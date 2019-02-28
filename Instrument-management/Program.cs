using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InM
{
    static class Program
    {
        public static TrayController trayContoller;
        public static FormMain formMain;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InMEventHandler inMEventHandler = new InMEventHandler();
            trayContoller = new TrayController();
            ApiController api = new ApiController();
            api.GetStart();
            var a = api.GetProcessinfo("1");
            formMain = new FormMain();
            formMain.Show();
            //Application.Run(new FormMain());
            Application.Run();
        }
    }
}
