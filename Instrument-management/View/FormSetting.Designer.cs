namespace InM
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.LinkHandBook = new System.Windows.Forms.LinkLabel();
            this.LblHandBook = new System.Windows.Forms.Label();
            this.LblUpdate = new System.Windows.Forms.Label();
            this.LblSetInerNet = new System.Windows.Forms.Label();
            this.CheckNet = new System.Windows.Forms.CheckBox();
            this.BtnCheckUpdate = new System.Windows.Forms.Button();
            this.TxtSever = new System.Windows.Forms.TextBox();
            this.LblSever = new System.Windows.Forms.Label();
            this.TxtClient = new System.Windows.Forms.TextBox();
            this.LblNetClient = new System.Windows.Forms.Label();
            this.LblPort = new System.Windows.Forms.Label();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.LabPortNotice = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LabIPNotice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LinkHandBook
            // 
            this.LinkHandBook.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.LinkHandBook.AutoSize = true;
            this.LinkHandBook.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LinkHandBook.Location = new System.Drawing.Point(147, 266);
            this.LinkHandBook.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LinkHandBook.Name = "LinkHandBook";
            this.LinkHandBook.Size = new System.Drawing.Size(93, 20);
            this.LinkHandBook.TabIndex = 28;
            this.LinkHandBook.TabStop = true;
            this.LinkHandBook.Text = "查看使用说明";
            // 
            // LblHandBook
            // 
            this.LblHandBook.AutoSize = true;
            this.LblHandBook.Location = new System.Drawing.Point(48, 266);
            this.LblHandBook.Name = "LblHandBook";
            this.LblHandBook.Size = new System.Drawing.Size(79, 20);
            this.LblHandBook.TabIndex = 27;
            this.LblHandBook.Text = "使用说明：";
            // 
            // LblUpdate
            // 
            this.LblUpdate.AutoSize = true;
            this.LblUpdate.Location = new System.Drawing.Point(48, 219);
            this.LblUpdate.Name = "LblUpdate";
            this.LblUpdate.Size = new System.Drawing.Size(79, 20);
            this.LblUpdate.TabIndex = 26;
            this.LblUpdate.Text = "系统更新：";
            // 
            // LblSetInerNet
            // 
            this.LblSetInerNet.AutoSize = true;
            this.LblSetInerNet.Location = new System.Drawing.Point(48, 125);
            this.LblSetInerNet.Name = "LblSetInerNet";
            this.LblSetInerNet.Size = new System.Drawing.Size(93, 20);
            this.LblSetInerNet.TabIndex = 25;
            this.LblSetInerNet.Text = "局域网接口：";
            // 
            // CheckNet
            // 
            this.CheckNet.AutoSize = true;
            this.CheckNet.Checked = true;
            this.CheckNet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckNet.Location = new System.Drawing.Point(146, 77);
            this.CheckNet.Name = "CheckNet";
            this.CheckNet.Size = new System.Drawing.Size(224, 24);
            this.CheckNet.TabIndex = 24;
            this.CheckNet.Text = "局域网仅在公网服务无效时使用";
            this.CheckNet.UseVisualStyleBackColor = true;
            this.CheckNet.CheckedChanged += new System.EventHandler(this.CheckNet_CheckedChanged);
            // 
            // BtnCheckUpdate
            // 
            this.BtnCheckUpdate.Location = new System.Drawing.Point(146, 215);
            this.BtnCheckUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCheckUpdate.Name = "BtnCheckUpdate";
            this.BtnCheckUpdate.Size = new System.Drawing.Size(108, 28);
            this.BtnCheckUpdate.TabIndex = 23;
            this.BtnCheckUpdate.Text = "检查更新";
            this.BtnCheckUpdate.UseVisualStyleBackColor = true;
            // 
            // TxtSever
            // 
            this.TxtSever.Enabled = false;
            this.TxtSever.Location = new System.Drawing.Point(147, 28);
            this.TxtSever.Name = "TxtSever";
            this.TxtSever.Size = new System.Drawing.Size(252, 26);
            this.TxtSever.TabIndex = 22;
            this.TxtSever.Text = "https://api.anycen.com/instrument/";
            // 
            // LblSever
            // 
            this.LblSever.AutoSize = true;
            this.LblSever.Location = new System.Drawing.Point(48, 31);
            this.LblSever.Name = "LblSever";
            this.LblSever.Size = new System.Drawing.Size(79, 20);
            this.LblSever.TabIndex = 21;
            this.LblSever.Text = "服务接口：";
            // 
            // TxtClient
            // 
            this.TxtClient.Location = new System.Drawing.Point(146, 122);
            this.TxtClient.Name = "TxtClient";
            this.TxtClient.Size = new System.Drawing.Size(139, 26);
            this.TxtClient.TabIndex = 30;
            // 
            // LblNetClient
            // 
            this.LblNetClient.AutoSize = true;
            this.LblNetClient.Location = new System.Drawing.Point(48, 78);
            this.LblNetClient.Name = "LblNetClient";
            this.LblNetClient.Size = new System.Drawing.Size(93, 20);
            this.LblNetClient.TabIndex = 29;
            this.LblNetClient.Text = "开启局域网：";
            // 
            // LblPort
            // 
            this.LblPort.AutoSize = true;
            this.LblPort.Location = new System.Drawing.Point(48, 172);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(93, 20);
            this.LblPort.TabIndex = 31;
            this.LblPort.Text = "局域网端口：";
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(147, 169);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(65, 26);
            this.TxtPort.TabIndex = 32;
            this.TxtPort.TextChanged += new System.EventHandler(this.TxtPort_TextChanged);
            // 
            // LabPortNotice
            // 
            this.LabPortNotice.AutoSize = true;
            this.LabPortNotice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabPortNotice.ForeColor = System.Drawing.Color.Red;
            this.LabPortNotice.Location = new System.Drawing.Point(218, 175);
            this.LabPortNotice.Name = "LabPortNotice";
            this.LabPortNotice.Size = new System.Drawing.Size(144, 17);
            this.LabPortNotice.TabIndex = 34;
            this.LabPortNotice.Text = "输入的端口号请大于8000";
            this.LabPortNotice.Visible = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(151, 314);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(157, 42);
            this.BtnSave.TabIndex = 36;
            this.BtnSave.Text = "保存设置";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LabIPNotice
            // 
            this.LabIPNotice.AutoSize = true;
            this.LabIPNotice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabIPNotice.ForeColor = System.Drawing.Color.Gray;
            this.LabIPNotice.Location = new System.Drawing.Point(294, 128);
            this.LabIPNotice.Name = "LabIPNotice";
            this.LabIPNotice.Size = new System.Drawing.Size(115, 17);
            this.LabIPNotice.TabIndex = 35;
            this.LabIPNotice.Text = "请输入管理端IP地址";
            this.LabIPNotice.Visible = false;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 384);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LabIPNotice);
            this.Controls.Add(this.LabPortNotice);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.LblPort);
            this.Controls.Add(this.TxtClient);
            this.Controls.Add(this.LblNetClient);
            this.Controls.Add(this.LinkHandBook);
            this.Controls.Add(this.LblHandBook);
            this.Controls.Add(this.LblUpdate);
            this.Controls.Add(this.LblSetInerNet);
            this.Controls.Add(this.CheckNet);
            this.Controls.Add(this.BtnCheckUpdate);
            this.Controls.Add(this.TxtSever);
            this.Controls.Add(this.LblSever);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仪器管理系统-客户端设置";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel LinkHandBook;
        private System.Windows.Forms.Label LblHandBook;
        private System.Windows.Forms.Label LblUpdate;
        private System.Windows.Forms.Label LblSetInerNet;
        private System.Windows.Forms.CheckBox CheckNet;
        private System.Windows.Forms.Button BtnCheckUpdate;
        private System.Windows.Forms.TextBox TxtSever;
        private System.Windows.Forms.Label LblSever;
        private System.Windows.Forms.TextBox TxtClient;
        private System.Windows.Forms.Label LblNetClient;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Label LabPortNotice;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LabIPNotice;
    }
}