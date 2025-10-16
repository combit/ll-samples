using combit.Reporting;

using System.Windows.Forms;

namespace DOMSimple
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
            Button3 = new Button();
            textBox2 = new TextBox();
            label9 = new Label();
            textBox1 = new TextBox();
            label8 = new Label();
            button2 = new Button();
            button1 = new Button();
            ListBox2 = new ListBox();
            ListBox1 = new ListBox();
            label7 = new Label();
            label6 = new Label();
            comboBoxTable = new ComboBox();
            label5 = new Label();
            button4 = new Button();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 23);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "D:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 23);
            label2.Name = "label2";
            label2.Size = new Size(396, 15);
            label2.TabIndex = 1;
            label2.Text = "Dieses Beispiel zeigt die dynamische Erstellung von List && Label Projekten.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 48);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 2;
            label3.Text = "US:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 48);
            label4.Name = "label4";
            label4.Size = new Size(348, 15);
            label4.TabIndex = 3;
            label4.Text = "This sample shows the dynamic creation of List && Label projects.";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Button3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(ListBox2);
            groupBox1.Controls.Add(ListBox1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(comboBoxTable);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(27, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(580, 387);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Project Layout";
            // 
            // Button3
            // 
            Button3.Location = new Point(533, 345);
            Button3.Name = "Button3";
            Button3.Size = new Size(31, 22);
            Button3.TabIndex = 12;
            Button3.Text = "...";
            Button3.UseVisualStyleBackColor = true;
            Button3.Click += Button3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(7, 345);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(518, 23);
            textBox2.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 327);
            label9.Name = "label9";
            label9.Size = new Size(37, 15);
            label9.TabIndex = 10;
            label9.Text = "Logo:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 288);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(557, 23);
            textBox1.TabIndex = 9;
            textBox1.Text = "Dynamically created project";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 270);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 8;
            label8.Text = "Title:";
            // 
            // button2
            // 
            button2.Location = new Point(264, 180);
            button2.Name = "button2";
            button2.Size = new Size(41, 35);
            button2.TabIndex = 7;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SelectField_Click;
            // 
            // button1
            // 
            button1.Location = new Point(264, 138);
            button1.Name = "button1";
            button1.Size = new Size(41, 35);
            button1.TabIndex = 6;
            button1.Text = ">";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SelectField_Click;
            // 
            // ListBox2
            // 
            ListBox2.FormattingEnabled = true;
            ListBox2.ItemHeight = 15;
            ListBox2.Location = new Point(312, 102);
            ListBox2.Name = "ListBox2";
            ListBox2.SelectionMode = SelectionMode.MultiSimple;
            ListBox2.Size = new Size(252, 139);
            ListBox2.Sorted = true;
            ListBox2.TabIndex = 5;
            ListBox2.MouseDoubleClick += ListBox2_MouseDoubleClick;
            // 
            // ListBox1
            // 
            ListBox1.FormattingEnabled = true;
            ListBox1.ItemHeight = 15;
            ListBox1.Location = new Point(7, 102);
            ListBox1.Name = "ListBox1";
            ListBox1.SelectionMode = SelectionMode.MultiSimple;
            ListBox1.Size = new Size(249, 139);
            ListBox1.Sorted = true;
            ListBox1.TabIndex = 4;
            ListBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(308, 83);
            label7.Name = "label7";
            label7.Size = new Size(87, 15);
            label7.TabIndex = 3;
            label7.Text = "Selected Fields:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 83);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 2;
            label6.Text = "Available Fields:";
            // 
            // comboBoxTable
            // 
            comboBoxTable.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTable.FormattingEnabled = true;
            comboBoxTable.Location = new Point(7, 46);
            comboBoxTable.Name = "comboBoxTable";
            comboBoxTable.Size = new Size(557, 23);
            comboBoxTable.TabIndex = 1;
            comboBoxTable.SelectedIndexChanged += ComboBoxTable_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 27);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 0;
            label5.Text = "Table:";
            // 
            // button4
            // 
            button4.Location = new Point(483, 464);
            button4.Name = "button4";
            button4.Size = new Size(124, 30);
            button4.TabIndex = 5;
            button4.Text = "Print...";
            button4.UseVisualStyleBackColor = true;
            button4.Click += PrintProject_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "sunshine.gif";
            openFileDialog1.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|All Files (*.*)|*.*";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 510);
            Controls.Add(button4);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "List & Label Cross Platform Simple DOM Sample";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal ListLabel LL;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private ComboBox comboBoxTable;
        private Label label5;
        private ListBox ListBox1;
        private Label label7;
        private Label label6;
        private Button button2;
        private Button button1;
        private ListBox ListBox2;
        private Button Button3;
        private TextBox textBox2;
        private Label label9;
        private TextBox textBox1;
        private Label label8;
        private Button button4;
        private OpenFileDialog openFileDialog1;
    }
}
