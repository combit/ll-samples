namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Vom Windows Form-Designer generierter Code
        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textSourceFile = new System.Windows.Forms.TextBox();
            this.textTargetFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectTargetFile = new System.Windows.Forms.Button();
            this.selectSourceFile = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Convert Report";
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "US:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "D:  ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(421, 71);
            this.label4.TabIndex = 9;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(421, 70);
            this.label3.TabIndex = 8;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // textSourceFile
            // 
            this.textSourceFile.BackColor = System.Drawing.SystemColors.Window;
            this.textSourceFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textSourceFile.Location = new System.Drawing.Point(126, 180);
            this.textSourceFile.Name = "textSourceFile";
            this.textSourceFile.Size = new System.Drawing.Size(314, 20);
            this.textSourceFile.TabIndex = 12;
            this.textSourceFile.MouseEnter += new System.EventHandler(this.TextTargetFile_MouseEnter);
            this.textSourceFile.MouseLeave += new System.EventHandler(this.TextSourceFile_MouseLeave);
            // 
            // textTargetFile
            // 
            this.textTargetFile.BackColor = System.Drawing.SystemColors.Window;
            this.textTargetFile.Location = new System.Drawing.Point(126, 210);
            this.textTargetFile.Name = "textTargetFile";
            this.textTargetFile.Size = new System.Drawing.Size(314, 20);
            this.textTargetFile.TabIndex = 13;
            this.textTargetFile.MouseEnter += new System.EventHandler(this.TextTargetFile_MouseEnter);
            this.textTargetFile.MouseLeave += new System.EventHandler(this.TextSourceFile_MouseLeave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Report to convert:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Converted report:";
            // 
            // selectTargetFile
            // 
            this.selectTargetFile.Location = new System.Drawing.Point(446, 209);
            this.selectTargetFile.Name = "selectTargetFile";
            this.selectTargetFile.Size = new System.Drawing.Size(75, 24);
            this.selectTargetFile.TabIndex = 15;
            this.selectTargetFile.Text = "Select File...";
            this.selectTargetFile.Click += new System.EventHandler(this.SelectTargetFile_Click);
            // 
            // selectSourceFile
            // 
            this.selectSourceFile.Location = new System.Drawing.Point(446, 179);
            this.selectSourceFile.Name = "selectSourceFile";
            this.selectSourceFile.Size = new System.Drawing.Size(75, 23);
            this.selectSourceFile.TabIndex = 14;
            this.selectSourceFile.Text = "Select File...";
            this.selectSourceFile.Click += new System.EventHandler(this.SelectSourceFile_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 275);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectTargetFile);
            this.Controls.Add(this.selectSourceFile);
            this.Controls.Add(this.textTargetFile);
            this.Controls.Add(this.textSourceFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "List & Label RDL Converter Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSourceFile;
        private System.Windows.Forms.TextBox textTargetFile;
        private System.Windows.Forms.Button selectSourceFile;
        private System.Windows.Forms.Button selectTargetFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
