namespace DataGridView
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.tbDescription = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.btnDesign = new MetroFramework.Controls.MetroButton();
            this.btnPrint = new MetroFramework.Controls.MetroButton();
            this.LL = new combit.ListLabel24.ListLabel(this.components);
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.cbTable = new MetroFramework.Controls.MetroComboBox();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.cbOnlyDisplayableColumns = new MetroFramework.Controls.MetroCheckBox();
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label7 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(23, 148);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(822, 419);
            this.dgvData.TabIndex = 4;
            this.dgvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvData_ColumnHeaderMouseClick);
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDescription.BackColor = System.Drawing.SystemColors.Window;
            this.tbDescription.Lines = new string[] {
        "Dynamically created project"};
            this.tbDescription.Location = new System.Drawing.Point(134, 582);
            this.tbDescription.MaxLength = 32767;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.PasswordChar = '\0';
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbDescription.SelectedText = "";
            this.tbDescription.Size = new System.Drawing.Size(195, 20);
            this.tbDescription.TabIndex = 2;
            this.tbDescription.Text = "Dynamically created project";
            this.tbDescription.UseCustomBackColor = true;
            this.tbDescription.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(25, 584);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project description:";
            // 
            // btnDesign
            // 
            this.btnDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesign.Location = new System.Drawing.Point(689, 579);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(75, 23);
            this.btnDesign.TabIndex = 0;
            this.btnDesign.Text = "Design...";
            this.btnDesign.UseSelectable = true;
            this.btnDesign.Click += new System.EventHandler(this.BtnDesign_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(770, 579);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print...";
            this.btnPrint.UseSelectable = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // LL
            // 
            this.LL.AutoDestination = combit.ListLabel24.LlPrintMode.MultipleJobs;
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.AutoShowPrintOptions = false;
            this.LL.AutoShowSelectFile = false;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_10;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(23, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Table:";
            // 
            // cbTable
            // 
            this.cbTable.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbTable.ItemHeight = 19;
            this.cbTable.Location = new System.Drawing.Point(62, 108);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(360, 25);
            this.cbTable.Style = MetroFramework.MetroColorStyle.Blue;
            this.cbTable.TabIndex = 3;
            this.cbTable.UseSelectable = true;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.CbTable_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(23, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "D:  ";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(44, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(554, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dieses Beispiel zeigt die dynamische Erstellung von List && Label Projekten mit A" +
    "uslesen eines Datagridviews.";
            this.label3.WrapToLine = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(23, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "US:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(44, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(554, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "This sample shows the dynamic creation of List && Label projects with reading a d" +
    "atagridview.";
            this.label6.WrapToLine = true;
            // 
            // cbOnlyDisplayableColumns
            // 
            this.cbOnlyDisplayableColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOnlyDisplayableColumns.AutoSize = true;
            this.cbOnlyDisplayableColumns.Location = new System.Drawing.Point(492, 584);
            this.cbOnlyDisplayableColumns.Name = "cbOnlyDisplayableColumns";
            this.cbOnlyDisplayableColumns.Size = new System.Drawing.Size(190, 15);
            this.cbOnlyDisplayableColumns.Style = MetroFramework.MetroColorStyle.Blue;
            this.cbOnlyDisplayableColumns.TabIndex = 12;
            this.cbOnlyDisplayableColumns.Text = "Only show displayable columns";
            this.cbOnlyDisplayableColumns.UseSelectable = true;
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Name = "cmsRightClick";
            this.cmsRightClick.Size = new System.Drawing.Size(61, 4);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label7.Location = new System.Drawing.Point(493, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(351, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Information: right click on the columnname to enable/disable columns";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 625);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbOnlyDisplayableColumns);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDesign);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDescription);
            this.MinimumSize = new System.Drawing.Size(870, 625);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# Data Grid View Sample";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private MetroFramework.Controls.MetroTextBox tbDescription;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroButton btnDesign;
        private MetroFramework.Controls.MetroButton btnPrint;
        private combit.ListLabel24.ListLabel LL;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroComboBox cbTable;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Controls.MetroCheckBox cbOnlyDisplayableColumns;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private MetroFramework.Controls.MetroLabel label7;
    }
}

