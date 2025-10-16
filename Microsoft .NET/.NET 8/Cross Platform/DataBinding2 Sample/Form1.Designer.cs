using combit.Reporting;

namespace DataBinding2
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
            btnInvoiceItemsPrint = new Button();
            groupBox2 = new GroupBox();
            btnInvoiceMergePrint = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 25);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "D:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 72);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 1;
            label2.Text = "US:";
            // 
            // label3
            // 
            label3.Location = new Point(64, 25);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(466, 46);
            label3.TabIndex = 2;
            label3.Text = "Dieses Beispiel zeigt die Verwendung der Datenübergabe für die Print-Methode im datengebundenen Modus.";
            // 
            // label4
            // 
            label4.Location = new Point(64, 72);
            label4.Name = "label4";
            label4.Size = new Size(466, 33);
            label4.TabIndex = 3;
            label4.Text = "This sample shows the usage of databinding for Print method in the databind mode.";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnInvoiceItemsPrint);
            groupBox1.Location = new Point(64, 113);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(230, 74);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Invoice && Items List";
            // 
            // btnInvoiceItemsPrint
            // 
            btnInvoiceItemsPrint.Location = new Point(37, 28);
            btnInvoiceItemsPrint.Name = "btnInvoiceItemsPrint";
            btnInvoiceItemsPrint.Size = new Size(159, 27);
            btnInvoiceItemsPrint.TabIndex = 0;
            btnInvoiceItemsPrint.Text = "Print";
            btnInvoiceItemsPrint.UseVisualStyleBackColor = true;
            btnInvoiceItemsPrint.Click += btnInvoiceItemsPrint_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnInvoiceMergePrint);
            groupBox2.Location = new Point(300, 113);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(230, 74);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Invoice Merge";
            // 
            // btnInvoiceMergePrint
            // 
            btnInvoiceMergePrint.Location = new Point(37, 28);
            btnInvoiceMergePrint.Name = "btnInvoiceMergePrint";
            btnInvoiceMergePrint.Size = new Size(159, 27);
            btnInvoiceMergePrint.TabIndex = 0;
            btnInvoiceMergePrint.Text = "Print";
            btnInvoiceMergePrint.UseVisualStyleBackColor = true;
            btnInvoiceMergePrint.Click += btnInvoiceMergePrint_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 211);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "List & Label Cross Platform Databinding2 Sample";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private Button btnInvoiceItemsPrint;
        private GroupBox groupBox2;
        private Button btnInvoiceMergePrint;
    }
}
