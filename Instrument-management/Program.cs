using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Instrument_management
{
    static class Program
    {
        static TrayController trayContoller;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            trayContoller = new TrayController();
            //Application.Run(new frmMain());
            Application.Run();
        }
    }
}
