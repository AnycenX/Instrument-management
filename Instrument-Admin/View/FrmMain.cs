using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InM;
using InM.Core.Model;
using InM_Admin.Controller;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public int cacheUserID;
        public int cacheProcessID;

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

            dateStart = DateTime.Now.Date;
            dateStop = DateTime.Now.Date.AddDays(1);
            userName = ComUsername.Text;

            CheckNet.Checked = Properties.Settings.Default.NetSwitch;
            TxtPort.Text = Properties.Settings.Default.Port.ToString();

            if (Properties.Settings.Default.NetConnect)
            {
                NetHideLog.Visible = false;
                NetHideUser.Visible = false;
                NetHideProcess.Visible = false;
            }
            else
            {
                NetHideLog.Visible = true;
                NetHideUser.Visible = true ;
                NetHideProcess.Visible = true;
            }
        }

        private void ComDayChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComDayChange.SelectedIndex)
            {
                case 0://今天
                    dateStart = DateTime.Now.Date;
                    dateStop = DateTime.Now.Date.AddDays(1);
                    break;
                case 1://三天
                    dateStart = DateTime.Now.Date.AddDays(-2);
                    dateStop = DateTime.Now.Date.AddDays(1);
                    break;
                case 2://七天
                    dateStart = DateTime.Now.Date.AddDays(-6);
                    dateStop = DateTime.Now.Date.AddDays(1);
                    break;
                case 3://一月
                    dateStart = DateTime.Now.Date.AddDays(-29);
                    dateStop = DateTime.Now.Date.AddDays(1);
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
            BtnDelUser.Visible = false;
            LblUserEdit.Text = "新建用户";
            PanUserEdit.Visible = true;
            TxtUserName.Text = "";
            TxtPassWord.Text = "";
            TxtRePassWord.Text = "";
        }

        private void BtnNewProcess_Click(object sender, EventArgs e)
        {
            flag_process = true;
            BtnDelProcess.Visible = false;
            LblProcessEdit.Text = "新建监控";
            PanProcessEdit.Visible = true;
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
                BtnDelUser.Visible = true;

                var ele = (UserGdv.DataSource as IEnumerable<UserInfo>).ElementAt(e.RowIndex);
                TxtUserName.Text = ele.username;
                TxtPassWord.Text = ele.password;
                TxtRePassWord.Text = ele.password;
                cachePassWord = ele.password;
                cachePassSalt = ele.passsalt;
                cacheUserID = ele.id;
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
                LblProcessEdit.Text = "编辑监控";
                PanProcessEdit.Visible = true;
                BtnDelProcess.Visible = true;

                var ele = (ProcessGdv.DataSource as IEnumerable<ProcessInfo>).ElementAt(e.RowIndex);
                TxtSoftName.Text = ele.name;
                TxtProcessName.Text = ele.process;
                cacheProcessID = ele.id;
                if (ele.type == "EXE")
                {
                    ComProcessType.Text = "EXE";
                }
                else if (ele.type == "MSI")
                {
                    ComProcessType.Text = "MSI";
                }
                else if (ele.type == "VBS")
                {
                    ComProcessType.Text = "VBS";
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
                            refreshUser();
                            MessageBox.Show("新增用户成功", "系统提示");
                            PanUserEdit.Visible = false;
                            ComUsername.DataSource = (from x in SharedData.userInfo select x.username).ToArray();
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
                            users.id = cacheUserID;
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
                            refreshUser();
                            MessageBox.Show("用户信息更新成功", "系统提示");
                            PanUserEdit.Visible = false;
                            ComUsername.DataSource = (from x in SharedData.userInfo select x.username).ToArray();
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
                    try
                    {
                        var processs = new ProcessInfo();
                        processs.name = TxtSoftName.Text;
                        processs.process = TxtProcessName.Text;
                        processs.type = ComProcessType.Text;
                        Program.api.Inprocess(processs);
                        refreshProcess();
                        MessageBox.Show("监控进程添加成功", "系统提示");
                        PanProcessEdit.Visible = false;
                    }
                    catch
                    {
                        MessageBox.Show("监控进程添加失败，请重试", "系统提示");
                    }
                }
                else
                {
                    MessageBox.Show("数据输入错误", "系统提示");
                }
            }
            else
            {
                try
                {
                    var processs = new ProcessInfo();
                    processs.id = cacheProcessID;
                    processs.name = TxtSoftName.Text;
                    processs.process = TxtProcessName.Text;
                    processs.type = ComProcessType.Text;
                    Program.api.Upprocess(processs);
                    refreshProcess();
                    MessageBox.Show("监控进程修改成功", "系统提示");
                    PanProcessEdit.Visible = false;
                }
                catch
                {
                    MessageBox.Show("监控进程修改失败，请重试", "系统提示");
                }
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

        private void RefreshUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refreshUser();
            MessageBox.Show("用户信息刷新成功", "系统提示");
        }

        private void RefreshProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refreshProcess();
            MessageBox.Show("监控进程刷新成功", "系统提示");
        }

        private void refreshUser()
        {
            SharedData.userInfoVer = new InfoWithVer<UserInfo>()
            {
                info = Program.api.GetUserinfo("ver").ToArray()
            };
            DataUserinfo.DataSource = SharedData.userInfo;
            saveDatatoBin();
        }

        private void refreshProcess()
        {
            SharedData.processInfoVer = new InfoWithVer<ProcessInfo>()
            {
                info = Program.api.GetProcessinfo("ver").ToArray()
            };
            DataProcessInfo.DataSource = SharedData.processInfo;
            saveDatatoBin();
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

        private void BtnDelUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("您真的要确认删除该用户吗？", "系统提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var users = new UserInfo();
                    users.id = cacheUserID;
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
                    Program.api.Upuser(users, true);
                    refreshUser();
                    MessageBox.Show("用户信息删除成功", "系统提示");
                    PanUserEdit.Visible = false;
                    ComUsername.DataSource = (from x in SharedData.userInfo select x.username).ToArray();
                }
                catch
                {
                    MessageBox.Show("用户信息删除失败，请重试", "系统提示");
                }
            }
        }

        private void BtnDelProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("您真的要确认删除该监控进程吗？", "系统提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var processs = new ProcessInfo();
                    processs.id = cacheProcessID;
                    processs.name = TxtSoftName.Text;
                    processs.process = TxtProcessName.Text;
                    processs.type = ComProcessType.Text;
                    Program.api.Upprocess(processs, true);
                    refreshProcess();
                    MessageBox.Show("监控进程删除成功", "系统提示");
                    PanProcessEdit.Visible = false;
                }
                catch
                {
                    MessageBox.Show("监控进程删除失败，请重试", "系统提示");
                }
            }
        }

        private void CheckNet_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckNet.Checked == true)
            {
                TxtPort.Enabled = true;
                Properties.Settings.Default.NetSwitch = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                TxtPort.Enabled = false;
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

        public static Task<string> HttpGetAsync(string url) => Task.Run(() => HttpGet(url));

        private async void BtnCheckUpdate_Click(object sender, EventArgs e)
        {
            string result = await HttpGetAsync("https://api.anycen.com/instrument/adminsoft/check/");
            try
            {
                if (Convert.ToInt32(BuildVersion.Text) < Convert.ToInt32(result))
                {
                    MessageBox.Show("发现新版本，请前往打开页面依照提示下载更新", "更新提示");
                    Process.Start("https://api.anycen.com/instrument/adminsoft/");
                }
                else
                {
                    MessageBox.Show("目前已经是最新版本", "更新提示");
                }
            }
            catch
            {
                MessageBox.Show("返回远程数据错误", "更新提示");
            }
        }

        public static string HttpGet(string url)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
                wbRequest.Method = "GET";
                HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
                using (Stream responseStream = wbResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        result = sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        private void LinkHandBook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://api.anycen.com/instrument/adminsoft/doc/");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Port = Convert.ToInt32(TxtPort.Text);
                Properties.Settings.Default.IP = TxtClient.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("设置保存成功", "系统提示");
            }
            catch
            {
                MessageBox.Show("设置保存失败", "系统提示");
            }
        }

        public static string InvokeExcute(string Command)
        {
            Command = Command.Trim().TrimEnd('&') + "&exit";
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
                p.Start();//启动程序
                          //向cmd窗口写入命令
                p.StandardInput.WriteLine(Command);
                p.StandardInput.AutoFlush = true;
                //获取cmd窗口的输出信息
                StreamReader reader = p.StandardOutput;//截取输出流
                StreamReader error = p.StandardError;//截取错误信息
                string str = reader.ReadToEnd() + error.ReadToEnd();
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
                return str;
            }
        }
    }
}
