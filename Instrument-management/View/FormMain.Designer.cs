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
            this.PlanLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.panelForm.SuspendLayout();
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
            this.panelForm.Controls.Add(this.PlanLoad);
            this.panelForm.Controls.Add(this.picBack);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Margin = new System.Windows.Forms.Padding(2);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(960, 576);
            this.panelForm.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 576);
            this.Controls.Add(this.panelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "屏幕锁定";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.formMain_Load);
            this.PlanLoad.ResumeLayout(false);
            this.PlanLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.panelForm.ResumeLayout(false);
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
    }
}

