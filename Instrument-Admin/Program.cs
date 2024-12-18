﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InM;
using InM.Core.Model;
using InM_Admin.Controller;
using Newtonsoft.Json;

namespace InM_Admin
{
    static class Program
    {
        const int VERSION = 1;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        const string authkey = "21232f297a57a5a743894a0e4a801fc3";
        const string endpoint = "https://api.anycen.com/instrument/";
        public static ApiController api;
        public static FrmLoad frmLoad;
        public static FrmMain frmMain;
        public static InMAdminHandler inMAdminHandler;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            logger.Info("软件开始启动");

            IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 12345);

            TcpListener t = new TcpListener(ipLocalEndPoint);
            t.Start();
            t.Stop();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            api = new ApiController(authkey, endpoint);

            Properties.Settings.Default.NetConnect = true;
            if (!api.CheckConnection())
            {
                Properties.Settings.Default.NetConnect = false;
                if (Properties.Settings.Default.NetSwitch)
                {
                    logger.Info("启动局域网模式");
                    HttpListenServer();
                }
            }
            Properties.Settings.Default.Save();

            inMAdminHandler = new InMAdminHandler();

            Update();
            frmLoad = new FrmLoad();
            frmLoad.Show();
            
            Application.Run();
        }

        static void Update()
        {
            DirectoryInfo theFolder = new DirectoryInfo(SharedData.currentPath);
            FileInfo[] fileInfo = theFolder.GetFiles();
            foreach (FileInfo file in fileInfo)
            {
                if (file.Name.Contains(".delete"))
                {
                    File.Delete(file.FullName);
                }
            }

            StorageModel smold = StorageController.Load(SharedData.dataPath);
            if (smold != null)
            {
                SharedData.updateInfoVer = smold.updateInfo;
                SharedData.processInfoVer = smold.processInfo;
                SharedData.userInfoVer = smold.userInfo;
            }

            if (!api.CheckConnection())
            {
                //TODO: 局域网处理
                return;
            }

            StartInfo startInfo = api.GetStart();
            if (startInfo.processinfo > (smold?.processInfo.version ?? -1))
            {
                SharedData.processInfoVer = new InfoWithVer<ProcessInfo>()
                {
                    version = startInfo.processinfo,
                    info = api.GetProcessinfo(startInfo.processinfo.ToString()).ToArray()
                };
            }
            if (startInfo.userinfo > (smold?.userInfo.version ?? -1))
            {
                SharedData.userInfoVer = new InfoWithVer<UserInfo>()
                {
                    version = startInfo.userinfo,
                    info = api.GetUserinfo(startInfo.userinfo.ToString()).ToArray()
                };
            }

            SharedData.updateInfoVer = new InfoWithVer<UpdateInfo>()
            {
                version = startInfo.update,
                info = api.GetUpdate(startInfo.update.ToString()).ToArray()
            };

            StorageModel sm = new StorageModel()
            {
                updateInfo = SharedData.updateInfoVer,
                userInfo = SharedData.userInfoVer,
                processInfo = SharedData.processInfoVer
            };
            StorageController.Save(SharedData.dataPath, sm);
        }

        static void HttpListenServer()
        {
            HttpListener httpListener = new HttpListener();

            try
            {
                httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                //httpListener.Prefixes.Add(string.Format("http://{0}:{1}/", "192.168.31.201", "8888"));Properties.Settings.Default.IP
                httpListener.Prefixes.Add(string.Format("http://{0}:{1}/", Properties.Settings.Default.IP, Properties.Settings.Default.Port));
                httpListener.Start();
            }
            catch(Exception e)
            {
                httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                httpListener.Prefixes.Add(string.Format("http://localhost:{1}/", Properties.Settings.Default.IP, Properties.Settings.Default.Port));
                httpListener.Start();
                logger.Info("局域网启动错误：" + e.Message);
                MessageBox.Show("IP地址输入错误，请登录后前往设置页面修改。","系统提示");
            }

            new Thread(new ThreadStart(delegate
            {
                while (true)
                {
                    HttpListenerContext httpListenerContext = httpListener.GetContext();

                    //解析Request请求
                    HttpListenerRequest request = httpListenerContext.Request;

                    string type = "";
                    long timestamp = 0;
                    string key = "";
                    string version = "";
                    string JsonData = "";

                    try
                    {
                        type = request.QueryString["type"];
                        timestamp = long.Parse(request.QueryString["timestamp"]);
                        key = request.QueryString["key"];
                        version = request.QueryString["version"];
                    }
                    catch
                    {
                        //此处略过错误
                    }

                    if (key == "")
                    {
                        Root returnNoAuthkey = new Root();
                        returnNoAuthkey.code = 301;
                        returnNoAuthkey.data = "No authkey";
                        JsonData = JsonConvert.SerializeObject(returnNoAuthkey);
                    }
                    else if (timestamp.ToString() == "")
                    {
                        Root NoTimestamp = new Root();
                        NoTimestamp.code = 302;
                        NoTimestamp.data = "No timestamp";
                        JsonData = JsonConvert.SerializeObject(NoTimestamp);
                    }
                    else if(key == Encryption.MD5Hash(((timestamp - 500) * 3).ToString() + authkey))
                    {
                        switch (type)
                        {
                            case "start":
                                try
                                {
                                    Root returnStart = new Root();
                                    returnStart.code = 200;
                                    returnStart.data = SharedData.startInfo;
                                    JsonData = JsonConvert.SerializeObject(returnStart);
                                }
                                catch
                                {
                                    Root returnErrorAuthkey = new Root();
                                    returnErrorAuthkey.code = 500;
                                    returnErrorAuthkey.data = "System error";
                                    JsonData = JsonConvert.SerializeObject(returnErrorAuthkey);
                                }
                                break;
                            case "userinfo":
                                try
                                {
                                    Root returnUser = new Root();
                                    returnUser.code = 200;
                                    returnUser.data = SharedData.userInfo;
                                    JsonData = JsonConvert.SerializeObject(returnUser);
                                }
                                catch
                                {
                                    Root returnErrorAuthkey = new Root();
                                    returnErrorAuthkey.code = 500;
                                    returnErrorAuthkey.data = "System error";
                                    JsonData = JsonConvert.SerializeObject(returnErrorAuthkey);
                                }
                                break;
                            case "processinfo":
                                try
                                {
                                    Root returnProcess = new Root();
                                    returnProcess.code = 200;
                                    returnProcess.data = SharedData.processInfo;
                                    JsonData = JsonConvert.SerializeObject(returnProcess);
                                }
                                catch
                                {
                                    Root returnErrorAuthkey = new Root();
                                    returnErrorAuthkey.code = 500;
                                    returnErrorAuthkey.data = "System error";
                                    JsonData = JsonConvert.SerializeObject(returnErrorAuthkey);
                                }
                                break;
                            default:
                                Root returnNoType = new Root();
                                returnNoType.code = 300;
                                returnNoType.data = "No type";
                                JsonData = JsonConvert.SerializeObject(returnNoType);
                                break;
                        }
                    }
                    else
                    {
                        Root returnErrorAuthkey = new Root();
                        returnErrorAuthkey.code = 303;
                        returnErrorAuthkey.data = "Error authkey";
                        JsonData = JsonConvert.SerializeObject(returnErrorAuthkey);
                    }

                    //发送Response请求
                    HttpListenerResponse response = httpListenerContext.Response;
                    response.StatusCode = 200;
                    response.ContentType = "application/json;charset=UTF-8";
                    response.ContentEncoding = Encoding.UTF8;
                    using (StreamWriter writer = new StreamWriter(httpListenerContext.Response.OutputStream))
                    {
                        writer.WriteLine(JsonData);
                        writer.Close();
                        response.Close();
                    }

                }
            })).Start();
        }
    }
}
