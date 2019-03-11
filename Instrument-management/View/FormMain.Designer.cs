namespace InM
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.TimKill = new System.Windows.Forms.Timer(this.components);
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxUserpwd = new System.Windows.Forms.TextBox();
            this.PlanLoad = new System.Windows.Forms.Panel();
            this.LinkRefreshData = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.panelForm = new System.Windows.Forms.Panel();
            this.BtnShutDown = new System.Windows.Forms.Button();
            this.PanReg = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnReg = new System.Windows.Forms.Button();
            this.btnUserClose = new System.Windows.Forms.Label();
            this.PlanLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.panelForm.SuspendLayout();
            this.PanReg.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimKill
            // 
            this.TimKill.Enabled = true;
            this.TimKill.Tick += new System.EventHandler(this.TimKill_Tick);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.ForeColor = System.Drawing.Color.Silver;
            this.textBoxUsername.Location = new System.Drawing.Point(22, 55);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(255, 29);
            this.textBoxUsername.TabIndex = 4;
            this.textBoxUsername.Text = "请输入用户名";
            this.textBoxUsername.Enter += new System.EventHandler(this.textBoxUsername_Enter);
            this.textBoxUsername.Leave += new System.EventHandler(this.textBoxUsername_Leave);
            // 
            // textBoxUserpwd
            // 
            this.textBoxUserpwd.ForeColor = System.Drawing.Color.Silver;
            this.textBoxUserpwd.Location = new System.Drawing.Point(22, 96);
            this.textBoxUserpwd.Name = "textBoxUserpwd";
            this.textBoxUserpwd.Size = new System.Drawing.Size(255, 29);
            this.textBoxUserpwd.TabIndex = 5;
            this.textBoxUserpwd.Text = "请输入密码";
            this.textBoxUserpwd.Enter += new System.EventHandler(this.textBoxUserpwd_Enter);
            this.textBoxUserpwd.Leave += new System.EventHandler(this.textBoxUserpwd_Leave);
            // 
            // PlanLoad
            // 
            this.PlanLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlanLoad.BackColor = System.Drawing.SystemColors.Control;
            this.PlanLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlanLoad.Controls.Add(this.LinkRefreshData);
            this.PlanLoad.Controls.Add(this.label1);
            this.PlanLoad.Controls.Add(this.buttonLogin);
            this.PlanLoad.Controls.Add(this.textBoxUsername);
            this.PlanLoad.Controls.Add(this.textBoxUserpwd);
            this.PlanLoad.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlanLoad.Location = new System.Drawing.Point(359, 185);
            this.PlanLoad.Margin = new System.Windows.Forms.Padding(0);
            this.PlanLoad.Name = "PlanLoad";
            this.PlanLoad.Size = new System.Drawing.Size(298, 206);
            this.PlanLoad.TabIndex = 8;
            // 
            // LinkRefreshData
            // 
            this.LinkRefreshData.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.LinkRefreshData.AutoSize = true;
            this.LinkRefreshData.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkRefreshData.LinkColor = System.Drawing.Color.Gray;
            this.LinkRefreshData.Location = new System.Drawing.Point(22, 150);
            this.LinkRefreshData.Name = "LinkRefreshData";
            this.LinkRefreshData.Size = new System.Drawing.Size(93, 20);
            this.LinkRefreshData.TabIndex = 13;
            this.LinkRefreshData.TabStop = true;
            this.LinkRefreshData.Text = "刷新本地数据";
            this.LinkRefreshData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkRefreshData_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "请先登录";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(140, 141);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(131, 36);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "登 录";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // picBack
            // 
            this.picBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBack.Image = ((System.Drawing.Image)(resources.GetObject("picBack.Image")));
            this.picBack.Location = new System.Drawing.Point(0, 0);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(960, 576);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBack.TabIndex = 9;
            this.picBack.TabStop = false;
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.BtnReg);
            this.panelForm.Controls.Add(this.PanReg);
            this.panelForm.Controls.Add(this.BtnShutDown);
            this.panelForm.Controls.Add(this.PlanLoad);
            this.panelForm.Controls.Add(this.picBack);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Margin = new System.Windows.Forms.Padding(2);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(960, 576);
            this.panelForm.TabIndex = 10;
            // 
            // BtnShutDown
            // 
            this.BtnShutDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnShutDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnShutDown.Location = new System.Drawing.Point(89, 538);
            this.BtnShutDown.Name = "BtnShutDown";
            this.BtnShutDown.Size = new System.Drawing.Size(58, 26);
            this.BtnShutDown.TabIndex = 10;
            this.BtnShutDown.Text = "关机";
            this.BtnShutDown.UseVisualStyleBackColor = true;
            this.BtnShutDown.Click += new System.EventHandler(this.BtnShutDown_Click);
            // 
            // PanReg
            // 
            this.PanReg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PanReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanReg.Controls.Add(this.btnUserClose);
            this.PanReg.Controls.Add(this.webBrowser1);
            this.PanReg.Controls.Add(this.label2);
            this.PanReg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PanReg.Location = new System.Drawing.Point(348, 169);
            this.PanReg.Name = "PanReg";
            this.PanReg.Size = new System.Drawing.Size(326, 269);
            this.PanReg.TabIndex = 11;
            this.PanReg.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "注册新用户";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(51, 50);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(220, 193);
            this.webBrowser1.TabIndex = 9;
            this.webBrowser1.Url = new System.Uri("https://api.anycen.com/instrument/reg.html", System.UriKind.Absolute);
            // 
            // BtnReg
            // 
            this.BtnReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnReg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnReg.Location = new System.Drawing.Point(12, 538);
            this.BtnReg.Name = "BtnReg";
            this.BtnReg.Size = new System.Drawing.Size(71, 26);
            this.BtnReg.TabIndex = 12;
            this.BtnReg.Text = "用户注册";
            this.BtnReg.UseVisualStyleBackColor = true;
            this.BtnReg.Click += new System.EventHandler(this.BtnReg_Click);
            // 
            // btnUserClose
            // 
            this.btnUserClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserClose.BackColor = System.Drawing.Color.Transparent;
            this.btnUserClose.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserClose.ForeColor = System.Drawing.Color.Red;
            this.btnUserClose.Location = new System.Drawing.Point(292, 0);
            this.btnUserClose.Name = "btnUserClose";
            this.btnUserClose.Size = new System.Drawing.Size(33, 30);
            this.btnUserClose.TabIndex = 10;
            this.btnUserClose.Text = "×";
            this.btnUserClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUserClose.Click += new System.EventHandler(this.btnUserClose_Click);
            this.btnUserClose.MouseLeave += new System.EventHandler(this.btnUserClose_MouseLeave);
            this.btnUserClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnUserClose_MouseMove);
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(960, 576);
            this.Controls.Add(this.panelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "屏幕锁定";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMain_Load);
            this.PlanLoad.ResumeLayout(false);
            this.PlanLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.PanReg.ResumeLayout(false);
            this.PanReg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer TimKill;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxUserpwd;
        private System.Windows.Forms.Panel PlanLoad;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.LinkLabel LinkRefreshData;
        private System.Windows.Forms.Button BtnShutDown;
        private System.Windows.Forms.Panel PanReg;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnReg;
        private System.Windows.Forms.Label btnUserClose;
    }
}

