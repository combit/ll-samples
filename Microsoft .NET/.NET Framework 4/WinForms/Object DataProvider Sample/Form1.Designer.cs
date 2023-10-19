namespace combit.Reporting.CSharpSample.ObjectDataProviderSample
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
            this.LL = new combit.Reporting.ListLabel(this.components);
            this.buttonDesign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_DE = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_US = new System.Windows.Forms.Label();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.comboSelection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LL
            // 
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.CompressStorage = true;
            this.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.FileRepository = null;
            this.LL.GenericMaximumRecordCount = -1;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_100;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // buttonDesign
            // 
            this.buttonDesign.Location = new System.Drawing.Point(251, 105);
            this.buttonDesign.Name = "buttonDesign";
            this.buttonDesign.Size = new System.Drawing.Size(75, 21);
            this.buttonDesign.TabIndex = 0;
            this.buttonDesign.Text = "&Design...";
            this.buttonDesign.Click += new System.EventHandler(this.ButtonDesign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "D:";
            // 
            // label_DE
            // 
            this.label_DE.Location = new System.Drawing.Point(64, 25);
            this.label_DE.Name = "label_DE";
            this.label_DE.Size = new System.Drawing.Size(404, 30);
            this.label_DE.TabIndex = 2;
            this.label_DE.Text = "Dieses Beispiel zeigt die Verwendung des ObjectDataProvider mit List && Label.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "US:";
            // 
            // label_US
            // 
            this.label_US.Location = new System.Drawing.Point(64, 59);
            this.label_US.Name = "label_US";
            this.label_US.Size = new System.Drawing.Size(404, 30);
            this.label_US.TabIndex = 4;
            this.label_US.Text = "This sample shows the usage of the ObjectDataProvider with List && Label.";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(332, 105);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(136, 21);
            this.buttonPrint.TabIndex = 6;
            this.buttonPrint.Text = "Print/Preview/Export...";
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // comboSelection
            // 
            this.comboSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelection.FormattingEnabled = true;
            this.comboSelection.ItemHeight = 13;
            this.comboSelection.Location = new System.Drawing.Point(23, 105);
            this.comboSelection.Name = "comboSelection";
            this.comboSelection.Size = new System.Drawing.Size(222, 21);
            this.comboSelection.TabIndex = 9;
            this.comboSelection.SelectedIndexChanged += new System.EventHandler(this.ComboSelection_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 150);
            this.Controls.Add(this.comboSelection);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.label_US);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_DE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDesign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "List & Label C# ObjectDataProvider Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private combit.Reporting.ListLabel LL;
        private System.Windows.Forms.Button buttonDesign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_DE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_US;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.ComboBox comboSelection;
    }
}
