namespace ClientApiExample.Dialogs
{
    partial class ManageReportTasksDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageReportTasksDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewReportTasks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRunScheduledReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddTask = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTask = new System.Windows.Forms.ToolStripButton();
            this.btnEditProperties = new System.Windows.Forms.ToolStripButton();
            this.btnManageTriggers = new System.Windows.Forms.ToolStripButton();
            this.btnManageActions = new System.Windows.Forms.ToolStripButton();
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
            this.panel1.Controls.Add(this.listViewReportTasks);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 290);
            this.panel1.TabIndex = 1;
            // 
            // listViewReportTasks
            // 
            this.listViewReportTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewReportTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewReportTasks.FullRowSelect = true;
            this.listViewReportTasks.Location = new System.Drawing.Point(0, 25);
            this.listViewReportTasks.Name = "listViewReportTasks";
            this.listViewReportTasks.Size = new System.Drawing.Size(712, 265);
            this.listViewReportTasks.TabIndex = 11;
            this.listViewReportTasks.UseCompatibleStateImageBehavior = false;
            this.listViewReportTasks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 242;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Owner";
            this.columnHeader2.Width = 146;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Modified By";
            this.columnHeader3.Width = 152;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Modified On";
            this.columnHeader4.Width = 144;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRunScheduledReport,
            this.toolStripSeparator1,
            this.btnAddTask,
            this.btnDeleteTask,
            this.btnEditProperties,
            this.btnManageTriggers,
            this.btnManageActions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(712, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRunScheduledReport
            // 
            this.btnRunScheduledReport.Image = ((System.Drawing.Image)(resources.GetObject("btnRunScheduledReport.Image")));
            this.btnRunScheduledReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunScheduledReport.Name = "btnRunScheduledReport";
            this.btnRunScheduledReport.Size = new System.Drawing.Size(74, 22);
            this.btnRunScheduledReport.Text = "Run Task";
            this.btnRunScheduledReport.Click += new System.EventHandler(this.btnRunScheduledReport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTask.Image")));
            this.btnAddTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 22);
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTask.Image")));
            this.btnDeleteTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(86, 22);
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
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
            // btnManageTriggers
            // 
            this.btnManageTriggers.Image = ((System.Drawing.Image)(resources.GetObject("btnManageTriggers.Image")));
            this.btnManageTriggers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageTriggers.Name = "btnManageTriggers";
            this.btnManageTriggers.Size = new System.Drawing.Size(101, 22);
            this.btnManageTriggers.Text = "Edit Triggers...";
            this.btnManageTriggers.Click += new System.EventHandler(this.btnManageTriggers_Click_1);
            // 
            // btnManageActions
            // 
            this.btnManageActions.Image = ((System.Drawing.Image)(resources.GetObject("btnManageActions.Image")));
            this.btnManageActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageActions.Name = "btnManageActions";
            this.btnManageActions.Size = new System.Drawing.Size(99, 22);
            this.btnManageActions.Text = "Edit Actions...";
            this.btnManageActions.Click += new System.EventHandler(this.btnManageActions_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(649, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ManageReportTasksDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(736, 356);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageReportTasksDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Tasks (Scheduled Reports)";
            this.Load += new System.EventHandler(this.ManageReportTasksDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewReportTasks;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDeleteTask;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton btnRunScheduledReport;
        private System.Windows.Forms.ToolStripButton btnAddTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditProperties;
        private System.Windows.Forms.ToolStripButton btnManageActions;
        private System.Windows.Forms.ToolStripButton btnManageTriggers;
    }
}