using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace InM
{
    public partial class FormSetting : Form
    {
        IPAddress ip;

        public FormSetting()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            CheckNet.Checked = Properties.Settings.Default.NetSwitch;
            TxtClient.Text = Properties.Settings.Default.IP;
            TxtPort.Text = Properties.Settings.Default.Port.ToString();
        }

        private void CheckNet_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNet.Checked == true)
            {
                TxtPort.Enabled = true;
                TxtClient.Enabled = true;
                Properties.Settings.Default.NetSwitch = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                TxtPort.Enabled = false;
                TxtClient.Enabled = false;
                Properties.Settings.Default.NetSwitch = false;
                Properties.Settings.Default.Save();
            }
        }

        private void TxtPort_TextChanged(object sender, EventArgs e)
        {
            if (TxtPort.Text == "")
            {
                LabPortNotice.Text = "端口值不能为空";
                LabPortNotice.Visible = true;
            }
            else if (Convert.ToInt32(TxtPort.Text) >= 8000)
            {
                LabPortNotice.Visible = false;
            }
            else
            {
                LabPortNotice.Text = "输入的端口号请大于8000";
                LabPortNotice.Visible = true;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtPort.Text == "")
                {
                    TxtPort.Text = "8000";
                    Properties.Settings.Default.Port = Convert.ToInt32(TxtPort.Text);
                    Properties.Settings.Default.Save();
                }
                else if (Convert.ToInt32(TxtPort.Text) >= 8000)
                {
                    Properties.Settings.Default.Port = Convert.ToInt32(TxtPort.Text);
                    Properties.Settings.Default.Save();
                }
                else
                {
                    TxtPort.Text = "8000";
                    Properties.Settings.Default.Port = Convert.ToInt32(TxtPort.Text);
                    Properties.Settings.Default.Save();
                }

                ip = IPAddress.Parse(TxtClient.Text);
                Properties.Settings.Default.IP = TxtClient.Text;
                Properties.Settings.Default.Save();

                MessageBox.Show("设置保存成功", "系统提示");
            }
            catch
            {
                MessageBox.Show("设置保存失败","系统提示");
            }
        }
    }
}
