using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;
using System.Management;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Linq;

namespace InM
{
    public partial class FormMain : Form
    {
        Hook h = new Hook();
        public FormMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.User != "")
            {
                textBoxUsername.Text = Properties.Settings.Default.User;
                textBoxUsername.ForeColor = Color.Black;
            }
            
#if !DEBUG
            h.Hook_Start();//禁用快捷键
#endif
        }

        protected override bool ProcessKeyEventArgs(ref Message m)//禁用任务管理器
        {
            KillTaskmgr();
            return base.ProcessKeyEventArgs(ref m);
        }

        protected override void WndProc(ref Message m)//禁用鼠标右键
        {
            if (m.Msg == 0x205)
            {

            }
            base.WndProc(ref m);
        }

        private void KillTaskmgr()//禁用任务管理器
        {
            Process[] sum = Process.GetProcesses();
            foreach (Process p in sum)
            {
                if (p.ProcessName == "taskmgr" || p.ProcessName == "cmd")
                    try
                    {
                        p.Kill();
                    }
                    catch
                    {
                        ;
                    }
            }
        }

        private void TimKill_Tick(object sender, EventArgs e)//始终禁用，对xp有效
        {
            KillTaskmgr();
        }

        private void textBoxUserpwd_Leave(object sender, EventArgs e)
        {
            if (textBoxUserpwd.Text == "")
            {
                textBoxUserpwd.Text = "请输入密码";
                textBoxUserpwd.ForeColor = Color.Silver;
                textBoxUserpwd.UseSystemPasswordChar = false;
            }
        }

        private void textBoxUserpwd_Enter(object sender, EventArgs e)
        {
            if (textBoxUserpwd.Text == "请输入密码")
            {
                textBoxUserpwd.Text = "";
                textBoxUserpwd.ForeColor = Color.Black;
                textBoxUserpwd.UseSystemPasswordChar = true;
            }   
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "请输入用户名")
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                textBoxUsername.Text = "请输入用户名";
                textBoxUsername.ForeColor = Color.Silver;
            }
            else
            {
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.User = textBoxUsername.Text;
                Properties.Settings.Default.Save();
                SharedData.User.Login(textBoxUsername.Text, textBoxUserpwd.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "登录失败");
                if (ex.Message == "用户名错误")
                {
                    LinkRefreshData_LinkClicked(null, null);
                }
            }
        }

        private void LinkRefreshData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SharedData.userInfoVer = new InfoWithVer<UserInfo>()
                {
                    info = Program.api.GetUserinfo("ver").ToArray()
                };
                saveDatatoBin();
                MessageBox.Show("远程数据拉取成功", "系统提示");
            }
            catch
            {
                MessageBox.Show("无法从网络上拉取信息","网络错误");
            }
        }

        private void saveDatatoBin()
        {
            StorageModel bin = new StorageModel()
            {
                userInfo = SharedData.userInfoVer,
                processInfo = SharedData.processInfoVer
            };
            StorageController.Save(SharedData.dataPath, bin);
        }
    }
}
