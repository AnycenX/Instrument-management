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
    public partial class FrmMain : Form
    {
        public DateTime dateStart;
        public DateTime dateStop;
        public string userName;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if ((dateStop).Day - (dateStart).Day == 0)
            {
                MessageBox.Show("选择日期间隔请大于一天");
            }
            else
            {
                //MessageBox.Show(userName + "," + dateStart + "," + dateStop + "," + (dateStop - dateStart));
                //IEnumerable<ProcessUplogModelEx> processInfo = (IEnumerable<ProcessUplogModelEx>)Program.api.Getlog(userName, dateStart, dateStop);
                try
                {
                    var processInfo = Program.api.Getlog(userName, dateStart, dateStop);
                    DataLogInfo.DataSource = processInfo;
                }
                catch
                {
                    MessageBox.Show("无数据");
                }
                
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DataLogInfo.AutoGenerateColumns = false;
            DataUserinfo.AutoGenerateColumns = false;
            DataProcessInfo.AutoGenerateColumns = false;

            ComDayChange.SelectedIndex = ComDayChange.Items.IndexOf("今日数据");
            ComUsername.DataSource = (from x in SharedData.userInfo select x.username).ToArray();
            DataUserinfo.DataSource = SharedData.userInfo;
            DataProcessInfo.DataSource = SharedData.processInfo;

            dateStart = DateTime.Now.Date.AddDays(-1);
            dateStop = DateTime.Now.Date;
            userName = ComUsername.Text;
        }

        private void ComDayChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComDayChange.SelectedIndex)
            {
                case 0://今天
                    dateStart = DateTime.Now.Date.AddDays(-1);
                    dateStop = DateTime.Now.Date;
                    break;
                case 1://三天
                    dateStart = DateTime.Now.Date.AddDays(-3);
                    dateStop = DateTime.Now.Date;
                    break;
                case 2://七天
                    dateStart = DateTime.Now.Date.AddDays(-7);
                    dateStop = DateTime.Now.Date;
                    break;
                case 3://一月
                    dateStart = DateTime.Now.Date.AddDays(-30);
                    dateStop = DateTime.Now.Date;
                    break;
            }
            if (ComDayChange.SelectedIndex == 4)
            {
                dateStart = DateStart.Value;
                dateStop = DateStop.Value;
                DateStart.Enabled = true;
                DateStop.Enabled = true;
            }
            else
            {
                DateStart.Enabled = false;
                DateStop.Enabled = false;
            }
        }

        private void ComUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            userName = ComUsername.Text;
        }

        private void DateStart_ValueChanged(object sender, EventArgs e)
        {
            dateStart = DateStart.Value;
        }

        private void DateStop_ValueChanged(object sender, EventArgs e)
        {
            dateStop = DateStop.Value;
        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            LblUserEdit.Text = "新建用户";
            PanUserEdit.Visible = true;
            TxtUserName.Enabled = true;
            TxtUserName.Text = "";
            TxtPassWord.Text = "";
            TxtRePassWord.Text = "";
        }

        private void BtnNewProcess_Click(object sender, EventArgs e)
        {
            LblProcessEdit.Text = "新建监控";
            PanProcessEdit.Visible = true;
            TxtSoftName.Enabled = true;
            TxtSoftName.Text = "";
            TxtProcessName.Text = "";
        }

        private void btnProcessClose_Click(object sender, EventArgs e)
        {
            PanProcessEdit.Visible = false;
        }

        private void btnUserClose_Click(object sender, EventArgs e)
        {
            PanUserEdit.Visible = false;
        }

        private void btnUserClose_MouseMove(object sender, MouseEventArgs e)
        {
            btnUserClose.BackColor = Color.Red;
            btnUserClose.ForeColor = Color.White;
        }

        private void btnUserClose_MouseLeave(object sender, EventArgs e)
        {
            btnUserClose.BackColor = Color.Transparent;
            btnUserClose.ForeColor = Color.Red;
        }

        private void btnProcessClose_MouseMove(object sender, MouseEventArgs e)
        {
            btnProcessClose.BackColor = Color.Red;
            btnProcessClose.ForeColor = Color.White;
        }

        private void btnProcessClose_MouseLeave(object sender, EventArgs e)
        {
            btnProcessClose.BackColor = Color.Transparent;
            btnProcessClose.ForeColor = Color.Red;
        }

        private void CheckUser_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckUser.Checked == true)
            {
                ComUsername.Enabled = true;
                userName = ComUsername.Text;
            }
            else
            {
                ComUsername.Enabled = false;
                userName = "";
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void DataUserinfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView UserGdv = sender as DataGridView;//获取事件发送者
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//防止 Index 出错
            {
                LblUserEdit.Text = "编辑用户";
                PanUserEdit.Visible = true;
                TxtUserName.Text = UserGdv.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtUserName.Enabled = false;
                if (UserGdv.Rows[e.RowIndex].Cells[1].Value.ToString() == "1")
                {
                    ComUserRank.Text = "管理员";
                }
                else
                {
                    ComUserRank.Text = "普通用户";
                }
            }
        }

        private void DataProcessInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView ProcessGdv = sender as DataGridView;//获取事件发送者
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//防止 Index 出错
            {
                LblProcessEdit.Text = "编辑用户";
                PanProcessEdit.Visible = true;
                TxtSoftName.Text = ProcessGdv.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtSoftName.Enabled = false;
                TxtProcessName.Text = ProcessGdv.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (ProcessGdv.Rows[e.RowIndex].Cells[2].Value.ToString() == "EXE")
                {
                    ComProcessType.Text = "管理员";
                }
                else if (ProcessGdv.Rows[e.RowIndex].Cells[2].Value.ToString() == "MSI")
                {
                    ComProcessType.Text = "普通用户";
                }
                else if (ProcessGdv.Rows[e.RowIndex].Cells[2].Value.ToString() == "VBS")
                {
                    ComProcessType.Text = "普通用户";
                }
            }
        }

        private void DataUserinfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.Value = (int)e.Value == 1 ? "管理员" : "普通用户";
            }
        }

        private void DataLogInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == 3)
            {
                var ele = (dgv.DataSource as IEnumerable<ProcessUplogModel>).ElementAt(e.RowIndex);
                e.Value = (ele.timestop - ele.timestart).ToString();
            }
        }
    }
}
