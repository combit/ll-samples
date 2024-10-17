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
            components = new System.ComponentModel.Container();
            _showFileCheck = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            fileNameTb = new System.Windows.Forms.TextBox();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            formatCb = new System.Windows.Forms.ComboBox();
            createButton = new System.Windows.Forms.Button();
            selectButton = new System.Windows.Forms.Button();
            LL = new combit.Reporting.ListLabel(components);
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // _showFileCheck
            // 
            _showFileCheck.Location = new System.Drawing.Point(291, 92);
            _showFileCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _showFileCheck.Name = "_showFileCheck";
            _showFileCheck.Size = new System.Drawing.Size(171, 28);
            _showFileCheck.TabIndex = 10;
            _showFileCheck.Text = "Show file after creation";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(27, 50);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(28, 18);
            label1.TabIndex = 2;
            label1.Text = "US:";
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(27, 22);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(21, 18);
            label5.TabIndex = 0;
            label5.Text = "D:";
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(55, 50);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(336, 28);
            label4.TabIndex = 3;
            label4.Text = "This sample shows an export without user interaction.";
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(55, 22);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(392, 28);
            label3.TabIndex = 1;
            label3.Text = "Dieses Beispiel zeigt den Export ohne weitere Benutzerinteraktion.";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(7, 27);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 18);
            label2.TabIndex = 4;
            label2.Text = "Format:";
            // 
            // label6
            // 
            label6.Location = new System.Drawing.Point(7, 60);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(66, 18);
            label6.TabIndex = 6;
            label6.Text = "Filename:";
            // 
            // fileNameTb
            // 
            fileNameTb.BackColor = System.Drawing.SystemColors.Window;
            fileNameTb.Location = new System.Drawing.Point(80, 58);
            fileNameTb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fileNameTb.Name = "fileNameTb";
            fileNameTb.Size = new System.Drawing.Size(381, 23);
            fileNameTb.TabIndex = 7;
            // 
            // saveFileDialog
            // 
            saveFileDialog.FileName = "doc1";
            // 
            // formatCb
            // 
            formatCb.DropDownHeight = 160;
            formatCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            formatCb.IntegralHeight = false;
            formatCb.ItemHeight = 15;
            formatCb.Items.AddRange(new object[] { "PDF", "MHTML", "RTF", "XML", "Multi-TIFF", "Text", "XLS", "XLSX", "XHTML", "Preview", "DOCX" });
            formatCb.Location = new System.Drawing.Point(80, 22);
            formatCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            formatCb.Name = "formatCb";
            formatCb.Size = new System.Drawing.Size(381, 23);
            formatCb.TabIndex = 5;
            formatCb.SelectedValueChanged += FormatCombo_SelectedValueChanged;
            // 
            // createButton
            // 
            createButton.Location = new System.Drawing.Point(469, 92);
            createButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            createButton.Name = "createButton";
            createButton.Size = new System.Drawing.Size(93, 28);
            createButton.TabIndex = 9;
            createButton.Text = "Create...";
            createButton.Click += CreateButton_Click;
            // 
            // selectButton
            // 
            selectButton.Location = new System.Drawing.Point(469, 58);
            selectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            selectButton.Name = "selectButton";
            selectButton.Size = new System.Drawing.Size(93, 28);
            selectButton.TabIndex = 8;
            selectButton.Text = "Select...";
            selectButton.Click += SelectButton_Click;
            // 
            // LL
            // 
            LL.AutoPrinterSettingsStream = null;
            LL.AutoProjectStream = null;
            LL.AutoShowSelectFile = false;
            LL.CompressStorage = true;
            LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad;
            LL.DrilldownAvailable = true;
            LL.EMFResolution = 100;
            LL.FileRepository = null;
            LL.GenericMaximumRecordCount = -1;
            LL.LockNextChar = 8288;
            LL.MaxRTFVersion = 256;
            LL.PhantomSpace = 8203;
            LL.PreviewControl = null;
            LL.Printerless = false;
            LL.Unit = combit.Reporting.LlUnits.Inch_1_1000;
            LL.UseHardwareCopiesForLabels = false;
            LL.UseTableSchemaForDesignMode = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(formatCb);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(createButton);
            groupBox1.Controls.Add(_showFileCheck);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(selectButton);
            groupBox1.Controls.Add(fileNameTb);
            groupBox1.Location = new System.Drawing.Point(31, 81);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(569, 135);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(630, 237);
            Controls.Add(label5);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label4);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "List & Label Export Sample";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fileNameTb;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox formatCb;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button selectButton;
        private combit.Reporting.ListLabel LL;
        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
