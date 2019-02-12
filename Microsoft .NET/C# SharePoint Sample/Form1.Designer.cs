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
            MetroFramework.Controls.MetroLabel lblServer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MetroFramework.Controls.MetroLabel lblDocBib;
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.chkOverwriteFile = new MetroFramework.Controls.MetroCheckBox();
            this.lblInfo = new MetroFramework.Controls.MetroLabel();
            this.lblFileName = new MetroFramework.Controls.MetroLabel();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxFormat = new MetroFramework.Controls.MetroComboBox();
            this.txtFileName = new MetroFramework.Controls.MetroTextBox();
            this.btnExport = new MetroFramework.Controls.MetroButton();
            this.lblFormat = new MetroFramework.Controls.MetroLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new MetroFramework.Controls.MetroButton();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.comboBoxBib = new MetroFramework.Controls.MetroComboBox();
            this.txtServer = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.panel2 = new MetroFramework.Controls.MetroPanel();
            this.button1 = new MetroFramework.Controls.MetroButton();
            lblServer = new MetroFramework.Controls.MetroLabel();
            lblDocBib = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.FontSize = MetroFramework.MetroLabelSize.Small;
            resources.ApplyResources(lblServer, "lblServer");
            lblServer.Name = "lblServer";
            // 
            // lblDocBib
            // 
            lblDocBib.FontSize = MetroFramework.MetroLabelSize.Small;
            resources.ApplyResources(lblDocBib, "lblDocBib");
            lblDocBib.Name = "lblDocBib";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Lines = new string[0];
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.UseCustomBackColor = true;
            this.txtName.UseSelectable = true;
            // 
            // chkOverwriteFile
            // 
            resources.ApplyResources(this.chkOverwriteFile, "chkOverwriteFile");
            this.chkOverwriteFile.Name = "chkOverwriteFile";
            this.chkOverwriteFile.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkOverwriteFile.UseSelectable = true;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.FontSize = MetroFramework.MetroLabelSize.Small;
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // lblFileName
            // 
            this.lblFileName.FontSize = MetroFramework.MetroLabelSize.Small;
            resources.ApplyResources(this.lblFileName, "lblFileName");
            this.lblFileName.Name = "lblFileName";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Lines = new string[0];
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.UseCustomBackColor = true;
            this.txtPassword.UseSelectable = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.HorizontalScrollbarBarColor = true;
            this.panel1.HorizontalScrollbarHighlightOnWheel = false;
            this.panel1.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.VerticalScrollbarBarColor = true;
            this.panel1.VerticalScrollbarHighlightOnWheel = false;
            this.panel1.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxFormat.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxFormat, "comboBoxFormat");
            this.comboBoxFormat.Items.AddRange(new object[] {
            resources.GetString("comboBoxFormat.Items"),
            resources.GetString("comboBoxFormat.Items1"),
            resources.GetString("comboBoxFormat.Items2"),
            resources.GetString("comboBoxFormat.Items3"),
            resources.GetString("comboBoxFormat.Items4")});
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboBoxFormat.UseSelectable = true;
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            this.txtFileName.Lines = new string[0];
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.MaxLength = 32767;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PasswordChar = '\0';
            this.txtFileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFileName.SelectedText = "";
            this.txtFileName.UseCustomBackColor = true;
            this.txtFileName.UseSelectable = true;
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.UseSelectable = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // lblFormat
            // 
            this.lblFormat.FontSize = MetroFramework.MetroLabelSize.Small;
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
            this.btnRefresh.UseSelectable = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // lblName
            // 
            this.lblName.FontSize = MetroFramework.MetroLabelSize.Small;
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
            this.lblPassword.FontSize = MetroFramework.MetroLabelSize.Small;
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // comboBoxBib
            // 
            this.comboBoxBib.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxBib.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxBib, "comboBoxBib");
            this.comboBoxBib.Name = "comboBoxBib";
            this.comboBoxBib.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboBoxBib.UseSelectable = true;
            this.comboBoxBib.DropDown += new System.EventHandler(this.ComboBoxBib_DropDown);
            this.comboBoxBib.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBib_SelectedIndexChanged);
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.Color.White;
            this.txtServer.Lines = new string[0];
            resources.ApplyResources(this.txtServer, "txtServer");
            this.txtServer.MaxLength = 32767;
            this.txtServer.Name = "txtServer";
            this.txtServer.PasswordChar = '\0';
            this.txtServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtServer.SelectedText = "";
            this.txtServer.UseCustomBackColor = true;
            this.txtServer.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.WrapToLine = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.HorizontalScrollbarBarColor = true;
            this.panel2.HorizontalScrollbarHighlightOnWheel = false;
            this.panel2.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            this.panel2.VerticalScrollbarBarColor = true;
            this.panel2.VerticalScrollbarHighlightOnWheel = false;
            this.panel2.VerticalScrollbarSize = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.TabStop = false;
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtName;
        private MetroFramework.Controls.MetroCheckBox chkOverwriteFile;
        private MetroFramework.Controls.MetroLabel lblInfo;
        private MetroFramework.Controls.MetroLabel lblFileName;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroPanel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroComboBox comboBoxFormat;
        private MetroFramework.Controls.MetroTextBox txtFileName;
        private MetroFramework.Controls.MetroButton btnExport;
        private MetroFramework.Controls.MetroLabel lblFormat;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton btnRefresh;
        private MetroFramework.Controls.MetroLabel lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroComboBox comboBoxBib;
        private MetroFramework.Controls.MetroTextBox txtServer;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroPanel panel2;
        private MetroFramework.Controls.MetroButton button1;

    }
}

