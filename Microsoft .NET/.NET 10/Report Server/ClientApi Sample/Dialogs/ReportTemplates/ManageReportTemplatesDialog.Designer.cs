namespace ClientApiExample
{
    partial class ManageReportTemplatesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageReportTemplatesDialog));
            this.folderTree = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.templateList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnEditProperties = new System.Windows.Forms.ToolStripButton();
            this.txtSearchText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnChooseDatasources = new System.Windows.Forms.ToolStripButton();
            this.btnEditAccessRights = new System.Windows.Forms.ToolStripButton();
            this.btnEditRepository = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderTree
            // 
            this.folderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderTree.Location = new System.Drawing.Point(0, 0);
            this.folderTree.Name = "folderTree";
            this.folderTree.Size = new System.Drawing.Size(202, 387);
            this.folderTree.TabIndex = 0;
            this.folderTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.folderTree_NodeMouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folderTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.templateList);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1289, 387);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 1;
            // 
            // templateList
            // 
            this.templateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.templateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateList.FullRowSelect = true;
            this.templateList.Location = new System.Drawing.Point(0, 25);
            this.templateList.Name = "templateList";
            this.templateList.Size = new System.Drawing.Size(1083, 362);
            this.templateList.TabIndex = 4;
            this.templateList.UseCompatibleStateImageBehavior = false;
            this.templateList.View = System.Windows.Forms.View.Details;
            this.templateList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.templateList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 263;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Created By";
            this.columnHeader2.Width = 139;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Modified By";
            this.columnHeader3.Width = 164;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Modified On";
            this.columnHeader4.Width = 174;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.toolStripSeparator1,
            this.btnNewTemplate,
            this.btnDeleteTemplate,
            this.btnEditProperties,
            this.txtSearchText,
            this.toolStripLabel1,
            this.btnChooseDatasources,
            this.btnEditAccessRights,
            this.btnEditRepository});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(1083, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 22);
            this.btnExport.Text = "Export Report...";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNewTemplate
            // 
            this.btnNewTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTemplate.Image")));
            this.btnNewTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewTemplate.Name = "btnNewTemplate";
            this.btnNewTemplate.Size = new System.Drawing.Size(112, 22);
            this.btnNewTemplate.Text = "New Template...";
            this.btnNewTemplate.Click += new System.EventHandler(this.btnNewTemplate_Click);
            // 
            // btnDeleteTemplate
            // 
            this.btnDeleteTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTemplate.Image")));
            this.btnDeleteTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(112, 22);
            this.btnDeleteTemplate.Text = "Delete Template";
            this.btnDeleteTemplate.Click += new System.EventHandler(this.btnDeleteTemplate_Click);
            // 
            // btnEditProperties
            // 
            this.btnEditProperties.Image = ((System.Drawing.Image)(resources.GetObject("btnEditProperties.Image")));
            this.btnEditProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditProperties.Name = "btnEditProperties";
            this.btnEditProperties.Size = new System.Drawing.Size(112, 22);
            this.btnEditProperties.Text = "Edit Properties...";
            this.btnEditProperties.Click += new System.EventHandler(this.btnEditProperties_Click);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(150, 25);
            this.txtSearchText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchText_KeyUp);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Search:";
            // 
            // btnChooseDatasources
            // 
            this.btnChooseDatasources.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseDatasources.Image")));
            this.btnChooseDatasources.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChooseDatasources.Name = "btnChooseDatasources";
            this.btnChooseDatasources.Size = new System.Drawing.Size(127, 22);
            this.btnChooseDatasources.Text = "Edit Data Sources...";
            this.btnChooseDatasources.Click += new System.EventHandler(this.btnChooseDatasources_Click);
            // 
            // btnEditAccessRights
            // 
            this.btnEditAccessRights.Image = ((System.Drawing.Image)(resources.GetObject("btnEditAccessRights.Image")));
            this.btnEditAccessRights.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAccessRights.Name = "btnEditAccessRights";
            this.btnEditAccessRights.Size = new System.Drawing.Size(122, 22);
            this.btnEditAccessRights.Text = "Edit Access Rights";
            this.btnEditAccessRights.Click += new System.EventHandler(this.btnEditAccessRights_Click);
            // 
            // btnEditRepository
            // 
            this.btnEditRepository.Image = ((System.Drawing.Image)(resources.GetObject("btnEditRepository.Image")));
            this.btnEditRepository.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditRepository.Name = "btnEditRepository";
            this.btnEditRepository.Size = new System.Drawing.Size(106, 22);
            this.btnEditRepository.Text = "Edit Repository";
            this.btnEditRepository.Click += new System.EventHandler(this.btnEditRepository_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1226, 405);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ManageReportTemplatesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1313, 443);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManageReportTemplatesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Report Templates";
            this.Load += new System.EventHandler(this.ReportTemplateListDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView folderTree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView templateList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEditProperties;
        private System.Windows.Forms.ToolStripTextBox txtSearchText;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnNewTemplate;
        private System.Windows.Forms.ToolStripButton btnChooseDatasources;
        private System.Windows.Forms.ToolStripButton btnEditAccessRights;
        private System.Windows.Forms.ToolStripButton btnDeleteTemplate;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditRepository;
    }
}