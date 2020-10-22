namespace RTFSample
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
            this.components = new System.ComponentModel.Container();
            this.listLabel1 = new combit.Reporting.ListLabel(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.listLabelRTFControl1 = new combit.Reporting.ListLabelRTFControl(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listLabel1
            // 
            this.listLabel1.AutoPrinterSettingsStream = null;
            this.listLabel1.AutoProjectStream = null;
            this.listLabel1.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad;
            this.listLabel1.DrilldownAvailable = true;
            this.listLabel1.EMFResolution = 100;
            this.listLabel1.FileRepository = null;
            this.listLabel1.GenericMaximumRecordCount = -1;
            this.listLabel1.LockNextChar = 8288;
            this.listLabel1.MaxRTFVersion = 1280;
            this.listLabel1.PhantomSpace = 8203;
            this.listLabel1.PreviewControl = null;
            this.listLabel1.Unit = combit.Reporting.LlUnits.Millimeter_1_100;
            this.listLabel1.UseHardwareCopiesForLabels = false;
            this.listLabel1.UseTableSchemaForDesignMode = false;
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "*.RTF";
            this.ofd.Filter = "RTF Files|*.RTF";
            this.ofd.Title = "Select RTF File";
            // 
            // listLabelRTFControl1
            // 
            this.listLabelRTFControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listLabelRTFControl1.Location = new System.Drawing.Point(32, 47);
            this.listLabelRTFControl1.Name = "listLabelRTFControl1";
            this.listLabelRTFControl1.ParentComponent = this.listLabel1;
            this.listLabelRTFControl1.Size = new System.Drawing.Size(635, 307);
            this.listLabelRTFControl1.TabIndex = 1;
            this.listLabelRTFControl1.Text = "listLabelRTFControl1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open RTF File...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(441, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Design...";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(557, 360);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Print...";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(694, 401);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listLabelRTFControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(710, 440);
            this.Name = "Form1";
            this.Text = "List & Label C# RTF Control Sample";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.OpenFileDialog ofd;
        private combit.Reporting.ListLabelRTFControl listLabelRTFControl1;
        private combit.Reporting.ListLabel listLabel1;
        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
