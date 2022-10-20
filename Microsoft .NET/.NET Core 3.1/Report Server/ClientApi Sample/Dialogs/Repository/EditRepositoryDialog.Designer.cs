namespace ClientApiExample.Dialogs
{
    partial class EditRepositoryDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRepositoryDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvRepoItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.addListLabelProjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPdfFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteRepoItem = new System.Windows.Forms.ToolStripButton();
            this.btnView = new System.Windows.Forms.ToolStripButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Repository of Report Template:";
            // 
            // txtReportName
            // 
            this.txtReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportName.Location = new System.Drawing.Point(15, 70);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.ReadOnly = true;
            this.txtReportName.Size = new System.Drawing.Size(845, 22);
            this.txtReportName.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(785, 437);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lvRepoItems);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(15, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 333);
            this.panel1.TabIndex = 5;
            // 
            // lvRepoItems
            // 
            this.lvRepoItems.AllowColumnReorder = true;
            this.lvRepoItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.lvRepoItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRepoItems.FullRowSelect = true;
            this.lvRepoItems.Location = new System.Drawing.Point(0, 25);
            this.lvRepoItems.MultiSelect = false;
            this.lvRepoItems.Name = "lvRepoItems";
            this.lvRepoItems.Size = new System.Drawing.Size(845, 308);
            this.lvRepoItems.TabIndex = 10;
            this.lvRepoItems.UseCompatibleStateImageBehavior = false;
            this.lvRepoItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Repository ID";
            this.columnHeader1.Width = 298;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 155;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 127;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Modification";
            this.columnHeader3.Width = 154;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddItem,
            this.btnDeleteRepoItem,
            this.btnView});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(845, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddItem
            // 
            this.btnAddItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addListLabelProjectMenuItem,
            this.addPdfFileMenuItem,
            this.addImageMenuItem});
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(85, 22);
            this.btnAddItem.Text = "Add Item";
            // 
            // addListLabelProjectMenuItem
            // 
            this.addListLabelProjectMenuItem.Name = "addListLabelProjectMenuItem";
            this.addListLabelProjectMenuItem.Size = new System.Drawing.Size(231, 22);
            this.addListLabelProjectMenuItem.Text = "Add List && Label Project File...";
            this.addListLabelProjectMenuItem.Click += new System.EventHandler(this.addListLabelProjectMenuItem_Click);
            // 
            // addPdfFileMenuItem
            // 
            this.addPdfFileMenuItem.Name = "addPdfFileMenuItem";
            this.addPdfFileMenuItem.Size = new System.Drawing.Size(231, 22);
            this.addPdfFileMenuItem.Text = "Add PDF file...";
            this.addPdfFileMenuItem.Click += new System.EventHandler(this.AddPdfFileMenuItem_Click);
            // 
            // addImageMenuItem
            // 
            this.addImageMenuItem.Name = "addImageMenuItem";
            this.addImageMenuItem.Size = new System.Drawing.Size(231, 22);
            this.addImageMenuItem.Text = "Add Image File...";
            this.addImageMenuItem.Click += new System.EventHandler(this.AddImageMenuItem_Click);
            // 
            // btnDeleteRepoItem
            // 
            this.btnDeleteRepoItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRepoItem.Image")));
            this.btnDeleteRepoItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteRepoItem.Name = "btnDeleteRepoItem";
            this.btnDeleteRepoItem.Size = new System.Drawing.Size(87, 22);
            this.btnDeleteRepoItem.Text = "Delete Item";
            this.btnDeleteRepoItem.Click += new System.EventHandler(this.btnDeleteRepoItem_Click);
            // 
            // btnView
            // 
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(79, 22);
            this.btnView.Text = "View Item";
            this.btnView.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(664, 437);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 28);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Apply (Commit)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(848, 34);
            this.label2.TabIndex = 7;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // EditRepositoryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(872, 474);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReportName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRepositoryDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Repository";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditRepositoryDialog_FormClosed);
            this.Load += new System.EventHandler(this.EditRepositoryDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvRepoItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnAddItem;
        private System.Windows.Forms.ToolStripMenuItem addListLabelProjectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPdfFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addImageMenuItem;
        private System.Windows.Forms.ToolStripButton btnDeleteRepoItem;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolStripButton btnView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
    }
}