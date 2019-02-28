using InM.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InM
{
    class TrayController
    {
        public NotifyIcon notifyIcon;
        private ContextMenu contextMenu;

        public TrayController()
        {
            initMenu();
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Text = "仪器管理系统";
            notifyIcon.Icon = Resources.trayIcon;
        }

        private void initMenu()
        {
            contextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("设置", settingItem_Click),
                new MenuItem("退出登录", logoutItem_Click)
            });
        }

        private void settingItem_Click(object sender, EventArgs e)
        {
            FormSetting form = new FormSetting();
            form.Show();
        }

        private void logoutItem_Click(object sender, EventArgs e)
        {
            SharedData.User.Logout();
        }
    }
}
