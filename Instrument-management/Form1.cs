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

namespace Instrument_management
{
    public partial class frmMain : Form
    {
        Hook h = new Hook();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            FullScreen();//最大化
            h.Hook_Start();//禁用快捷键
            SetWindowPos(this.Handle, -1, 0, 0, 0, 0, 1 | 2);//保持窗体最前
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
            try
            {
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                rk.SetValue("DisableTaskMgr", 1, Microsoft.Win32.RegistryValueKind.DWord);
                MessageBox.Show("禁用任务管理器成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                rk.SetValue("DisableTaskMgr", 0, Microsoft.Win32.RegistryValueKind.DWord);
                MessageBox.Show("启用任务管理器成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "请输入密码";
                textBox2.ForeColor = Color.Silver;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "请输入密码")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
            }   
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "请输入用户名")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入用户名";
                textBox1.ForeColor = Color.Silver;
            }
        }
    }
}
