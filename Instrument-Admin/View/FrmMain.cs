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
        public bool flag_user = true;
        public bool flag_process = true;
        public string cachePassSalt;
        public string cachePassWord;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if ((dateStop).Day - (dateStart).Day == 0)
            {
                MessageBox.Show("选择日期间隔请大于一天", "系统提示");
            }
            else
            {
                try
                {
                    var processInfo = Program.api.Getlog(userName, dateStart, dateStop);
                    DataLogInfo.DataSource = processInfo;
                }
                catch
                {
                    MessageBox.Show("无数据", "系统提示");
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
            flag_user = true;
            LblUserEdit.Text = "新建用户";
            PanUserEdit.Visible = true;
            TxtUserName.Enabled = true;
            TxtUserName.Text = "";
            TxtPassWord.Text = "";
            TxtRePassWord.Text = "";
        }

        private void BtnNewProcess_Click(object sender, EventArgs e)
        {
            flag_process = true;
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
                flag_user = false;
                LblUserEdit.Text = "编辑用户";
                PanUserEdit.Visible = true;

                var ele = (UserGdv.DataSource as IEnumerable<UserInfo>).ElementAt(e.RowIndex);
                TxtUserName.Text = ele.username;
                TxtUserName.Enabled = false;
                TxtPassWord.Text = ele.password;
                TxtRePassWord.Text = ele.password;
                cachePassWord = ele.password;
                cachePassSalt = ele.passsalt;
                if (ele.rank == 1)
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
                flag_process = false;
                LblProcessEdit.Text = "编辑用户";
                PanProcessEdit.Visible = true;

                var ele = (ProcessGdv.DataSource as IEnumerable<ProcessInfo>).ElementAt(e.RowIndex);
                TxtSoftName.Text = ele.name;
                TxtSoftName.Enabled = false;
                TxtProcessName.Text = ele.process;
                if (ele.type == "EXE")
                {
                    ComProcessType.Text = "管理员";
                }
                else if (ele.type == "MSI")
                {
                    ComProcessType.Text = "普通用户";
                }
                else if (ele.type == "VBS")
                {
                    ComProcessType.Text = "普通用户";
                }
            }
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            if (flag_user)
            {
                if (TxtUserName.Text != "" && TxtPassWord.Text != "" && TxtRePassWord.Text != "" && ComUserRank.Text != "")
                {
                    if (TxtUserName.Text.Length < 4)
                    {
                        MessageBox.Show("用户名长度应大于等于4位", "系统提示");
                    }
                    else if(TxtPassWord.Text.Length < 6)
                    {
                        MessageBox.Show("密码长度应大于等于6位", "系统提示");
                    }
                    else if (TxtPassWord.Text != TxtRePassWord.Text)
                    {
                        MessageBox.Show("两次密码输入不一致", "系统提示");
                    }
                    else
                    {
                        try
                        {
                            var users = new UserInfo();
                            users.username = TxtUserName.Text;
                            users.passsalt = GetRandomString(6, true, true, true, false, "");
                            users.password = Encryption.MD5HashWithSalt(TxtPassWord.Text, users.passsalt);
                            if (ComUserRank.Text == "普通用户")
                            {
                                users.rank = 0;
                            }
                            else
                            {
                                users.rank = 1;
                            }
                            Program.api.Inuser(users);
                            SharedData.userInfoVer = new InfoWithVer<UserInfo>()
                            {
                                info = Program.api.GetUserinfo(users.ToString()).ToArray()
                            };
                            DataUserinfo.DataSource = SharedData.userInfo;
                            MessageBox.Show("新增用户成功", "系统提示");
                            PanUserEdit.Visible = false;
                        }
                        catch
                        {
                            MessageBox.Show("新增用户失败，请重试", "系统提示");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("数据输入错误", "系统提示");
                }
                
            }
            else
            {
                if (TxtPassWord.Text != "" && TxtRePassWord.Text != "" && ComUserRank.Text != "")
                {
                    if (TxtPassWord.Text.Length < 6)
                    {
                        MessageBox.Show("密码长度应大于等于6位", "系统提示");
                    }
                    else if (TxtPassWord.Text != TxtRePassWord.Text)
                    {
                        MessageBox.Show("两次密码输入不一致", "系统提示");
                    }
                    else
                    {
                        try
                        {
                            var users = new UserInfo();
                            users.username = TxtUserName.Text;
                            if (TxtPassWord.Text == cachePassWord)
                            {
                                users.passsalt = cachePassSalt;
                                users.password = cachePassWord;
                            }
                            else
                            {
                                users.passsalt = GetRandomString(6, true, true, true, false, "");
                                users.password = Encryption.MD5HashWithSalt(TxtPassWord.Text, users.passsalt);
                            }
                            if (ComUserRank.Text == "普通用户")
                            {
                                users.rank = 0;
                            }
                            else
                            {
                                users.rank = 1;
                            }
                            Program.api.Upuser(users);
                            SharedData.userInfoVer = new InfoWithVer<UserInfo>()
                            {
                                info = Program.api.GetUserinfo(users.ToString()).ToArray()
                            };
                            DataUserinfo.DataSource = SharedData.userInfo;
                            MessageBox.Show("用户信息更新成功", "系统提示");
                            PanUserEdit.Visible = false;
                        }
                        catch
                        {
                            MessageBox.Show("用户信息更新失败，请重试", "系统提示");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("数据输入错误", "系统提示");
                }
            }
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (flag_process)
            {
                if (TxtSoftName.Text != "" && TxtProcessName.Text != "" && ComProcessType.Text != "")
                {
                    
                }
                else
                {
                    MessageBox.Show("数据输入错误", "系统提示");
                }
            }
            else
            {
                MessageBox.Show("edit", "系统提示");
            }
        }

        ///<summary>
        ///生成随机字符串 
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
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
