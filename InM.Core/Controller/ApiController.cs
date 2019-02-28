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
        const string authkey = "21232f297a57a5a743894a0e4a801fc3";
        const string endpoint = "https://api.anycen.com/instrument/";
        private HttpClient httpClient = new HttpClient();

        public ApiController()
        {
            httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
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
        public void GetStart()
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", "start" }
                };
            var result = SendAsync(parampairs).Result;
            Console.WriteLine(result);
        }

        public void GetUpdate(string version)
        {
            Dictionary<string, string> parampairs = new Dictionary<string, string>
                {
                    { "type", "update" },
                    { "version", version }
                };
            var result = SendAsync(parampairs).Result;
            Console.WriteLine(result);
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
            Console.WriteLine(result);
        }

        public 

        async Task<JToken> SendAsync(IEnumerable<KeyValuePair<string, string>> param)
        {
            var paramlist = param.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            long unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string key = Sign(unixTimestamp);
            paramlist.Add("timestamp", unixTimestamp.ToString());
            paramlist.Add("key", key);

            var builder = new UriBuilder(endpoint);
            builder.Port = -1;
            var content = new FormUrlEncodedContent(paramlist);
            string query = content.ReadAsStringAsync().Result;
            builder.Query = query.ToString();
            string url = builder.ToString();
            Console.WriteLine(url);

            // 如果出现http错误这里将会抛出异常
            string responseString = await httpClient.GetStringAsync(url);
            Console.WriteLine(responseString);
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
    }
}
