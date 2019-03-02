using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InM
{
    public class InMEventHandler
    {
        public InMEventHandler()
        {
            SharedData.User.UserChanged += User_UserChanged;
            Program.reportTimer.ReportUpload += ReportTimer_ReportUpload;
        }

        private void User_UserChanged(object sender, UserChangedArgs e)
        {
            if (e.isLoggedin)
            {
                Program.formMain.Close();
                Program.trayContoller.notifyIcon.ShowBalloonTip(5000, e.LoggedinUser + "，欢迎使用", "右击托盘图标可进行更多操作", ToolTipIcon.Info);
                Program.reportTimer.Start();
            }
            else
            {
                Program.formMain = new FormMain();
                Program.formMain.Show();
                Program.reportTimer.Stop();
            }
        }

        private void ReportTimer_ReportUpload(object sender, ReportUploadArgs e)
        {
            foreach (var x in e.processUplogModels)
            {
                try
                {
                    Program.api.Uplog(SharedData.LoggedinUser, x);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
