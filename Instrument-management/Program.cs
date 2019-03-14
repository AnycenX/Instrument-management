using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
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

            WinFirewallPopup();
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            trayContoller = new TrayController();
            reportTimer = new ReportTimer();

            inMEventHandler = new InMEventHandler();

            StartSelfProtect();
            DelayConncet();

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

        private static void StartSelfProtect()
        {
#if !DEBUG
            try
            {
                //SelfProtect.Protect();
            }
            catch (Exception e)
            {
                logger.Warn("自我保护失败，请检查是否有管理员权限：" + e.Message);
            }

            try
            {
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                rk.SetValue("DisableTaskMgr", 1, Microsoft.Win32.RegistryValueKind.DWord);
                logger.Warn("关闭任务管理器成功");
            }
            catch (Exception e)
            {
                logger.Warn("关闭任务管理器失败，请检查是否有管理员权限：" + e.Message);
            }
#endif
        }

        private static void DelayConncet()
        {
            System.Timers.Timer timerDelay = new System.Timers.Timer(30000)
            {
                AutoReset = false,
            };
            timerDelay.Elapsed += TimerDelay_Elapsed;
            timerDelay.Start();
        }

        private static void TimerDelay_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckServer();
            Update();
            formMain.BeginInvoke((Action)(() => { formMain.HideDelay(); }));
        }

        private static void CheckServer()
        {
            api = new ApiController(authkey, endpoint);
            if (!api.CheckConnection()) //公网连不上
            {
                logger.Warn("无法连接公网");
                bool checkBin = false;
                if (Properties.Settings.Default.NetSwitch) //有内网配置
                {
                    api = new ApiController(authkey, Properties.Settings.Default.IP + ":" + Properties.Settings.Default.Port);
                    if (!api.CheckConnection()) //内网连不上
                    {
                        logger.Warn("无法连接内网" + Properties.Settings.Default.IP + ":" + Properties.Settings.Default.Port);
                        checkBin = true;
                    }
                }
                else //无内网配置
                {
                    logger.Warn("无内网配置");
                    checkBin = true;
                }

                if (checkBin) //公网内网都连不上
                {
                    if (!File.Exists(Path.Combine(SharedData.currentPath, "data.bin")))
                    {
                        logger.Error("无本地缓存数据，程序即将退出");
                        MessageBox.Show("系统初始化失败，请检查是否配置防火墙信息。", "系统错误");
                        Environment.Exit(0);
                    }
                }

                Properties.Settings.Default.NetConnect = false;
                Properties.Settings.Default.Save();
            }
            else //公网可以连
            {
                Properties.Settings.Default.NetConnect = true;
                Properties.Settings.Default.Save();
            }
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

            if (!Properties.Settings.Default.NetConnect) //无网络连接，读取过本地数据即可
            {
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

        private static void WinFirewallPopup()
        {
            IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 12345);

            TcpListener t = new TcpListener(ipLocalEndPoint);
            t.Start();
            t.Stop();
        }
    }
}
