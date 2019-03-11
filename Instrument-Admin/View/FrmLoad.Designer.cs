namespace InM_Admin
{
    partial class FrmLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoad));
            this.TxtUserword = new System.Windows.Forms.TextBox();
            this.LblUser = new System.Windows.Forms.Label();
            this.LblPass = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.LinkForgetPass = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // TxtUserword
            // 
            this.TxtUserword.Location = new System.Drawing.Point(78, 33);
            this.TxtUserword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtUserword.Name = "TxtUserword";
            this.TxtUserword.Size = new System.Drawing.Size(180, 26);
            this.TxtUserword.TabIndex = 1;
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(19, 36);
            this.LblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(51, 20);
            this.LblUser.TabIndex = 2;
            this.LblUser.Text = "用户：";
            // 
            // LblPass
            // 
            this.LblPass.AutoSize = true;
            this.LblPass.Location = new System.Drawing.Point(19, 77);
            this.LblPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPass.Name = "LblPass";
            this.LblPass.Size = new System.Drawing.Size(51, 20);
            this.LblPass.TabIndex = 4;
            this.LblPass.Text = "密码：";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(78, 74);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(180, 26);
            this.TxtPassword.TabIndex = 3;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(131, 123);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(118, 34);
            this.BtnLoad.TabIndex = 5;
            this.BtnLoad.Text = "登 录";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // LinkForgetPass
            // 
            this.LinkForgetPass.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.LinkForgetPass.AutoSize = true;
            this.LinkForgetPass.LinkColor = System.Drawing.Color.Gray;
            this.LinkForgetPass.Location = new System.Drawing.Point(27, 132);
            this.LinkForgetPass.Name = "LinkForgetPass";
            this.LinkForgetPass.Size = new System.Drawing.Size(65, 20);
            this.LinkForgetPass.TabIndex = 6;
            this.LinkForgetPass.TabStop = true;
            this.LinkForgetPass.Text = "忘记密码";
            this.LinkForgetPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkForgetPass_LinkClicked);
            // 
            // FrmLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(278, 184);
            this.Controls.Add(this.LinkForgetPass);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.LblPass);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.LblUser);
            this.Controls.Add(this.TxtUserword);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLoad_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtUserword;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label LblPass;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.LinkLabel LinkForgetPass;
    }
}