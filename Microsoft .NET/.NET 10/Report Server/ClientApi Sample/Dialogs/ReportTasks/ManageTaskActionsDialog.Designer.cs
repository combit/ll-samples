namespace ClientApiExample.Dialogs
{
    partial class ManageTaskActionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTaskActionsDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewActions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddAction = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAddEmailAction = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddFileCopyAction = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddFtpUploadAction = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSharepointAction = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteAction = new System.Windows.Forms.ToolStripButton();
            this.btnEditProperties = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.listViewActions);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 293);
            this.panel1.TabIndex = 1;
            // 
            // listViewActions
            // 
            this.listViewActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewActions.FullRowSelect = true;
            this.listViewActions.Location = new System.Drawing.Point(0, 25);
            this.listViewActions.Name = "listViewActions";
            this.listViewActions.Size = new System.Drawing.Size(712, 268);
            this.listViewActions.TabIndex = 11;
            this.listViewActions.UseCompatibleStateImageBehavior = false;
            this.listViewActions.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 340;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 146;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddAction,
            this.btnDeleteAction,
            this.btnEditProperties});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(712, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddAction
            // 
            this.btnAddAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddEmailAction,
            this.btnAddFileCopyAction,
            this.btnAddFtpUploadAction,
            this.btnAddSharepointAction});
            this.btnAddAction.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAction.Image")));
            this.btnAddAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(96, 22);
            this.btnAddAction.Text = "Add Action";
            // 
            // btnAddEmailAction
            // 
            this.btnAddEmailAction.Name = "btnAddEmailAction";
            this.btnAddEmailAction.Size = new System.Drawing.Size(181, 22);
            this.btnAddEmailAction.Text = "Send E-Mail...";
            this.btnAddEmailAction.Click += new System.EventHandler(this.btnAddEmailAction_Click);
            // 
            // btnAddFileCopyAction
            // 
            this.btnAddFileCopyAction.Name = "btnAddFileCopyAction";
            this.btnAddFileCopyAction.Size = new System.Drawing.Size(181, 22);
            this.btnAddFileCopyAction.Text = "File Copy...";
            this.btnAddFileCopyAction.Click += new System.EventHandler(this.btnAddFileCopyAction_Click);
            // 
            // btnAddFtpUploadAction
            // 
            this.btnAddFtpUploadAction.Name = "btnAddFtpUploadAction";
            this.btnAddFtpUploadAction.Size = new System.Drawing.Size(181, 22);
            this.btnAddFtpUploadAction.Text = "FTP Upload...";
            this.btnAddFtpUploadAction.Click += new System.EventHandler(this.btnAddFtpUploadAction_Click);
            // 
            // btnAddSharepointAction
            // 
            this.btnAddSharepointAction.Name = "btnAddSharepointAction";
            this.btnAddSharepointAction.Size = new System.Drawing.Size(181, 22);
            this.btnAddSharepointAction.Text = "Sharepoint Upload...";
            this.btnAddSharepointAction.Click += new System.EventHandler(this.btnAddSharepointAction_Click);
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteAction.Image")));
            this.btnDeleteAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(98, 22);
            this.btnDeleteAction.Text = "Delete Action";
            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
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
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(649, 318);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ManageTaskActionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(736, 360);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageTaskActionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Actions";
            this.Load += new System.EventHandler(this.ManageTaskActionsDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewActions;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDeleteAction;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripButton btnEditProperties;
        private System.Windows.Forms.ToolStripDropDownButton btnAddAction;
        private System.Windows.Forms.ToolStripMenuItem btnAddEmailAction;
        private System.Windows.Forms.ToolStripMenuItem btnAddFtpUploadAction;
        private System.Windows.Forms.ToolStripMenuItem btnAddFileCopyAction;
        private System.Windows.Forms.ToolStripMenuItem btnAddSharepointAction;
    }
}