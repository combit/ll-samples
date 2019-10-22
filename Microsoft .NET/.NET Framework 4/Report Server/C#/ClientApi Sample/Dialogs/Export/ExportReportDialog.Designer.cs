namespace ClientApiExample.Dialogs
{
    partial class ExportReportDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectExportOrPrinterProfile = new System.Windows.Forms.Label();
            this.cbReportTemplate = new System.Windows.Forms.ComboBox();
            this.cbExportProfile = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDisableCache = new System.Windows.Forms.CheckBox();
            this.btnExportOrPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lvReportParameters = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select a report template:";
            // 
            // lblSelectExportOrPrinterProfile
            // 
            this.lblSelectExportOrPrinterProfile.AutoSize = true;
            this.lblSelectExportOrPrinterProfile.Location = new System.Drawing.Point(12, 69);
            this.lblSelectExportOrPrinterProfile.Name = "lblSelectExportOrPrinterProfile";
            this.lblSelectExportOrPrinterProfile.Size = new System.Drawing.Size(205, 13);
            this.lblSelectExportOrPrinterProfile.TabIndex = 1;
            this.lblSelectExportOrPrinterProfile.Text = "Please select an export or print profile:";
            // 
            // cbReportTemplate
            // 
            this.cbReportTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReportTemplate.FormattingEnabled = true;
            this.cbReportTemplate.Location = new System.Drawing.Point(15, 32);
            this.cbReportTemplate.Name = "cbReportTemplate";
            this.cbReportTemplate.Size = new System.Drawing.Size(510, 21);
            this.cbReportTemplate.TabIndex = 2;
            this.cbReportTemplate.SelectedIndexChanged += new System.EventHandler(this.cbReportTemplates_SelectedIndexChanged);
            // 
            // cbExportProfile
            // 
            this.cbExportProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExportProfile.FormattingEnabled = true;
            this.cbExportProfile.Location = new System.Drawing.Point(15, 85);
            this.cbExportProfile.Name = "cbExportProfile";
            this.cbExportProfile.Size = new System.Drawing.Size(510, 21);
            this.cbExportProfile.TabIndex = 3;
            this.cbExportProfile.SelectedIndexChanged += new System.EventHandler(this.cbExportProfile_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Other Options:";
            // 
            // chkDisableCache
            // 
            this.chkDisableCache.AutoSize = true;
            this.chkDisableCache.Location = new System.Drawing.Point(15, 296);
            this.chkDisableCache.Name = "chkDisableCache";
            this.chkDisableCache.Size = new System.Drawing.Size(195, 17);
            this.chkDisableCache.TabIndex = 5;
            this.chkDisableCache.Text = "Don\'t use reports from the cache";
            this.chkDisableCache.UseVisualStyleBackColor = true;
            // 
            // btnExportOrPrint
            // 
            this.btnExportOrPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportOrPrint.Location = new System.Drawing.Point(369, 363);
            this.btnExportOrPrint.Name = "btnExportOrPrint";
            this.btnExportOrPrint.Size = new System.Drawing.Size(75, 28);
            this.btnExportOrPrint.TabIndex = 6;
            this.btnExportOrPrint.Text = "Export";
            this.btnExportOrPrint.UseVisualStyleBackColor = true;
            this.btnExportOrPrint.Click += new System.EventHandler(this.btnExportOrPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(450, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Specify report parameters that the export might need:";
            // 
            // lvReportParameters
            // 
            this.lvReportParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvReportParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.ValueColumn});
            this.lvReportParameters.FullRowSelect = true;
            this.lvReportParameters.GridLines = true;
            this.lvReportParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReportParameters.Location = new System.Drawing.Point(15, 136);
            this.lvReportParameters.Name = "lvReportParameters";
            this.lvReportParameters.Size = new System.Drawing.Size(510, 108);
            this.lvReportParameters.TabIndex = 9;
            this.lvReportParameters.UseCompatibleStateImageBehavior = false;
            this.lvReportParameters.View = System.Windows.Forms.View.Details;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 210;
            // 
            // ValueColumn
            // 
            this.ValueColumn.Text = "Value";
            this.ValueColumn.Width = 290;
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddParameter.Location = new System.Drawing.Point(405, 250);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(120, 28);
            this.btnAddParameter.TabIndex = 10;
            this.btnAddParameter.Text = "Add Parameter";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 352);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "[Status]";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 368);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(140, 23);
            this.progressBar.TabIndex = 12;
            // 
            // ExportReportDialog
            // 
            this.AcceptButton = this.btnExportOrPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(537, 403);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAddParameter);
            this.Controls.Add(this.lvReportParameters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExportOrPrint);
            this.Controls.Add(this.chkDisableCache);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbExportProfile);
            this.Controls.Add(this.cbReportTemplate);
            this.Controls.Add(this.lblSelectExportOrPrinterProfile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportReportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export/Print a Report";
            this.Load += new System.EventHandler(this.ExportReportDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbReportTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDisableCache;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvReportParameters;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader ValueColumn;
        private System.Windows.Forms.Button btnAddParameter;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        protected System.Windows.Forms.ComboBox cbExportProfile;
        protected System.Windows.Forms.Button btnExportOrPrint;
        protected System.Windows.Forms.Label lblSelectExportOrPrinterProfile;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}