using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InM
{
    static class Program
    {
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            inMEventHandler = new InMEventHandler();
            trayContoller = new TrayController();
            reportTimer = new ReportTimer();
            api = new ApiController(authkey, endpoint);
            api.GetStart();
            var a = api.GetProcessinfo("1");
            formMain = new FormMain();
            formMain.Show();
            //Application.Run(new FormMain());
            Application.Run();
        }
    }
}
