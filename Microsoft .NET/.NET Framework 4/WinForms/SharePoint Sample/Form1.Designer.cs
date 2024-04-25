namespace SharePointSample
{
    partial class Form1
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
            System.Windows.Forms.Label lblServer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.Label lblDocBib;
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkOverwriteFile = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblFormat = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.comboBoxBib = new System.Windows.Forms.ComboBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            lblServer = new System.Windows.Forms.Label();
            lblDocBib = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            resources.ApplyResources(lblServer, "lblServer");
            lblServer.Name = "lblServer";
            // 
            // lblDocBib
            // 
            resources.ApplyResources(lblDocBib, "lblDocBib");
            lblDocBib.Name = "lblDocBib";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // chkOverwriteFile
            // 
            resources.ApplyResources(this.chkOverwriteFile, "chkOverwriteFile");
            this.chkOverwriteFile.Name = "chkOverwriteFile";
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // lblFileName
            // 
            resources.ApplyResources(this.lblFileName, "lblFileName");
            this.lblFileName.Name = "lblFileName";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxFormat, "comboBoxFormat");
            this.comboBoxFormat.Items.AddRange(new object[] {
            resources.GetString("comboBoxFormat.Items"),
            resources.GetString("comboBoxFormat.Items1"),
            resources.GetString("comboBoxFormat.Items2"),
            resources.GetString("comboBoxFormat.Items3"),
            resources.GetString("comboBoxFormat.Items4")});
            this.comboBoxFormat.Name = "comboBoxFormat";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.Name = "txtFileName";
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // lblFormat
            // 
            resources.ApplyResources(this.lblFormat, "lblFormat");
            this.lblFormat.Name = "lblFormat";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOverwriteFile);
            this.groupBox2.Controls.Add(this.lblFileName);
            this.groupBox2.Controls.Add(this.comboBoxFormat);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.lblFormat);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblName);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // comboBoxBib
            // 
            this.comboBoxBib.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxBib, "comboBoxBib");
            this.comboBoxBib.Name = "comboBoxBib";
            this.comboBoxBib.DropDown += new System.EventHandler(this.ComboBoxBib_DropDown);
            this.comboBoxBib.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBib_SelectedIndexChanged);
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtServer, "txtServer");
            this.txtServer.Name = "txtServer";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel2);
            this.Controls.Add(lblServer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(lblDocBib);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxBib);
            this.Controls.Add(this.txtServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkOverwriteFile;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox comboBoxBib;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}
