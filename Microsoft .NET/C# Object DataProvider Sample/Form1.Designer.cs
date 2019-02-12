namespace combit.ListLabel24.CSharpSample.ObjectDataProviderSample
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
            this.LL = new combit.ListLabel24.ListLabel(this.components);
            this.buttonDesign = new MetroFramework.Controls.MetroButton();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label_DE = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label_US = new MetroFramework.Controls.MetroLabel();
            this.buttonPrint = new MetroFramework.Controls.MetroButton();
            this.comboSelection = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // LL
            // 
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.CompressStorage = true;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_100;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // buttonDesign
            // 
            this.buttonDesign.Location = new System.Drawing.Point(251, 140);
            this.buttonDesign.Name = "buttonDesign";
            this.buttonDesign.Size = new System.Drawing.Size(75, 29);
            this.buttonDesign.TabIndex = 0;
            this.buttonDesign.Text = "&Design...";
            this.buttonDesign.UseSelectable = true;
            this.buttonDesign.Click += new System.EventHandler(this.ButtonDesign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(23, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "D:";
            // 
            // label_DE
            // 
            this.label_DE.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label_DE.Location = new System.Drawing.Point(64, 60);
            this.label_DE.Name = "label_DE";
            this.label_DE.Size = new System.Drawing.Size(404, 30);
            this.label_DE.TabIndex = 2;
            this.label_DE.Text = "Dieses Beispiel zeigt die Verwendung des ObjectDataProvider mit List && Label.";
            this.label_DE.WrapToLine = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(23, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "US:";
            // 
            // label_US
            // 
            this.label_US.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label_US.Location = new System.Drawing.Point(64, 94);
            this.label_US.Name = "label_US";
            this.label_US.Size = new System.Drawing.Size(404, 30);
            this.label_US.TabIndex = 4;
            this.label_US.Text = "This sample shows the usage of the ObjectDataProvider with List && Label.";
            this.label_US.WrapToLine = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(332, 140);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(136, 29);
            this.buttonPrint.TabIndex = 6;
            this.buttonPrint.Text = "Print/Preview/Export...";
            this.buttonPrint.UseSelectable = true;
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // comboSelection
            // 
            this.comboSelection.FormattingEnabled = true;
            this.comboSelection.ItemHeight = 23;
            this.comboSelection.Location = new System.Drawing.Point(23, 140);
            this.comboSelection.Name = "comboSelection";
            this.comboSelection.Size = new System.Drawing.Size(222, 29);
            this.comboSelection.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboSelection.TabIndex = 9;
            this.comboSelection.UseSelectable = true;
            this.comboSelection.SelectedIndexChanged += new System.EventHandler(this.ComboSelection_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 192);
            this.Controls.Add(this.comboSelection);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.label_US);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_DE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDesign);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# ObjectDataProvider Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private combit.ListLabel24.ListLabel LL;
        private MetroFramework.Controls.MetroButton buttonDesign;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label_DE;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroLabel label_US;
        private MetroFramework.Controls.MetroButton buttonPrint;
        private MetroFramework.Controls.MetroComboBox comboSelection;
    }
}

