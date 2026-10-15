namespace C_
{
    partial class InputBox
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
            this.LabelPrompt = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TextBoxEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelPrompt
            // 
            this.LabelPrompt.AutoSize = true;
            this.LabelPrompt.Location = new System.Drawing.Point(12, 9);
            this.LabelPrompt.Name = "LabelPrompt";
            this.LabelPrompt.Size = new System.Drawing.Size(35, 13);
            this.LabelPrompt.TabIndex = 0;
            this.LabelPrompt.Text = "label1";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(323, 27);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(323, 56);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Abbrechen";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // TextBoxEntry
            // 
            this.TextBoxEntry.Location = new System.Drawing.Point(12, 100);
            this.TextBoxEntry.Name = "TextBoxEntry";
            this.TextBoxEntry.Size = new System.Drawing.Size(386, 20);
            this.TextBoxEntry.TabIndex = 3;
            this.TextBoxEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxEntry_KeyDown);
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 132);
            this.Controls.Add(this.TextBoxEntry);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.LabelPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.Shown += new System.EventHandler(this.InputBox_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelPrompt;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TextBox TextBoxEntry;
    }
}