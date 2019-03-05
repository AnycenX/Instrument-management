using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InM;

namespace InM_Admin
{
    public partial class FrmLoad : Form
    {
        public FrmLoad()
        {
            InitializeComponent();
            TxtUserword.Text = Properties.Settings.Default.User;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SharedData.User.Login(TxtUserword.Text, TxtPassword.Text);
                Properties.Settings.Default.User = TxtUserword.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "登录失败");
            }
        }

        private void FrmLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                BtnLoad_Click(sender, e);
            }
        }

        private void LinkForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("请联系高级管理员重置密码","系统提示");
        }
    }
}
