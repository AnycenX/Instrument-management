using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InM;

namespace InM_Admin.Controller
{
    class InMAdminHandler
    {
        public InMAdminHandler()
        {
            SharedData.User.UserChanged += User_UserChanged;
        }

        private void User_UserChanged(object sender, UserChangedArgs e)
        {
            if (e.isLoggedin)
            {
                if (e.isAdmin)
                {
                    Program.frmLoad.Hide();
                    Program.frmMain = new FrmMain();
                    Program.frmMain.Show();
                }
                else
                {
                    throw new Exception("请使用管理员账户登录");
                }
            }
            else
            {
                throw new Exception("登录失败");
            }
        }

        private void Get_Log(string username, DateTime timestart, DateTime timestop)
        {
            Program.api.Getlog(username, timestart, timestop);
        }
    }
}
