namespace Export
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
            this._showFileCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.fileNameTb = new MetroFramework.Controls.MetroTextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.formatCb = new MetroFramework.Controls.MetroComboBox();
            this.createButton = new MetroFramework.Controls.MetroButton();
            this.selectButton = new MetroFramework.Controls.MetroButton();
            this.LL = new combit.ListLabel24.ListLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _showFileCheck
            // 
            this._showFileCheck.Location = new System.Drawing.Point(258, 80);
            this._showFileCheck.Name = "_showFileCheck";
            this._showFileCheck.Size = new System.Drawing.Size(138, 24);
            this._showFileCheck.TabIndex = 10;
            this._showFileCheck.Text = "Show file after creation";
            // 
            // label1
            // 
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(23, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "US:";
            // 
            // label5
            // 
            this.label5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(23, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "D:";
            // 
            // label4
            // 
            this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(47, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "This sample shows an export without user interaction.";
            // 
            // label3
            // 
            this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(47, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dieses Beispiel zeigt den Export ohne weitere Benutzerinteraktion.";
            // 
            // label2
            // 
            this.label2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Format:";
            // 
            // label6
            // 
            this.label6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Filename:";
            // 
            // fileNameTb
            // 
            this.fileNameTb.BackColor = System.Drawing.SystemColors.Window;
            this.fileNameTb.Lines = new string[0];
            this.fileNameTb.Location = new System.Drawing.Point(69, 50);
            this.fileNameTb.MaxLength = 32767;
            this.fileNameTb.Name = "fileNameTb";
            this.fileNameTb.PasswordChar = '\0';
            this.fileNameTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.fileNameTb.SelectedText = "";
            this.fileNameTb.Size = new System.Drawing.Size(327, 24);
            this.fileNameTb.TabIndex = 7;
            this.fileNameTb.UseCustomBackColor = true;
            this.fileNameTb.UseSelectable = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "doc1";
            // 
            // formatCb
            // 
            this.formatCb.DropDownHeight = 160;
            this.formatCb.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.formatCb.IntegralHeight = false;
            this.formatCb.ItemHeight = 19;
            this.formatCb.Items.AddRange(new object[] {
            "PDF",
            "MHTML",
            "HTML",
            "RTF",
            "XML",
            "Multi-TIFF",
            "Text",
            "XLS",
            "XLSX",
            "XHTML",
            "Preview",
            "DOCX"});
            this.formatCb.Location = new System.Drawing.Point(69, 19);
            this.formatCb.Name = "formatCb";
            this.formatCb.Size = new System.Drawing.Size(327, 25);
            this.formatCb.Style = MetroFramework.MetroColorStyle.Blue;
            this.formatCb.TabIndex = 5;
            this.formatCb.UseSelectable = true;
            this.formatCb.SelectedValueChanged += new System.EventHandler(this.FormatCombo_SelectedValueChanged);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(402, 80);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(80, 24);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create...";
            this.createButton.UseSelectable = true;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(402, 50);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(80, 24);
            this.selectButton.TabIndex = 8;
            this.selectButton.Text = "Select...";
            this.selectButton.UseSelectable = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // LL
            // 
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.AutoShowSelectFile = false;
            this.LL.CompressStorage = true;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 256;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.ListLabel24.LlUnits.Inch_1_1000;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.formatCb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.createButton);
            this.groupBox1.Controls.Add(this._showFileCheck);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.selectButton);
            this.groupBox1.Controls.Add(this.fileNameTb);
            this.groupBox1.Location = new System.Drawing.Point(27, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 117);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(545, 245);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# Export Sample";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Controls.MetroTextBox fileNameTb;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private MetroFramework.Controls.MetroComboBox formatCb;
        private MetroFramework.Controls.MetroButton createButton;
        private MetroFramework.Controls.MetroButton selectButton;
        private combit.ListLabel24.ListLabel LL;

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
