using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace InM
{
    static class Program
    {
        const int VERSION = 1;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        const string authkey = "21232f297a57a5a743894a0e4a801fc3";
        const string endpoint = "https://api.anycen.com/instrument/";

        public static TrayController trayContoller;
        public static FormMain formMain;
        public static ReportTimer reportTimer;
        public static InMEventHandler inMEventHandler;
        public static ApiController api;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            logger.Info("软件开始启动");
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            trayContoller = new TrayController();
            reportTimer = new ReportTimer();
            if (Properties.Settings.Default.NetSwitch)
            {
                if (api.CheckConnection())
                {
                    api = new ApiController(authkey, endpoint);
                }
                else
                {
                    api = new ApiController(authkey, Properties.Settings.Default.IP);
                }
            }
            else
            {
                api = new ApiController(authkey, endpoint);
            }
            inMEventHandler = new InMEventHandler();

#if !DEBUG
            try
            {
                SelfProtect.Protect();
            }
            catch (Exception e)
            {
                logger.Warn("自我保护失败，请检查是否有管理员权限：" + e.Message);
            }
#endif

            Update();
            formMain = new FormMain();
            formMain.Show();
            
            Application.Run();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Fatal(e.ExceptionObject);
            Application.Restart();
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            logger.Fatal(e.Exception);
            Application.Restart();
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

            if (!api.CheckConnection())
            {
                logger.Warn("无法连接至公网服务器");
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

            StorageModel sm = new StorageModel()
            {
                userInfo = SharedData.userInfoVer,
                processInfo = SharedData.processInfoVer
            };
            StorageController.Save(SharedData.dataPath, sm);

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
        }
    }
}
