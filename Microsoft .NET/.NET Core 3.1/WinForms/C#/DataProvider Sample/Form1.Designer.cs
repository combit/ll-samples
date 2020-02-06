namespace combit.ListLabel25.Samples
{
    partial class Form1
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
            this.designBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.printBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // designBtn
            // 
            this.designBtn.Location = new System.Drawing.Point(333, 99);
            this.designBtn.Name = "designBtn";
            this.designBtn.Size = new System.Drawing.Size(75, 23);
            this.designBtn.TabIndex = 0;
            this.designBtn.Text = "Design...";
            this.designBtn.Click += new System.EventHandler(this.DesignBtn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "US:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "D:  ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(53, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(436, 38);
            this.label4.TabIndex = 13;
            this.label4.Text = "This sample shows how to implement the IDataProvider interface. By implementing t" +
    "his interface you can bind to arbitrary data sources.";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(53, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(436, 41);
            this.label3.TabIndex = 12;
            this.label3.Text = "Dieses Beispiel demonstriert die Implementierung des IDataProvider-Interfaces. Üb" +
    "er dieses Interface können eigene Datenquellen angebunden werden.";
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(414, 99);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 16;
            this.printBtn.Text = "Print...";
            this.printBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(507, 137);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.designBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "List & Label C# Custom Data Provider Sample";
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button designBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button printBtn;
    }
}
