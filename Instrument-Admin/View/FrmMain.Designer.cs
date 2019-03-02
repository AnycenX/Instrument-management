namespace InM_Admin
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabCont = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CheckUser = new System.Windows.Forms.CheckBox();
            this.DataLogInfo = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefreshLog = new System.Windows.Forms.LinkLabel();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.DateStart = new System.Windows.Forms.DateTimePicker();
            this.DateStop = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComDayChange = new System.Windows.Forms.ComboBox();
            this.ComUsername = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RefreshUser = new System.Windows.Forms.LinkLabel();
            this.BtnNewUser = new System.Windows.Forms.Button();
            this.PanUserEdit = new System.Windows.Forms.Panel();
            this.TxtRePassWord = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnUser = new System.Windows.Forms.Button();
            this.ComUserRank = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtPassWord = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUserClose = new System.Windows.Forms.Label();
            this.LblUserEdit = new System.Windows.Forms.Label();
            this.DataUserinfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.RefreshProcess = new System.Windows.Forms.LinkLabel();
            this.BtnNewProcess = new System.Windows.Forms.Button();
            this.PanProcessEdit = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnProcess = new System.Windows.Forms.Button();
            this.ComProcessType = new System.Windows.Forms.ComboBox();
            this.TxtProcessName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtSoftName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnProcessClose = new System.Windows.Forms.Label();
            this.LblProcessEdit = new System.Windows.Forms.Label();
            this.DataProcessInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.TabCont.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataLogInfo)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.PanUserEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataUserinfo)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.PanProcessEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataProcessInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCont
            // 
            this.TabCont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabCont.Controls.Add(this.tabPage2);
            this.TabCont.Controls.Add(this.tabPage3);
            this.TabCont.Controls.Add(this.tabPage4);
            this.TabCont.Controls.Add(this.tabPage5);
            this.TabCont.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabCont.Location = new System.Drawing.Point(0, 0);
            this.TabCont.Name = "TabCont";
            this.TabCont.SelectedIndex = 0;
            this.TabCont.Size = new System.Drawing.Size(649, 424);
            this.TabCont.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CheckUser);
            this.tabPage2.Controls.Add(this.DataLogInfo);
            this.tabPage2.Controls.Add(this.RefreshLog);
            this.tabPage2.Controls.Add(this.BtnSearch);
            this.tabPage2.Controls.Add(this.DateStart);
            this.tabPage2.Controls.Add(this.DateStop);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.ComDayChange);
            this.tabPage2.Controls.Add(this.ComUsername);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(641, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " 日志查看 ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CheckUser
            // 
            this.CheckUser.AutoSize = true;
            this.CheckUser.Checked = true;
            this.CheckUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckUser.Location = new System.Drawing.Point(458, 54);
            this.CheckUser.Name = "CheckUser";
            this.CheckUser.Size = new System.Drawing.Size(98, 24);
            this.CheckUser.TabIndex = 14;
            this.CheckUser.Text = "按用户查询";
            this.CheckUser.UseVisualStyleBackColor = true;
            this.CheckUser.CheckedChanged += new System.EventHandler(this.CheckUser_CheckedChanged);
            // 
            // DataLogInfo
            // 
            this.DataLogInfo.AllowUserToAddRows = false;
            this.DataLogInfo.AllowUserToDeleteRows = false;
            this.DataLogInfo.AllowUserToResizeColumns = false;
            this.DataLogInfo.AllowUserToResizeRows = false;
            this.DataLogInfo.BackgroundColor = System.Drawing.Color.White;
            this.DataLogInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataLogInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4});
            this.DataLogInfo.Location = new System.Drawing.Point(14, 93);
            this.DataLogInfo.MultiSelect = false;
            this.DataLogInfo.Name = "DataLogInfo";
            this.DataLogInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataLogInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataLogInfo.RowHeadersVisible = false;
            this.DataLogInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataLogInfo.RowTemplate.Height = 23;
            this.DataLogInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataLogInfo.Size = new System.Drawing.Size(613, 284);
            this.DataLogInfo.TabIndex = 13;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "username";
            this.Column2.HeaderText = "用户名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 154;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "name";
            this.Column1.HeaderText = "软件名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 152;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "timestart";
            this.Column3.HeaderText = "开始时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 152;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "timeStop";
            this.Column4.HeaderText = "结束时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 152;
            // 
            // RefreshLog
            // 
            this.RefreshLog.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.RefreshLog.AutoSize = true;
            this.RefreshLog.LinkColor = System.Drawing.Color.Gray;
            this.RefreshLog.Location = new System.Drawing.Point(562, 56);
            this.RefreshLog.Name = "RefreshLog";
            this.RefreshLog.Size = new System.Drawing.Size(65, 20);
            this.RefreshLog.TabIndex = 11;
            this.RefreshLog.TabStop = true;
            this.RefreshLog.Text = "刷新数据";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(458, 9);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(169, 38);
            this.BtnSearch.TabIndex = 10;
            this.BtnSearch.Text = "查 询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // DateStart
            // 
            this.DateStart.Enabled = false;
            this.DateStart.Location = new System.Drawing.Point(90, 50);
            this.DateStart.Name = "DateStart";
            this.DateStart.Size = new System.Drawing.Size(126, 26);
            this.DateStart.TabIndex = 2;
            this.DateStart.ValueChanged += new System.EventHandler(this.DateStart_ValueChanged);
            // 
            // DateStop
            // 
            this.DateStop.Enabled = false;
            this.DateStop.Location = new System.Drawing.Point(315, 50);
            this.DateStop.Name = "DateStop";
            this.DateStop.Size = new System.Drawing.Size(126, 26);
            this.DateStop.TabIndex = 8;
            this.DateStop.ValueChanged += new System.EventHandler(this.DateStop_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "结束时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "开始时间：";
            // 
            // ComDayChange
            // 
            this.ComDayChange.FormattingEnabled = true;
            this.ComDayChange.Items.AddRange(new object[] {
            "今日数据",
            "最近三天",
            "最近七天",
            "最近一月",
            "自定义时间"});
            this.ComDayChange.Location = new System.Drawing.Point(315, 10);
            this.ComDayChange.Name = "ComDayChange";
            this.ComDayChange.Size = new System.Drawing.Size(126, 28);
            this.ComDayChange.TabIndex = 5;
            this.ComDayChange.Text = "今日数据";
            this.ComDayChange.SelectedIndexChanged += new System.EventHandler(this.ComDayChange_SelectedIndexChanged);
            // 
            // ComUsername
            // 
            this.ComUsername.FormattingEnabled = true;
            this.ComUsername.Location = new System.Drawing.Point(90, 10);
            this.ComUsername.Name = "ComUsername";
            this.ComUsername.Size = new System.Drawing.Size(126, 28);
            this.ComUsername.TabIndex = 4;
            this.ComUsername.Text = "加载中...";
            this.ComUsername.SelectedIndexChanged += new System.EventHandler(this.ComUsername_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "时间选择：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "用 户 名：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RefreshUser);
            this.tabPage3.Controls.Add(this.BtnNewUser);
            this.tabPage3.Controls.Add(this.PanUserEdit);
            this.tabPage3.Controls.Add(this.DataUserinfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(641, 391);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = " 用户管理 ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RefreshUser
            // 
            this.RefreshUser.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.RefreshUser.AutoSize = true;
            this.RefreshUser.LinkColor = System.Drawing.Color.Gray;
            this.RefreshUser.Location = new System.Drawing.Point(16, 357);
            this.RefreshUser.Name = "RefreshUser";
            this.RefreshUser.Size = new System.Drawing.Size(65, 20);
            this.RefreshUser.TabIndex = 14;
            this.RefreshUser.TabStop = true;
            this.RefreshUser.Text = "刷新数据";
            // 
            // BtnNewUser
            // 
            this.BtnNewUser.Location = new System.Drawing.Point(520, 351);
            this.BtnNewUser.Name = "BtnNewUser";
            this.BtnNewUser.Size = new System.Drawing.Size(106, 32);
            this.BtnNewUser.TabIndex = 13;
            this.BtnNewUser.Text = "新建用户";
            this.BtnNewUser.UseVisualStyleBackColor = true;
            this.BtnNewUser.Click += new System.EventHandler(this.BtnNewUser_Click);
            // 
            // PanUserEdit
            // 
            this.PanUserEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanUserEdit.Controls.Add(this.TxtRePassWord);
            this.PanUserEdit.Controls.Add(this.label10);
            this.PanUserEdit.Controls.Add(this.BtnUser);
            this.PanUserEdit.Controls.Add(this.ComUserRank);
            this.PanUserEdit.Controls.Add(this.label9);
            this.PanUserEdit.Controls.Add(this.TxtPassWord);
            this.PanUserEdit.Controls.Add(this.label8);
            this.PanUserEdit.Controls.Add(this.TxtUserName);
            this.PanUserEdit.Controls.Add(this.label7);
            this.PanUserEdit.Controls.Add(this.btnUserClose);
            this.PanUserEdit.Controls.Add(this.LblUserEdit);
            this.PanUserEdit.Location = new System.Drawing.Point(140, 30);
            this.PanUserEdit.Name = "PanUserEdit";
            this.PanUserEdit.Size = new System.Drawing.Size(362, 287);
            this.PanUserEdit.TabIndex = 11;
            this.PanUserEdit.Visible = false;
            // 
            // TxtRePassWord
            // 
            this.TxtRePassWord.Location = new System.Drawing.Point(134, 139);
            this.TxtRePassWord.Name = "TxtRePassWord";
            this.TxtRePassWord.Size = new System.Drawing.Size(169, 26);
            this.TxtRePassWord.TabIndex = 16;
            this.TxtRePassWord.UseSystemPasswordChar = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "确认密码：";
            // 
            // BtnUser
            // 
            this.BtnUser.Location = new System.Drawing.Point(115, 229);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Size = new System.Drawing.Size(145, 32);
            this.BtnUser.TabIndex = 14;
            this.BtnUser.Text = "确 定";
            this.BtnUser.UseVisualStyleBackColor = true;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // ComUserRank
            // 
            this.ComUserRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComUserRank.FormattingEnabled = true;
            this.ComUserRank.Items.AddRange(new object[] {
            "普通用户",
            "管理员"});
            this.ComUserRank.Location = new System.Drawing.Point(134, 181);
            this.ComUserRank.Name = "ComUserRank";
            this.ComUserRank.Size = new System.Drawing.Size(169, 28);
            this.ComUserRank.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "用户级别：";
            // 
            // TxtPassWord
            // 
            this.TxtPassWord.Location = new System.Drawing.Point(134, 97);
            this.TxtPassWord.Name = "TxtPassWord";
            this.TxtPassWord.Size = new System.Drawing.Size(169, 26);
            this.TxtPassWord.TabIndex = 4;
            this.TxtPassWord.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "用户密码：";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(134, 55);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(169, 26);
            this.TxtUserName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "用户名：";
            // 
            // btnUserClose
            // 
            this.btnUserClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserClose.BackColor = System.Drawing.Color.Transparent;
            this.btnUserClose.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserClose.ForeColor = System.Drawing.Color.Red;
            this.btnUserClose.Location = new System.Drawing.Point(329, 0);
            this.btnUserClose.Name = "btnUserClose";
            this.btnUserClose.Size = new System.Drawing.Size(33, 30);
            this.btnUserClose.TabIndex = 0;
            this.btnUserClose.Text = "×";
            this.btnUserClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUserClose.Click += new System.EventHandler(this.btnUserClose_Click);
            this.btnUserClose.MouseLeave += new System.EventHandler(this.btnUserClose_MouseLeave);
            this.btnUserClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnUserClose_MouseMove);
            // 
            // LblUserEdit
            // 
            this.LblUserEdit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblUserEdit.Location = new System.Drawing.Point(3, 9);
            this.LblUserEdit.Name = "LblUserEdit";
            this.LblUserEdit.Size = new System.Drawing.Size(354, 21);
            this.LblUserEdit.TabIndex = 17;
            this.LblUserEdit.Text = "新建用户";
            this.LblUserEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DataUserinfo
            // 
            this.DataUserinfo.AllowUserToAddRows = false;
            this.DataUserinfo.AllowUserToDeleteRows = false;
            this.DataUserinfo.AllowUserToResizeColumns = false;
            this.DataUserinfo.AllowUserToResizeRows = false;
            this.DataUserinfo.BackgroundColor = System.Drawing.Color.White;
            this.DataUserinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataUserinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DataUserinfo.Location = new System.Drawing.Point(13, 16);
            this.DataUserinfo.Name = "DataUserinfo";
            this.DataUserinfo.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataUserinfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataUserinfo.RowHeadersVisible = false;
            this.DataUserinfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataUserinfo.RowTemplate.Height = 23;
            this.DataUserinfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataUserinfo.Size = new System.Drawing.Size(613, 329);
            this.DataUserinfo.TabIndex = 15;
            this.DataUserinfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataUserinfo_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "username";
            this.dataGridViewTextBoxColumn1.HeaderText = "用户名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 305;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "rank";
            this.dataGridViewTextBoxColumn2.HeaderText = "用户级别";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 305;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.RefreshProcess);
            this.tabPage4.Controls.Add(this.BtnNewProcess);
            this.tabPage4.Controls.Add(this.PanProcessEdit);
            this.tabPage4.Controls.Add(this.DataProcessInfo);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(641, 391);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = " 监控管理 ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // RefreshProcess
            // 
            this.RefreshProcess.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.RefreshProcess.AutoSize = true;
            this.RefreshProcess.LinkColor = System.Drawing.Color.Gray;
            this.RefreshProcess.Location = new System.Drawing.Point(16, 357);
            this.RefreshProcess.Name = "RefreshProcess";
            this.RefreshProcess.Size = new System.Drawing.Size(65, 20);
            this.RefreshProcess.TabIndex = 16;
            this.RefreshProcess.TabStop = true;
            this.RefreshProcess.Text = "刷新数据";
            // 
            // BtnNewProcess
            // 
            this.BtnNewProcess.Location = new System.Drawing.Point(520, 351);
            this.BtnNewProcess.Name = "BtnNewProcess";
            this.BtnNewProcess.Size = new System.Drawing.Size(106, 32);
            this.BtnNewProcess.TabIndex = 15;
            this.BtnNewProcess.Text = "新建监控";
            this.BtnNewProcess.UseVisualStyleBackColor = true;
            this.BtnNewProcess.Click += new System.EventHandler(this.BtnNewProcess_Click);
            // 
            // PanProcessEdit
            // 
            this.PanProcessEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanProcessEdit.Controls.Add(this.label12);
            this.PanProcessEdit.Controls.Add(this.BtnProcess);
            this.PanProcessEdit.Controls.Add(this.ComProcessType);
            this.PanProcessEdit.Controls.Add(this.TxtProcessName);
            this.PanProcessEdit.Controls.Add(this.label14);
            this.PanProcessEdit.Controls.Add(this.TxtSoftName);
            this.PanProcessEdit.Controls.Add(this.label15);
            this.PanProcessEdit.Controls.Add(this.btnProcessClose);
            this.PanProcessEdit.Controls.Add(this.LblProcessEdit);
            this.PanProcessEdit.Location = new System.Drawing.Point(140, 30);
            this.PanProcessEdit.Name = "PanProcessEdit";
            this.PanProcessEdit.Size = new System.Drawing.Size(362, 287);
            this.PanProcessEdit.TabIndex = 14;
            this.PanProcessEdit.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(49, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "进程类型：";
            // 
            // BtnProcess
            // 
            this.BtnProcess.Location = new System.Drawing.Point(115, 229);
            this.BtnProcess.Name = "BtnProcess";
            this.BtnProcess.Size = new System.Drawing.Size(145, 32);
            this.BtnProcess.TabIndex = 14;
            this.BtnProcess.Text = "确 定";
            this.BtnProcess.UseVisualStyleBackColor = true;
            this.BtnProcess.Click += new System.EventHandler(this.BtnProcess_Click);
            // 
            // ComProcessType
            // 
            this.ComProcessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComProcessType.FormattingEnabled = true;
            this.ComProcessType.Items.AddRange(new object[] {
            "EXE",
            "MSI",
            "VBS"});
            this.ComProcessType.Location = new System.Drawing.Point(134, 139);
            this.ComProcessType.Name = "ComProcessType";
            this.ComProcessType.Size = new System.Drawing.Size(169, 28);
            this.ComProcessType.TabIndex = 6;
            // 
            // TxtProcessName
            // 
            this.TxtProcessName.Location = new System.Drawing.Point(134, 97);
            this.TxtProcessName.Name = "TxtProcessName";
            this.TxtProcessName.Size = new System.Drawing.Size(169, 26);
            this.TxtProcessName.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "进程名称：";
            // 
            // TxtSoftName
            // 
            this.TxtSoftName.Enabled = false;
            this.TxtSoftName.Location = new System.Drawing.Point(134, 55);
            this.TxtSoftName.Name = "TxtSoftName";
            this.TxtSoftName.Size = new System.Drawing.Size(169, 26);
            this.TxtSoftName.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(49, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "软件名称：";
            // 
            // btnProcessClose
            // 
            this.btnProcessClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessClose.BackColor = System.Drawing.Color.Transparent;
            this.btnProcessClose.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProcessClose.ForeColor = System.Drawing.Color.Red;
            this.btnProcessClose.Location = new System.Drawing.Point(329, 0);
            this.btnProcessClose.Name = "btnProcessClose";
            this.btnProcessClose.Size = new System.Drawing.Size(33, 30);
            this.btnProcessClose.TabIndex = 0;
            this.btnProcessClose.Text = "×";
            this.btnProcessClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcessClose.Click += new System.EventHandler(this.btnProcessClose_Click);
            this.btnProcessClose.MouseLeave += new System.EventHandler(this.btnProcessClose_MouseLeave);
            this.btnProcessClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcessClose_MouseMove);
            // 
            // LblProcessEdit
            // 
            this.LblProcessEdit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblProcessEdit.Location = new System.Drawing.Point(3, 9);
            this.LblProcessEdit.Name = "LblProcessEdit";
            this.LblProcessEdit.Size = new System.Drawing.Size(354, 21);
            this.LblProcessEdit.TabIndex = 17;
            this.LblProcessEdit.Text = "新建监控";
            this.LblProcessEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DataProcessInfo
            // 
            this.DataProcessInfo.AllowUserToAddRows = false;
            this.DataProcessInfo.AllowUserToDeleteRows = false;
            this.DataProcessInfo.AllowUserToResizeColumns = false;
            this.DataProcessInfo.AllowUserToResizeRows = false;
            this.DataProcessInfo.BackgroundColor = System.Drawing.Color.White;
            this.DataProcessInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataProcessInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.DataProcessInfo.Location = new System.Drawing.Point(13, 16);
            this.DataProcessInfo.Name = "DataProcessInfo";
            this.DataProcessInfo.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataProcessInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataProcessInfo.RowHeadersVisible = false;
            this.DataProcessInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataProcessInfo.RowTemplate.Height = 23;
            this.DataProcessInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataProcessInfo.Size = new System.Drawing.Size(613, 329);
            this.DataProcessInfo.TabIndex = 17;
            this.DataProcessInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataProcessInfo_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.HeaderText = "软件名称";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 203;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "process";
            this.dataGridViewTextBoxColumn4.HeaderText = "进程名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 203;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "type";
            this.dataGridViewTextBoxColumn5.HeaderText = "进程类型";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 204;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(641, 391);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = " 系统设置 ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 424);
            this.Controls.Add(this.TabCont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.TabCont.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataLogInfo)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.PanUserEdit.ResumeLayout(false);
            this.PanUserEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataUserinfo)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.PanProcessEdit.ResumeLayout(false);
            this.PanProcessEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataProcessInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCont;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DateTimePicker DateStart;
        private System.Windows.Forms.DateTimePicker DateStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComDayChange;
        private System.Windows.Forms.ComboBox ComUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.LinkLabel RefreshLog;
        private System.Windows.Forms.Panel PanUserEdit;
        private System.Windows.Forms.Label btnUserClose;
        private System.Windows.Forms.Button BtnNewUser;
        private System.Windows.Forms.TextBox TxtRePassWord;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnUser;
        private System.Windows.Forms.ComboBox ComUserRank;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtPassWord;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblUserEdit;
        private System.Windows.Forms.Panel PanProcessEdit;
        private System.Windows.Forms.Label LblProcessEdit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnProcess;
        private System.Windows.Forms.ComboBox ComProcessType;
        private System.Windows.Forms.TextBox TxtProcessName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtSoftName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label btnProcessClose;
        private System.Windows.Forms.Button BtnNewProcess;
        private System.Windows.Forms.DataGridView DataLogInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.CheckBox CheckUser;
        private System.Windows.Forms.LinkLabel RefreshUser;
        private System.Windows.Forms.LinkLabel RefreshProcess;
        private System.Windows.Forms.DataGridView DataUserinfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView DataProcessInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}

