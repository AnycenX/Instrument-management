using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InM
{
    public class ApiController
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        readonly string authkey;
        readonly string endpoint;
        private HttpClient httpClient = new HttpClient();

        public ApiController(string authkeyIn, string endpointIn)
        {
            authkey = authkeyIn;
            endpoint = endpointIn;
            httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            httpClient.Timeout = new TimeSpan(0, 0, 5);
            // TODO: 检测是否可以访问公网服务器，如果不行需要切换到内网服务器
        }
        public bool CheckConnection()
        {
            try
            {
                httpClient.SendAsync(new HttpRequestMessage
                {
                    Method = new HttpMethod("HEAD"),
                    RequestUri = new Uri(endpoint)
                }).Result.EnsureSuccessStatusCode();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public StartInfo GetStart()
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", "start" }
                };
            var result = SendAsync(parampairs).Result;
            return result.ToObject<StartInfo>();
        }

        public IEnumerable<UpdateInfo> GetUpdate(string version)
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", "update" },
                    { "version", version }
                };
            var result = SendAsync(parampairs).Result;
            return result.ToObject<IEnumerable<UpdateInfo>>();
        }

        public IEnumerable<UserInfo> GetUserinfo(string version)
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", "userinfo" },
                    { "version", version }
                };
            var result = SendAsync(parampairs).Result;
            return result.ToObject<IEnumerable<UserInfo>>();
        }

        public IEnumerable<ProcessInfo> GetProcessinfo(string version)
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", "processinfo" },
                    { "version", version }
                };
            var result = SendAsync(parampairs).Result;
            return result.ToObject<IEnumerable<ProcessInfo>>();
        }

        public void Uplog(string username, ProcessUplogModel processUplog)
        {
            Uplog(username, processUplog.name, processUplog.process, ToUnixTimestamp(processUplog.timestart), ToUnixTimestamp(processUplog.timestop));
        }

        public void Uplog(string username, string name, string process, long timestart, long timestop)
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", "uplog" },
                    { "username", username },
                    { "name", name },
                    { "pocess", process },
                    { "timestart", timestart.ToString() },
                    { "timestop", timestop.ToString() }
                };
            var result = SendAsync(parampairs).Result;
        }

        public void Inuser(UserInfo userInfo)
        {
            AdminUser("inuser", userInfo.username, userInfo.password, userInfo.passsalt, userInfo.rank);
        }

        public void Upuser(UserInfo userInfo, bool deleted = false)
        {
            AdminUser("upuser", userInfo.username, userInfo.password, userInfo.passsalt, userInfo.rank, userInfo.id, deleted);
        }

        private void AdminUser(string type, string username, string password, string passsalt, int rank, int id = -99, bool deleted = false)
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", type },
                    { "username", username },
                    { "password", password },
                    { "passsalt", passsalt },
                    { "rank", rank.ToString() }
                };
            if (id != -99)
            {
                parampairs.Add("id", id.ToString());
            }
            if (deleted)
            {
                parampairs.Add("deleted", "1");
            }
            var result = SendAsync(parampairs).Result;
        }

        public void Inprocess(ProcessInfo processInfo)
        {
            AdminProcess("inprocess", processInfo.name, processInfo.process, processInfo.type);
        }

        public void Upprocess(ProcessInfo processInfo, bool deleted = false)
        {
            AdminProcess("upprocess", processInfo.name, processInfo.process, processInfo.type, processInfo.id, deleted);
        }

        private void AdminProcess(string type, string name, string process, string pottype, int id = -99, bool deleted = false)
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", type },
                    { "name", name },
                    { "process", process },
                    { "pottype", pottype }
                };
            if (id != -99)
            {
                parampairs.Add("id", id.ToString());
            }
            if (deleted)
            {
                parampairs.Add("deleted", "1");
            }
            var result = SendAsync(parampairs).Result;
        }

        public IEnumerable<ProcessUplogModel> Getlog(string name, DateTime timestart, DateTime timestop)
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", "getlog" },
                    { "name", name },
                    { "timestart", ToUnixTimestamp(timestart).ToString() },
                    { "timestop", ToUnixTimestamp(timestop).ToString() }
                };
            var result = SendAsync(parampairs).Result;
            return result.ToObject<IEnumerable<ProcessUplogModel>>();
        }

        private async Task<JToken> SendAsync(IEnumerable<KeyValuePair<string, string>> param)
        {
            var paramlist = param.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            long unixTimestamp = ToUnixTimestamp(DateTime.Now);
            string key = Sign(unixTimestamp);
            paramlist.Add("timestamp", unixTimestamp.ToString());
            paramlist.Add("key", key);

            var builder = new UriBuilder(endpoint);
            builder.Port = -1;
            var content = new FormUrlEncodedContent(paramlist);
            string query = content.ReadAsStringAsync().Result;
            builder.Query = query.ToString();
            string url = builder.ToString();
            logger.Debug(url);

            // 如果出现http错误这里将会抛出异常
            string responseString = httpClient.GetStringAsync(url).Result;
            logger.Debug(responseString);
            JObject jObject = JObject.Parse(responseString);
            if ((int)jObject["code"] != 200)
            {
                throw new Exception($"{jObject["code"]}: {jObject["data"]}");
            }

            return jObject["data"];
        }

        string Sign(long unixTimestamp)
        {
            return Encryption.MD5Hash(((unixTimestamp - 500) * 3).ToString() + authkey);
        }

        long ToUnixTimestamp(DateTime dateTime)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(dateTime - startTime).TotalSeconds;
        }
    }
}
