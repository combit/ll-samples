namespace LocalizationSample
{
    partial class LocalizationForm
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
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.designButton = new MetroFramework.Controls.MetroButton();
            this.printButton = new MetroFramework.Controls.MetroButton();
            this.LL = new combit.ListLabel24.ListLabel(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(23, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "US:";
            this.label1.WrapToLine = true;
            // 
            // label5
            // 
            this.label5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(23, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "D:  ";
            this.label5.WrapToLine = true;
            // 
            // label4
            // 
            this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(42, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(365, 48);
            this.label4.TabIndex = 9;
            this.label4.Text = "This sample shows how to design multi language reports. The report template is th" +
    "e same for all languages - the localization is done with the Dictionary object.";
            this.label4.WrapToLine = true;
            // 
            // label3
            // 
            this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(42, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 48);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dieses Beispiel zeigt das Designen von mehrsprachigen Reports. Die Reportvorlage " +
    "ist für alle Sprachen die Gleiche, die Lokalisierung wird über das Dictionary-Ob" +
    "jekt erreicht.";
            this.label3.WrapToLine = true;
            // 
            // designButton
            // 
            this.designButton.Location = new System.Drawing.Point(225, 171);
            this.designButton.Name = "designButton";
            this.designButton.Size = new System.Drawing.Size(88, 24);
            this.designButton.TabIndex = 14;
            this.designButton.Text = "&Design...";
            this.designButton.UseSelectable = true;
            this.designButton.Click += new System.EventHandler(this.DesignButton_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(319, 171);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(88, 24);
            this.printButton.TabIndex = 15;
            this.printButton.Text = "&Print...";
            this.printButton.UseSelectable = true;
            this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
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
            // LocalizationForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(438, 218);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.designButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalizationForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# Localization Sample";
            this.ResumeLayout(false);

        }

        private combit.ListLabel24.ListLabel LL;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroButton designButton;
        private MetroFramework.Controls.MetroButton printButton;

        #endregion
    }
}
