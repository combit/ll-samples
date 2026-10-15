namespace ClientApiExample.Dialogs
{
    partial class EditTaskDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbReportTemplates = new System.Windows.Forms.ComboBox();
            this.cbExportProfiles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDisableReportCache = new System.Windows.Forms.CheckBox();
            this.chkSkipPrintOfEmptyReports = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.lvReportParameters = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkSetReportParameters = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.loadedFromTemplateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Name";
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(487, 22);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Tag = "ReportTemplateId";
            this.label2.Text = "Report Template:";
            // 
            // cbReportTemplates
            // 
            this.cbReportTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReportTemplates.FormattingEnabled = true;
            this.cbReportTemplates.Location = new System.Drawing.Point(12, 77);
            this.cbReportTemplates.Name = "cbReportTemplates";
            this.cbReportTemplates.Size = new System.Drawing.Size(487, 21);
            this.cbReportTemplates.TabIndex = 3;
            this.cbReportTemplates.SelectedIndexChanged += new System.EventHandler(this.cbReportTemplates_SelectedIndexChanged);
            // 
            // cbExportProfiles
            // 
            this.cbExportProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExportProfiles.FormattingEnabled = true;
            this.cbExportProfiles.Location = new System.Drawing.Point(12, 127);
            this.cbExportProfiles.Name = "cbExportProfiles";
            this.cbExportProfiles.Size = new System.Drawing.Size(487, 21);
            this.cbExportProfiles.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 4;
            this.label3.Tag = "ExportProfileId";
            this.label3.Text = "Export/Printer Profile:";
            // 
            // chkDisableReportCache
            // 
            this.chkDisableReportCache.AutoSize = true;
            this.chkDisableReportCache.Location = new System.Drawing.Point(12, 347);
            this.chkDisableReportCache.Name = "chkDisableReportCache";
            this.chkDisableReportCache.Size = new System.Drawing.Size(202, 17);
            this.chkDisableReportCache.TabIndex = 6;
            this.chkDisableReportCache.Tag = "DisableReportCache";
            this.chkDisableReportCache.Text = "Do not use reports from the cache";
            this.chkDisableReportCache.UseVisualStyleBackColor = true;
            // 
            // chkSkipPrintOfEmptyReports
            // 
            this.chkSkipPrintOfEmptyReports.AutoSize = true;
            this.chkSkipPrintOfEmptyReports.Location = new System.Drawing.Point(12, 370);
            this.chkSkipPrintOfEmptyReports.Name = "chkSkipPrintOfEmptyReports";
            this.chkSkipPrintOfEmptyReports.Size = new System.Drawing.Size(307, 17);
            this.chkSkipPrintOfEmptyReports.TabIndex = 7;
            this.chkSkipPrintOfEmptyReports.Tag = "CancelPrintOnServerWhenReportIsEmpty";
            this.chkSkipPrintOfEmptyReports.Text = "Skip print on server if no data records are in the report";
            this.chkSkipPrintOfEmptyReports.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(343, 427);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(424, 427);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddParameter.Enabled = false;
            this.btnAddParameter.Location = new System.Drawing.Point(380, 306);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(119, 30);
            this.btnAddParameter.TabIndex = 12;
            this.btnAddParameter.Text = "Add Parameter";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // lvReportParameters
            // 
            this.lvReportParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvReportParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.ValueColumn,
            this.columnHeader1});
            this.lvReportParameters.Enabled = false;
            this.lvReportParameters.FullRowSelect = true;
            this.lvReportParameters.GridLines = true;
            this.lvReportParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvReportParameters.HideSelection = false;
            this.lvReportParameters.Location = new System.Drawing.Point(12, 192);
            this.lvReportParameters.Name = "lvReportParameters";
            this.lvReportParameters.Size = new System.Drawing.Size(487, 108);
            this.lvReportParameters.TabIndex = 11;
            this.lvReportParameters.UseCompatibleStateImageBehavior = false;
            this.lvReportParameters.View = System.Windows.Forms.View.Details;
            this.lvReportParameters.ItemActivate += new System.EventHandler(this.lvReportParameters_ItemActivate);
            this.lvReportParameters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvReportParameters_KeyDown);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 199;
            // 
            // ValueColumn
            // 
            this.ValueColumn.Text = "Value";
            this.ValueColumn.Width = 190;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Use Default";
            this.columnHeader1.Width = 81;
            // 
            // chkSetReportParameters
            // 
            this.chkSetReportParameters.AutoSize = true;
            this.chkSetReportParameters.Location = new System.Drawing.Point(12, 169);
            this.chkSetReportParameters.Name = "chkSetReportParameters";
            this.chkSetReportParameters.Size = new System.Drawing.Size(160, 17);
            this.chkSetReportParameters.TabIndex = 13;
            this.chkSetReportParameters.Text = "Set the report parameters:";
            this.chkSetReportParameters.UseVisualStyleBackColor = true;
            this.chkSetReportParameters.CheckedChanged += new System.EventHandler(this.chkSetReportParameters_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // loadedFromTemplateLabel
            // 
            this.loadedFromTemplateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadedFromTemplateLabel.AutoSize = true;
            this.loadedFromTemplateLabel.Location = new System.Drawing.Point(300, 170);
            this.loadedFromTemplateLabel.Name = "loadedFromTemplateLabel";
            this.loadedFromTemplateLabel.Size = new System.Drawing.Size(199, 13);
            this.loadedFromTemplateLabel.TabIndex = 14;
            this.loadedFromTemplateLabel.Text = "Parameters are loaded from template.";
            this.loadedFromTemplateLabel.Visible = false;
            // 
            // EditTaskDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(511, 469);
            this.Controls.Add(this.loadedFromTemplateLabel);
            this.Controls.Add(this.chkSetReportParameters);
            this.Controls.Add(this.btnAddParameter);
            this.Controls.Add(this.lvReportParameters);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkSkipPrintOfEmptyReports);
            this.Controls.Add(this.chkDisableReportCache);
            this.Controls.Add(this.cbExportProfiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbReportTemplates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTaskDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create/Edit Task (Scheduled Report)";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbReportTemplates;
        private System.Windows.Forms.ComboBox cbExportProfiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDisableReportCache;
        private System.Windows.Forms.CheckBox chkSkipPrintOfEmptyReports;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddParameter;
        private System.Windows.Forms.ListView lvReportParameters;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader ValueColumn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox chkSetReportParameters;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label loadedFromTemplateLabel;
    }
}