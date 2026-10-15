namespace ClientApiExample.Dialogs
{
    partial class StartDialog
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
            this.btnManageReports = new System.Windows.Forms.Button();
            this.btnManageDatasources = new System.Windows.Forms.Button();
            this.btnManagedReportTasks = new System.Windows.Forms.Button();
            this.btnListLabelSamples = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a subsection of this example:";
            // 
            // btnManageReports
            // 
            this.btnManageReports.Location = new System.Drawing.Point(15, 46);
            this.btnManageReports.Name = "btnManageReports";
            this.btnManageReports.Size = new System.Drawing.Size(451, 41);
            this.btnManageReports.TabIndex = 1;
            this.btnManageReports.Text = "Manage && Export Reports";
            this.btnManageReports.UseVisualStyleBackColor = true;
            this.btnManageReports.Click += new System.EventHandler(this.btnManageReports_Click);
            // 
            // btnManageDatasources
            // 
            this.btnManageDatasources.Location = new System.Drawing.Point(15, 93);
            this.btnManageDatasources.Name = "btnManageDatasources";
            this.btnManageDatasources.Size = new System.Drawing.Size(451, 41);
            this.btnManageDatasources.TabIndex = 2;
            this.btnManageDatasources.Text = "Manage Data Sources\r\n";
            this.btnManageDatasources.UseVisualStyleBackColor = true;
            this.btnManageDatasources.Click += new System.EventHandler(this.btnManageDatasources_Click);
            // 
            // btnManagedReportTasks
            // 
            this.btnManagedReportTasks.Location = new System.Drawing.Point(15, 140);
            this.btnManagedReportTasks.Name = "btnManagedReportTasks";
            this.btnManagedReportTasks.Size = new System.Drawing.Size(451, 41);
            this.btnManagedReportTasks.TabIndex = 3;
            this.btnManagedReportTasks.Text = "Manage Tasks (Scheduled Reports)";
            this.btnManagedReportTasks.UseVisualStyleBackColor = true;
            this.btnManagedReportTasks.Click += new System.EventHandler(this.btnManageReportTasks_Click);
            // 
            // btnListLabelSamples
            // 
            this.btnListLabelSamples.Location = new System.Drawing.Point(15, 187);
            this.btnListLabelSamples.Name = "btnListLabelSamples";
            this.btnListLabelSamples.Size = new System.Drawing.Size(451, 41);
            this.btnListLabelSamples.TabIndex = 4;
            this.btnListLabelSamples.Text = "List && Label Integration: Create Data Source from IDataProvider";
            this.btnListLabelSamples.UseVisualStyleBackColor = true;
            this.btnListLabelSamples.Click += new System.EventHandler(this.btnListLabelSamples_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(451, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "List && Label Integration: Import Project with Dependencies";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 294);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnListLabelSamples);
            this.Controls.Add(this.btnManagedReportTasks);
            this.Controls.Add(this.btnManageDatasources);
            this.Controls.Add(this.btnManageReports);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Server ClientAPI Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageReports;
        private System.Windows.Forms.Button btnManageDatasources;
        private System.Windows.Forms.Button btnManagedReportTasks;
        private System.Windows.Forms.Button btnListLabelSamples;
        private System.Windows.Forms.Button button1;
    }
}