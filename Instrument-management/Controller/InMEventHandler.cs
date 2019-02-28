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
        }

        private void User_UserChanged(object sender, UserChangedArgs e)
        {
            if (e.isLoggedin)
            {
                Program.formMain.Close();
                Program.trayContoller.notifyIcon.ShowBalloonTip(5000, e.LoggedinUser + "，欢迎使用", "右击托盘图标可进行更多操作", ToolTipIcon.Info);
            }
            else
            {
                Program.formMain = new FormMain();
                Program.formMain.Show();
            }
        }
    }
}
