﻿using System;
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

namespace InM
{
    public partial class FormMain : Form
    {
        Hook h = new Hook();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        public FormMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            //FullScreen();//最大化
            //h.Hook_Start();//禁用快捷键
            //SetWindowPos(this.Handle, -1, 0, 0, 0, 0, 1 | 2);//保持窗体最前
            Locations();
            //Translate();
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

        private void FullScreen()//全屏
        {
            this.SetVisibleCore(true);
        }

        private void TimKill_Tick(object sender, EventArgs e)//始终禁用，对xp有效
        {
            KillTaskmgr();
        }

        public void Locations()//控件相对于屏幕位置
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);
            int width = ScreenArea.Width; //屏幕宽度 
            int height = ScreenArea.Height;
            PlanLoad.Location = new Point((width - 300) / 2, (height - 300) / 2);
        }

        public void Translate()
        {
            PlanLoad.Parent = picBack;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelfProtect.Protect();
            //try
            //{
            //    Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            //    rk.SetValue("DisableTaskMgr", 1, Microsoft.Win32.RegistryValueKind.DWord);
            //    MessageBox.Show("禁用任务管理器成功");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelfProtect.Unprotect();
            //try
            //{
            //    Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            //    rk.SetValue("DisableTaskMgr", 0, Microsoft.Win32.RegistryValueKind.DWord);
            //    MessageBox.Show("启用任务管理器成功");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SharedData.User.Login(textBoxUsername.Text, textBoxUserpwd.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "登录失败");
            }
        }
    }
}