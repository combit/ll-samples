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
            this.listLabel1 = new combit.ListLabel24.ListLabel(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.listLabelRTFControl1 = new combit.ListLabel24.ListLabelRTFControl(this.components);
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // listLabel1
            // 
            this.listLabel1.AutoPrinterSettingsStream = null;
            this.listLabel1.AutoProjectStream = null;
            this.listLabel1.DrilldownAvailable = true;
            this.listLabel1.EMFResolution = 100;
            this.listLabel1.LockNextChar = 8288;
            this.listLabel1.MaxRTFVersion = 1280;
            this.listLabel1.PhantomSpace = 8203;
            this.listLabel1.PreviewControl = null;
            this.listLabel1.Unit = combit.ListLabel24.LlUnits.Millimeter_1_100;
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
            this.listLabelRTFControl1.Location = new System.Drawing.Point(32, 102);
            this.listLabelRTFControl1.Name = "listLabelRTFControl1";
            this.listLabelRTFControl1.ParentComponent = this.listLabel1;
            this.listLabelRTFControl1.Size = new System.Drawing.Size(655, 274);
            this.listLabelRTFControl1.TabIndex = 1;
            this.listLabelRTFControl1.Text = "listLabelRTFControl1";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(32, 73);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(110, 23);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Open RTF File...";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.Location = new System.Drawing.Point(461, 382);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(110, 23);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Design...";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.MetroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.Location = new System.Drawing.Point(577, 382);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(110, 23);
            this.metroButton3.TabIndex = 4;
            this.metroButton3.Text = "Print...";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.MetroButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(710, 440);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.listLabelRTFControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(710, 440);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# RTF Control Sample";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.OpenFileDialog ofd;
        private combit.ListLabel24.ListLabelRTFControl listLabelRTFControl1;
        private combit.ListLabel24.ListLabel listLabel1;

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}
