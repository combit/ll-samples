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
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.textSourceFile = new MetroFramework.Controls.MetroTextBox();
            this.textTargetFile = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.selectTargetFile = new MetroFramework.Controls.MetroButton();
            this.selectSourceFile = new MetroFramework.Controls.MetroButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Convert Report";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(22, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "US:";
            // 
            // label5
            // 
            this.label5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(22, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "D:  ";
            // 
            // label4
            // 
            this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(52, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(421, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "This sample shows the usage of the RDL Reports converter class.";
            // 
            // label3
            // 
            this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(52, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(421, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dieses Beispiel zeigt die Verwendung der RDL Reports Konverter Klasse.";
            // 
            // textSourceFile
            // 
            this.textSourceFile.BackColor = System.Drawing.SystemColors.Window;
            this.textSourceFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textSourceFile.Lines = new string[0];
            this.textSourceFile.Location = new System.Drawing.Point(135, 114);
            this.textSourceFile.MaxLength = 32767;
            this.textSourceFile.Name = "textSourceFile";
            this.textSourceFile.PasswordChar = '\0';
            this.textSourceFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textSourceFile.SelectedText = "";
            this.textSourceFile.Size = new System.Drawing.Size(314, 20);
            this.textSourceFile.TabIndex = 12;
            this.textSourceFile.UseCustomBackColor = true;
            this.textSourceFile.UseSelectable = true;
            this.textSourceFile.MouseEnter += new System.EventHandler(this.TextTargetFile_MouseEnter);
            this.textSourceFile.MouseLeave += new System.EventHandler(this.TextSourceFile_MouseLeave);
            // 
            // textTargetFile
            // 
            this.textTargetFile.BackColor = System.Drawing.SystemColors.Window;
            this.textTargetFile.Lines = new string[0];
            this.textTargetFile.Location = new System.Drawing.Point(135, 144);
            this.textTargetFile.MaxLength = 32767;
            this.textTargetFile.Name = "textTargetFile";
            this.textTargetFile.PasswordChar = '\0';
            this.textTargetFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textTargetFile.SelectedText = "";
            this.textTargetFile.Size = new System.Drawing.Size(314, 20);
            this.textTargetFile.TabIndex = 13;
            this.textTargetFile.UseCustomBackColor = true;
            this.textTargetFile.UseSelectable = true;
            this.textTargetFile.MouseEnter += new System.EventHandler(this.TextTargetFile_MouseEnter);
            this.textTargetFile.MouseLeave += new System.EventHandler(this.TextSourceFile_MouseLeave);
            // 
            // label2
            // 
            this.label2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(22, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Report to convert:";
            // 
            // label6
            // 
            this.label6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(22, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Converted report:";
            // 
            // selectTargetFile
            // 
            this.selectTargetFile.Location = new System.Drawing.Point(455, 143);
            this.selectTargetFile.Name = "selectTargetFile";
            this.selectTargetFile.Size = new System.Drawing.Size(75, 24);
            this.selectTargetFile.TabIndex = 15;
            this.selectTargetFile.Text = "Select File...";
            this.selectTargetFile.UseSelectable = true;
            this.selectTargetFile.Click += new System.EventHandler(this.SelectTargetFile_Click);
            // 
            // selectSourceFile
            // 
            this.selectSourceFile.Location = new System.Drawing.Point(455, 113);
            this.selectSourceFile.Name = "selectSourceFile";
            this.selectSourceFile.Size = new System.Drawing.Size(75, 23);
            this.selectSourceFile.TabIndex = 14;
            this.selectSourceFile.Text = "Select File...";
            this.selectSourceFile.UseSelectable = true;
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
            this.ClientSize = new System.Drawing.Size(553, 212);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# RDL Converter Sample";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroTextBox textSourceFile;
        private MetroFramework.Controls.MetroTextBox textTargetFile;
        private MetroFramework.Controls.MetroButton selectSourceFile;
        private MetroFramework.Controls.MetroButton selectTargetFile;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroLabel label6;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

