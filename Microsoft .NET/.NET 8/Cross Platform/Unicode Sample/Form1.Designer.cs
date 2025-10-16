using combit.Reporting;

namespace Unicode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            rbList = new RadioButton();
            rbLabel = new RadioButton();
            Button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 22);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "D:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 22);
            label2.Name = "label2";
            label2.Size = new Size(272, 15);
            label2.TabIndex = 1;
            label2.Text = "Dieses Beispiel zeigt die Verwendung von Unicode.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 51);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 2;
            label3.Text = "US:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 51);
            label4.Name = "label4";
            label4.Size = new Size(217, 15);
            label4.TabIndex = 3;
            label4.Text = "This sample shows how to use Unicode.";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbList);
            groupBox1.Controls.Add(rbLabel);
            groupBox1.Location = new Point(27, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 81);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Project type";
            // 
            // rbList
            // 
            rbList.AutoSize = true;
            rbList.Location = new Point(9, 47);
            rbList.Name = "rbList";
            rbList.Size = new Size(43, 19);
            rbList.TabIndex = 1;
            rbList.TabStop = true;
            rbList.Text = "List";
            rbList.UseVisualStyleBackColor = true;
            // 
            // rbLabel
            // 
            rbLabel.AutoSize = true;
            rbLabel.Location = new Point(9, 22);
            rbLabel.Name = "rbLabel";
            rbLabel.Size = new Size(53, 19);
            rbLabel.TabIndex = 0;
            rbLabel.TabStop = true;
            rbLabel.Text = "Label";
            rbLabel.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            Button1.Location = new Point(246, 138);
            Button1.Name = "Button1";
            Button1.Size = new Size(88, 27);
            Button1.TabIndex = 5;
            Button1.Text = "Print...";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 182);
            Controls.Add(Button1);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "List & Label Cross Platform Unicode Sample";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private RadioButton rbList;
        private RadioButton rbLabel;
        private Button Button1;
    }
}
