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
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SharedData.User.Login(TxtUserword.Text, TxtPassword.Text);
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
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.BtnLoad_Click(sender, e);//触发button事件  
            }
        }
    }
}
