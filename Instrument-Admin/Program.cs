﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            api = new ApiController(authkey, endpoint);

            inMAdminHandler = new InMAdminHandler();

            Update();
            frmLoad = new FrmLoad();
            frmLoad.Show();

            HttpListenServer();

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
                SharedData.processInfoVer = smold.processInfo;
                SharedData.userInfoVer = smold.userInfo;
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

            StorageModel sm = new StorageModel()
            {
                userInfo = SharedData.userInfoVer,
                processInfo = SharedData.processInfoVer
            };
            StorageController.Save(SharedData.dataPath, sm);

            /*
            if (startInfo.update > VERSION)
            {
                HttpClient client = new HttpClient();
                List<UpdateInfo> updateInfos = api.GetUpdate(startInfo.update.ToString()).ToList();
                foreach (UpdateInfo x in updateInfos)
                {
                    string downloadFilename = Path.Combine(SharedData.currentPath, x.name);
                    var response = client.GetAsync(x.url).Result;
                    using (var fs = new FileStream(downloadFilename + ".downloading", FileMode.Create))
                    {
                        response.Content.CopyToAsync(fs);
                    }
                    if (File.Exists(downloadFilename))
                    {
                        File.Move(downloadFilename, downloadFilename + ".delete");
                    }
                    File.Move(downloadFilename + ".downloading", downloadFilename);
                }
            }
            */

            //Application.Run(new FrmLoad());
        }

        static void HttpListenServer()
        {
            HttpListener httpListener = new HttpListener();

            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            httpListener.Prefixes.Add("http://localhost:8383/");
            httpListener.Start();

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
                        NoTimestamp.data = "No authkey";
                        JsonData = JsonConvert.SerializeObject(NoTimestamp);
                    }
                    else if(key == Encryption.MD5Hash(((timestamp - 500) * 3).ToString() + authkey))
                    {
                        switch (type)
                        {
                            case "start":
                                Root returnStart = new Root();
                                returnStart.code = 200;
                                returnStart.data = SharedData.startInfo;
                                JsonData = JsonConvert.SerializeObject(returnStart);
                                break;
                            case "userinfo":
                                Root returnUser = new Root();
                                returnUser.code = 200;
                                returnUser.data = SharedData.userInfo;
                                JsonData = JsonConvert.SerializeObject(returnUser);
                                break;
                            case "processinfo":
                                Root returnProcess = new Root();
                                returnProcess.code = 200;
                                returnProcess.data = SharedData.processInfo;
                                JsonData = JsonConvert.SerializeObject(returnProcess);
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
                    response.AppendHeader("Content-Type", "application/json;charset=UTF-8");
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
