namespace ClientApiExample.Dialogs
{
    partial class DefineReportParameterDialog
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUseDefaultValue = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabUseSingleValue = new System.Windows.Forms.TabPage();
            this.txtSingleValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabUseMultipleValues = new System.Windows.Forms.TabPage();
            this.txtMultiValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabUseDateValue = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabUseDefaultValue.SuspendLayout();
            this.tabUseSingleValue.SuspendLayout();
            this.tabUseMultipleValues.SuspendLayout();
            this.tabUseDateValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(15, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(404, 22);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose a value type:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabUseDefaultValue);
            this.tabControl1.Controls.Add(this.tabUseSingleValue);
            this.tabControl1.Controls.Add(this.tabUseMultipleValues);
            this.tabControl1.Controls.Add(this.tabUseDateValue);
            this.tabControl1.Location = new System.Drawing.Point(16, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(403, 162);
            this.tabControl1.TabIndex = 3;
            // 
            // tabUseDefaultValue
            // 
            this.tabUseDefaultValue.Controls.Add(this.label6);
            this.tabUseDefaultValue.Location = new System.Drawing.Point(4, 22);
            this.tabUseDefaultValue.Name = "tabUseDefaultValue";
            this.tabUseDefaultValue.Padding = new System.Windows.Forms.Padding(3);
            this.tabUseDefaultValue.Size = new System.Drawing.Size(395, 136);
            this.tabUseDefaultValue.TabIndex = 3;
            this.tabUseDefaultValue.Text = "Use Default";
            this.tabUseDefaultValue.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(389, 130);
            this.label6.TabIndex = 0;
            this.label6.Text = "The default value for this report parameter will be used.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabUseSingleValue
            // 
            this.tabUseSingleValue.Controls.Add(this.txtSingleValue);
            this.tabUseSingleValue.Controls.Add(this.label4);
            this.tabUseSingleValue.Location = new System.Drawing.Point(4, 22);
            this.tabUseSingleValue.Name = "tabUseSingleValue";
            this.tabUseSingleValue.Padding = new System.Windows.Forms.Padding(3);
            this.tabUseSingleValue.Size = new System.Drawing.Size(395, 136);
            this.tabUseSingleValue.TabIndex = 0;
            this.tabUseSingleValue.Text = "Single Value";
            this.tabUseSingleValue.UseVisualStyleBackColor = true;
            // 
            // txtSingleValue
            // 
            this.txtSingleValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSingleValue.Location = new System.Drawing.Point(9, 30);
            this.txtSingleValue.Name = "txtSingleValue";
            this.txtSingleValue.Size = new System.Drawing.Size(380, 22);
            this.txtSingleValue.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Please enter a value (text or numeric):";
            // 
            // tabUseMultipleValues
            // 
            this.tabUseMultipleValues.Controls.Add(this.txtMultiValue);
            this.tabUseMultipleValues.Controls.Add(this.label5);
            this.tabUseMultipleValues.Location = new System.Drawing.Point(4, 22);
            this.tabUseMultipleValues.Name = "tabUseMultipleValues";
            this.tabUseMultipleValues.Padding = new System.Windows.Forms.Padding(3);
            this.tabUseMultipleValues.Size = new System.Drawing.Size(395, 136);
            this.tabUseMultipleValues.TabIndex = 1;
            this.tabUseMultipleValues.Text = "Multiple Values";
            this.tabUseMultipleValues.UseVisualStyleBackColor = true;
            // 
            // txtMultiValue
            // 
            this.txtMultiValue.AcceptsReturn = true;
            this.txtMultiValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMultiValue.Location = new System.Drawing.Point(9, 30);
            this.txtMultiValue.Multiline = true;
            this.txtMultiValue.Name = "txtMultiValue";
            this.txtMultiValue.Size = new System.Drawing.Size(380, 97);
            this.txtMultiValue.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Please enter one value per line:";
            // 
            // tabUseDateValue
            // 
            this.tabUseDateValue.Controls.Add(this.label3);
            this.tabUseDateValue.Controls.Add(this.dateTimePicker);
            this.tabUseDateValue.Location = new System.Drawing.Point(4, 22);
            this.tabUseDateValue.Name = "tabUseDateValue";
            this.tabUseDateValue.Padding = new System.Windows.Forms.Padding(3);
            this.tabUseDateValue.Size = new System.Drawing.Size(395, 136);
            this.tabUseDateValue.TabIndex = 2;
            this.tabUseDateValue.Text = "Date Value";
            this.tabUseDateValue.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Please select a date value:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.CustomFormat = "dd.MM.yyyy hh:mm:ss";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(9, 30);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(380, 22);
            this.dateTimePicker.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(344, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(263, 264);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DefineReportParameterDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(431, 299);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefineReportParameterDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Define Report Parameter";
            this.tabControl1.ResumeLayout(false);
            this.tabUseDefaultValue.ResumeLayout(false);
            this.tabUseSingleValue.ResumeLayout(false);
            this.tabUseSingleValue.PerformLayout();
            this.tabUseMultipleValues.ResumeLayout(false);
            this.tabUseMultipleValues.PerformLayout();
            this.tabUseDateValue.ResumeLayout(false);
            this.tabUseDateValue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUseSingleValue;
        private System.Windows.Forms.TextBox txtSingleValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabUseMultipleValues;
        private System.Windows.Forms.TextBox txtMultiValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabUseDateValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tabUseDefaultValue;
        private System.Windows.Forms.Label label6;
    }
}