namespace ClientApiExample.Dialogs
{
    partial class ManageDataSourcesDialog
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
            System.Windows.Forms.Panel panel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDataSourcesDialog));
            this.lstDataSources = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDeleteDataSource = new System.Windows.Forms.ToolStripButton();
            this.btnEditProperties = new System.Windows.Forms.ToolStripButton();
            this.btnEditAccessRights = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.folderTree = new System.Windows.Forms.TreeView();
            this.txtSearchText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(this.lstDataSources);
            panel1.Controls.Add(this.toolStrip1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(695, 311);
            panel1.TabIndex = 7;
            // 
            // lstDataSources
            // 
            this.lstDataSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstDataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDataSources.FullRowSelect = true;
            this.lstDataSources.Location = new System.Drawing.Point(0, 25);
            this.lstDataSources.Name = "lstDataSources";
            this.lstDataSources.Size = new System.Drawing.Size(695, 286);
            this.lstDataSources.TabIndex = 8;
            this.lstDataSources.UseCompatibleStateImageBehavior = false;
            this.lstDataSources.View = System.Windows.Forms.View.Details;
            this.lstDataSources.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstDataSources_MouseDoubleClick);
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
            this.btnDeleteDataSource,
            this.btnEditProperties,
            this.btnEditAccessRights,
            this.txtSearchText,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(695, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDeleteDataSource
            // 
            this.btnDeleteDataSource.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDataSource.Image")));
            this.btnDeleteDataSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteDataSource.Name = "btnDeleteDataSource";
            this.btnDeleteDataSource.Size = new System.Drawing.Size(126, 22);
            this.btnDeleteDataSource.Text = "Delete Data Source";
            this.btnDeleteDataSource.Click += new System.EventHandler(this.btnDataSourceTemplate_Click);
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
            // btnEditAccessRights
            // 
            this.btnEditAccessRights.Image = ((System.Drawing.Image)(resources.GetObject("btnEditAccessRights.Image")));
            this.btnEditAccessRights.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAccessRights.Name = "btnEditAccessRights";
            this.btnEditAccessRights.Size = new System.Drawing.Size(122, 22);
            this.btnEditAccessRights.Text = "Edit Access Rights";
            this.btnEditAccessRights.Click += new System.EventHandler(this.btnEditAccessRights_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(852, 334);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel2.Controls.Add(panel1);
            this.splitContainer1.Size = new System.Drawing.Size(915, 311);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 9;
            // 
            // folderTree
            // 
            this.folderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderTree.Location = new System.Drawing.Point(0, 0);
            this.folderTree.Name = "folderTree";
            this.folderTree.Size = new System.Drawing.Size(216, 311);
            this.folderTree.TabIndex = 0;
            this.folderTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.folderTree_NodeMouseClick);
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
            // ManageDataSourcesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 374);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageDataSourcesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Manage Data Sources";
            this.Load += new System.EventHandler(this.ManageDataSourcesDialog_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstDataSources;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDeleteDataSource;
        private System.Windows.Forms.ToolStripButton btnEditProperties;
        private System.Windows.Forms.ToolStripButton btnEditAccessRights;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView folderTree;
        private System.Windows.Forms.ToolStripTextBox txtSearchText;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}