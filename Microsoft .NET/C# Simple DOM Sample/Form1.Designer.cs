namespace DOMSimple
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.LL = new combit.ListLabel24.ListLabel(this.components);
            this.comboBoxTable = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.button3 = new MetroFramework.Controls.MetroButton();
            this.textBox2 = new MetroFramework.Controls.MetroTextBox();
            this.label10 = new MetroFramework.Controls.MetroLabel();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.label9 = new MetroFramework.Controls.MetroLabel();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label7 = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.button4 = new MetroFramework.Controls.MetroButton();
            this.button5 = new MetroFramework.Controls.MetroButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(52, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(379, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dieses Beispiel zeigt die dynamische Erstellung von List && Label Projekten.";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(23, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "US:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(52, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(379, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "This sample shows the dynamic creation of List && Label projects.";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(23, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "D:  ";
            // 
            // LL
            // 
            this.LL.AutoDestination = combit.ListLabel24.LlPrintMode.Preview;
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.AutoShowPrintOptions = false;
            this.LL.AutoShowSelectFile = false;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_10;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.comboBoxTable.ItemHeight = 19;
            this.comboBoxTable.Location = new System.Drawing.Point(6, 40);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(478, 25);
            this.comboBoxTable.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboBoxTable.TabIndex = 9;
            this.comboBoxTable.UseSelectable = true;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTable_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxTable);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 335);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Layout";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Table:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(457, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 19);
            this.button3.TabIndex = 20;
            this.button3.Text = "...";
            this.button3.UseSelectable = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(6, 299);
            this.textBox2.MaxLength = 32767;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.Size = new System.Drawing.Size(445, 20);
            this.textBox2.TabIndex = 19;
            this.textBox2.UseCustomBackColor = true;
            this.textBox2.UseSelectable = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label10.Location = new System.Drawing.Point(6, 283);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "Logo:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Lines = new string[] {
        "Dynamically created project"};
            this.textBox1.Location = new System.Drawing.Point(6, 250);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.Size = new System.Drawing.Size(478, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Dynamically created project";
            this.textBox1.UseCustomBackColor = true;
            this.textBox1.UseSelectable = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label9.Location = new System.Drawing.Point(6, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Title:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 30);
            this.button2.TabIndex = 15;
            this.button2.Text = "<";
            this.button2.UseSelectable = true;
            this.button2.Click += new System.EventHandler(this.SelectField_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = ">";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.SelectField_Click);
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.Location = new System.Drawing.Point(267, 88);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(217, 132);
            this.listBox2.Sorted = true;
            this.listBox2.TabIndex = 13;
            this.listBox2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox2_DrawItem);
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox2_MouseDoubleClick);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.Location = new System.Drawing.Point(6, 88);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(214, 132);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 12;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label7.Location = new System.Drawing.Point(264, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Selected Fields:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Available Fields:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(414, 442);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 26);
            this.button4.TabIndex = 12;
            this.button4.Text = "Preview...";
            this.button4.UseSelectable = true;
            this.button4.Click += new System.EventHandler(this.PrintProject_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(302, 442);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 26);
            this.button5.TabIndex = 13;
            this.button5.Text = "Design...";
            this.button5.UseSelectable = true;
            this.button5.Click += new System.EventHandler(this.DesignProject_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "sunshine.gif";
            this.openFileDialog1.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|A" +
    "ll Files (*.*)|*.*";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(549, 488);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# Simple DOM Sample";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel label1;
        private combit.ListLabel24.ListLabel LL;
        private MetroFramework.Controls.MetroComboBox comboBoxTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel label7;
        private MetroFramework.Controls.MetroLabel label6;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton button1;
        private System.Windows.Forms.ListBox listBox2;
        private MetroFramework.Controls.MetroLabel label10;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroLabel label9;
        private MetroFramework.Controls.MetroButton button3;
        private MetroFramework.Controls.MetroTextBox textBox2;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroButton button4;
        private MetroFramework.Controls.MetroButton button5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        #endregion
    }
}
