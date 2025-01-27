namespace ClientApiExample.Dialogs
{
    partial class ManageTaskTriggersDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTaskTriggersDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewTriggers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddTrigger = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTrigger = new System.Windows.Forms.ToolStripButton();
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
            this.panel1.Controls.Add(this.listViewTriggers);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 290);
            this.panel1.TabIndex = 1;
            // 
            // listViewTriggers
            // 
            this.listViewTriggers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTriggers.FullRowSelect = true;
            this.listViewTriggers.Location = new System.Drawing.Point(0, 25);
            this.listViewTriggers.Name = "listViewTriggers";
            this.listViewTriggers.Size = new System.Drawing.Size(712, 265);
            this.listViewTriggers.TabIndex = 11;
            this.listViewTriggers.UseCompatibleStateImageBehavior = false;
            this.listViewTriggers.View = System.Windows.Forms.View.Details;
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
            this.btnAddTrigger,
            this.btnDeleteTrigger,
            this.btnEditProperties});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(712, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddTrigger
            // 
            this.btnAddTrigger.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTrigger.Image")));
            this.btnAddTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTrigger.Name = "btnAddTrigger";
            this.btnAddTrigger.Size = new System.Drawing.Size(89, 22);
            this.btnAddTrigger.Text = "Add Trigger";
            this.btnAddTrigger.Click += new System.EventHandler(this.btnAddTrigger_Click);
            // 
            // btnDeleteTrigger
            // 
            this.btnDeleteTrigger.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTrigger.Image")));
            this.btnDeleteTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteTrigger.Name = "btnDeleteTrigger";
            this.btnDeleteTrigger.Size = new System.Drawing.Size(100, 22);
            this.btnDeleteTrigger.Text = "Delete Trigger";
            this.btnDeleteTrigger.Click += new System.EventHandler(this.btnDeleteTrigger_Click);
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
            this.btnClose.Location = new System.Drawing.Point(649, 308);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ManageTaskTriggersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(736, 350);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageTaskTriggersDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Triggers";
            this.Load += new System.EventHandler(this.ManageTaskTriggersDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewTriggers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDeleteTrigger;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripButton btnAddTrigger;
        private System.Windows.Forms.ToolStripButton btnEditProperties;
    }
}