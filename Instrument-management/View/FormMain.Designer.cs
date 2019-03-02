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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxUserpwd = new System.Windows.Forms.TextBox();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.PlanLoad = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.PlanLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // TimKill
            // 
            this.TimKill.Enabled = true;
            this.TimKill.Tick += new System.EventHandler(this.TimKill_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "禁用任务管理器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 82);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(218, 51);
            this.button2.TabIndex = 1;
            this.button2.Text = "启用任务管理器";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.ForeColor = System.Drawing.Color.Silver;
            this.textBoxUsername.Location = new System.Drawing.Point(40, 82);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(464, 44);
            this.textBoxUsername.TabIndex = 4;
            this.textBoxUsername.Text = "请输入用户名";
            this.textBoxUsername.Enter += new System.EventHandler(this.textBoxUsername_Enter);
            this.textBoxUsername.Leave += new System.EventHandler(this.textBoxUsername_Leave);
            // 
            // textBoxUserpwd
            // 
            this.textBoxUserpwd.ForeColor = System.Drawing.Color.Silver;
            this.textBoxUserpwd.Location = new System.Drawing.Point(40, 152);
            this.textBoxUserpwd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBoxUserpwd.Name = "textBoxUserpwd";
            this.textBoxUserpwd.Size = new System.Drawing.Size(464, 44);
            this.textBoxUserpwd.TabIndex = 5;
            this.textBoxUserpwd.Text = "请输入密码";
            this.textBoxUserpwd.Enter += new System.EventHandler(this.textBoxUserpwd_Enter);
            this.textBoxUserpwd.Leave += new System.EventHandler(this.textBoxUserpwd_Leave);
            // 
            // btnShutdown
            // 
            this.btnShutdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShutdown.Location = new System.Drawing.Point(22, 794);
            this.btnShutdown.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(94, 60);
            this.btnShutdown.TabIndex = 7;
            this.btnShutdown.Text = "关闭";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // PlanLoad
            // 
            this.PlanLoad.BackColor = System.Drawing.SystemColors.Control;
            this.PlanLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlanLoad.Controls.Add(this.label1);
            this.PlanLoad.Controls.Add(this.buttonLogin);
            this.PlanLoad.Controls.Add(this.textBoxUsername);
            this.PlanLoad.Controls.Add(this.textBoxUserpwd);
            this.PlanLoad.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlanLoad.Location = new System.Drawing.Point(825, 271);
            this.PlanLoad.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.PlanLoad.Name = "PlanLoad";
            this.PlanLoad.Size = new System.Drawing.Size(548, 342);
            this.PlanLoad.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "请先登录";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(152, 245);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(240, 66);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "登录";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // picBack
            // 
            this.picBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBack.Image = ((System.Drawing.Image)(resources.GetObject("picBack.Image")));
            this.picBack.Location = new System.Drawing.Point(0, 0);
            this.picBack.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(1833, 875);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBack.TabIndex = 9;
            this.picBack.TabStop = false;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1833, 875);
            this.Controls.Add(this.PlanLoad);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormMain";
            this.Text = "屏幕锁定";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.PlanLoad.ResumeLayout(false);
            this.PlanLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer TimKill;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxUserpwd;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Panel PlanLoad;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLogin;
    }
}

