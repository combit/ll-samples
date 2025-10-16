using combit.Reporting;
using System.Globalization;
namespace DataBinding
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
            tabControl = new System.Windows.Forms.TabControl();
            tpDataSet = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            print_DataSet = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            tpXML = new System.Windows.Forms.TabPage();
            panel5 = new System.Windows.Forms.Panel();
            print_XML = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            tpDataViewManager = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            cbCustomerNames = new System.Windows.Forms.ComboBox();
            print_DataViewManager = new System.Windows.Forms.Button();
            label21 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            tpDataView = new System.Windows.Forms.TabPage();
            panel4 = new System.Windows.Forms.Panel();
            print_DataView = new System.Windows.Forms.Button();
            label20 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            tpDbCommand = new System.Windows.Forms.TabPage();
            panel6 = new System.Windows.Forms.Panel();
            print_Reader = new System.Windows.Forms.Button();
            label12 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            tpDataTable = new System.Windows.Forms.TabPage();
            panel7 = new System.Windows.Forms.Panel();
            print_DataTable = new System.Windows.Forms.Button();
            label16 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label99 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            tpGenericList = new System.Windows.Forms.TabPage();
            panel8 = new System.Windows.Forms.Panel();
            print_GenericList = new System.Windows.Forms.Button();
            label79 = new System.Windows.Forms.Label();
            label77 = new System.Windows.Forms.Label();
            label76 = new System.Windows.Forms.Label();
            label78 = new System.Windows.Forms.Label();
            tabSQLServer = new System.Windows.Forms.TabPage();
            panel9 = new System.Windows.Forms.Panel();
            label115 = new System.Windows.Forms.Label();
            print_SQL = new System.Windows.Forms.Button();
            label111 = new System.Windows.Forms.Label();
            label114 = new System.Windows.Forms.Label();
            label113 = new System.Windows.Forms.Label();
            label112 = new System.Windows.Forms.Label();
            tbConnectionString = new System.Windows.Forms.TextBox();
            tabOdata = new System.Windows.Forms.TabPage();
            panel10 = new System.Windows.Forms.Panel();
            label116 = new System.Windows.Forms.Label();
            printOdataBtn = new System.Windows.Forms.Button();
            label117 = new System.Windows.Forms.Label();
            odataUrlTb = new System.Windows.Forms.TextBox();
            label119 = new System.Windows.Forms.Label();
            label120 = new System.Windows.Forms.Label();
            label118 = new System.Windows.Forms.Label();
            tabRest = new System.Windows.Forms.TabPage();
            panel11 = new System.Windows.Forms.Panel();
            label206 = new System.Windows.Forms.Label();
            restPrintBtn = new System.Windows.Forms.Button();
            label202 = new System.Windows.Forms.Label();
            label205 = new System.Windows.Forms.Label();
            label204 = new System.Windows.Forms.Label();
            label203 = new System.Windows.Forms.Label();
            restUrlTb = new System.Windows.Forms.TextBox();
            tabPage1 = new System.Windows.Forms.TabPage();
            comboBox1 = new System.Windows.Forms.ComboBox();
            comboBox2 = new System.Windows.Forms.ComboBox();
            comboBox3 = new System.Windows.Forms.ComboBox();
            comboBox4 = new System.Windows.Forms.ComboBox();
            comboBox5 = new System.Windows.Forms.ComboBox();
            textBox3 = new System.Windows.Forms.TextBox();
            tabPage37 = new System.Windows.Forms.TabPage();
            textBox4 = new System.Windows.Forms.TextBox();
            tabControl.SuspendLayout();
            tpDataSet.SuspendLayout();
            panel2.SuspendLayout();
            tpXML.SuspendLayout();
            panel5.SuspendLayout();
            tpDataViewManager.SuspendLayout();
            panel3.SuspendLayout();
            tpDataView.SuspendLayout();
            panel4.SuspendLayout();
            tpDbCommand.SuspendLayout();
            panel6.SuspendLayout();
            tpDataTable.SuspendLayout();
            panel7.SuspendLayout();
            tpGenericList.SuspendLayout();
            panel8.SuspendLayout();
            tabSQLServer.SuspendLayout();
            panel9.SuspendLayout();
            tabOdata.SuspendLayout();
            panel10.SuspendLayout();
            tabRest.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tpDataSet);
            tabControl.Controls.Add(tpXML);
            tabControl.Controls.Add(tpDataViewManager);
            tabControl.Controls.Add(tpDataView);
            tabControl.Controls.Add(tpDbCommand);
            tabControl.Controls.Add(tpDataTable);
            tabControl.Controls.Add(tpGenericList);
            tabControl.Controls.Add(tabSQLServer);
            tabControl.Controls.Add(tabOdata);
            tabControl.Controls.Add(tabRest);
            tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Margin = new System.Windows.Forms.Padding(4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(918, 144);
            tabControl.TabIndex = 8;
            tabControl.TabPages.Remove(tabRest);
            // 
            // tpDataSet
            // 
            tpDataSet.Controls.Add(panel2);
            tpDataSet.Location = new System.Drawing.Point(4, 24);
            tpDataSet.Margin = new System.Windows.Forms.Padding(4);
            tpDataSet.Name = "tpDataSet";
            tpDataSet.Size = new System.Drawing.Size(910, 116);
            tpDataSet.TabIndex = 0;
            tpDataSet.Text = "DataSet";
            tpDataSet.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel2.Controls.Add(print_DataSet);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label6);
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(936, 113);
            panel2.TabIndex = 18;
            // 
            // print_DataSet
            // 
            print_DataSet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            print_DataSet.Location = new System.Drawing.Point(741, 59);
            print_DataSet.Margin = new System.Windows.Forms.Padding(4);
            print_DataSet.Name = "print_DataSet";
            print_DataSet.Size = new System.Drawing.Size(131, 28);
            print_DataSet.TabIndex = 17;
            print_DataSet.Text = "&Print";
            print_DataSet.Click += Print_DataSet_Click;
            // 
            // label8
            // 
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label8.Location = new System.Drawing.Point(38, 17);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(358, 28);
            label8.TabIndex = 12;
            label8.Text = "Bindet die Komponente an ein dynamisch erstelltes DataSet-Objekt mit DataRelations.";
            // 
            // label7
            // 
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(439, 17);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(411, 21);
            label7.TabIndex = 13;
            label7.Text = "Binds the component to a dynamically created DataSet containing DataRelations.";
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(404, 17);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(28, 28);
            label2.TabIndex = 14;
            label2.Text = "US:";
            // 
            // label6
            // 
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(4, 17);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(28, 19);
            label6.TabIndex = 15;
            label6.Text = "D:";
            // 
            // tpXML
            // 
            tpXML.Controls.Add(panel5);
            tpXML.Location = new System.Drawing.Point(4, 24);
            tpXML.Margin = new System.Windows.Forms.Padding(4);
            tpXML.Name = "tpXML";
            tpXML.Size = new System.Drawing.Size(910, 116);
            tpXML.TabIndex = 5;
            tpXML.Text = "XML";
            tpXML.UseVisualStyleBackColor = true;
            tpXML.Visible = false;
            // 
            // panel5
            // 
            panel5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel5.Controls.Add(print_XML);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(label4);
            panel5.Location = new System.Drawing.Point(0, 0);
            panel5.Margin = new System.Windows.Forms.Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(936, 113);
            panel5.TabIndex = 22;
            // 
            // print_XML
            // 
            print_XML.Anchor = System.Windows.Forms.AnchorStyles.Right;
            print_XML.Location = new System.Drawing.Point(741, 59);
            print_XML.Margin = new System.Windows.Forms.Padding(4);
            print_XML.Name = "print_XML";
            print_XML.Size = new System.Drawing.Size(131, 28);
            print_XML.TabIndex = 21;
            print_XML.Text = "&Print";
            print_XML.Click += Print_XML_Click;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(4, 17);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(28, 19);
            label3.TabIndex = 19;
            label3.Text = "D:";
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(404, 17);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(28, 19);
            label1.TabIndex = 18;
            label1.Text = "US:";
            // 
            // label5
            // 
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(38, 17);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(358, 37);
            label5.TabIndex = 16;
            label5.Text = "Bindet die Komponente an die Beispiel XML-Datei.";
            // 
            // label4
            // 
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(439, 17);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(436, 37);
            label4.TabIndex = 17;
            label4.Text = "Binds the component to the sample XML file.";
            // 
            // tpDataViewManager
            // 
            tpDataViewManager.Controls.Add(panel3);
            tpDataViewManager.Location = new System.Drawing.Point(4, 24);
            tpDataViewManager.Margin = new System.Windows.Forms.Padding(4);
            tpDataViewManager.Name = "tpDataViewManager";
            tpDataViewManager.Size = new System.Drawing.Size(910, 116);
            tpDataViewManager.TabIndex = 6;
            tpDataViewManager.Text = "DataViewManager";
            tpDataViewManager.UseVisualStyleBackColor = true;
            tpDataViewManager.Visible = false;
            // 
            // panel3
            // 
            panel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel3.Controls.Add(cbCustomerNames);
            panel3.Controls.Add(print_DataViewManager);
            panel3.Controls.Add(label21);
            panel3.Controls.Add(label23);
            panel3.Controls.Add(label22);
            panel3.Controls.Add(label24);
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Margin = new System.Windows.Forms.Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(936, 113);
            panel3.TabIndex = 33;
            // 
            // cbCustomerNames
            // 
            cbCustomerNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbCustomerNames.ItemHeight = 13;
            cbCustomerNames.Location = new System.Drawing.Point(38, 59);
            cbCustomerNames.Margin = new System.Windows.Forms.Padding(4);
            cbCustomerNames.Name = "cbCustomerNames";
            cbCustomerNames.Size = new System.Drawing.Size(345, 21);
            cbCustomerNames.TabIndex = 32;
            // 
            // print_DataViewManager
            // 
            print_DataViewManager.Anchor = System.Windows.Forms.AnchorStyles.Right;
            print_DataViewManager.Location = new System.Drawing.Point(741, 59);
            print_DataViewManager.Margin = new System.Windows.Forms.Padding(4);
            print_DataViewManager.Name = "print_DataViewManager";
            print_DataViewManager.Size = new System.Drawing.Size(131, 28);
            print_DataViewManager.TabIndex = 31;
            print_DataViewManager.Text = "&Print";
            print_DataViewManager.Click += Print_DataViewManager_Click;
            // 
            // label21
            // 
            label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label21.Location = new System.Drawing.Point(404, 17);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(28, 28);
            label21.TabIndex = 28;
            label21.Text = "US:";
            // 
            // label23
            // 
            label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label23.Location = new System.Drawing.Point(439, 17);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(436, 37);
            label23.TabIndex = 27;
            label23.Text = "Binds the component to a DataView object. Choose a filter for the company name.";
            // 
            // label22
            // 
            label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label22.Location = new System.Drawing.Point(4, 17);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(28, 28);
            label22.TabIndex = 29;
            label22.Text = "D:";
            // 
            // label24
            // 
            label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label24.Location = new System.Drawing.Point(38, 17);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(358, 46);
            label24.TabIndex = 26;
            label24.Text = "Bindet die Komponente an ein DataViewManager-Objekt. Sie können einen Filter für den Firmennamen wählen.";
            // 
            // tpDataView
            // 
            tpDataView.Controls.Add(panel4);
            tpDataView.Location = new System.Drawing.Point(4, 24);
            tpDataView.Margin = new System.Windows.Forms.Padding(4);
            tpDataView.Name = "tpDataView";
            tpDataView.Size = new System.Drawing.Size(910, 116);
            tpDataView.TabIndex = 3;
            tpDataView.Text = "DataView";
            tpDataView.UseVisualStyleBackColor = true;
            tpDataView.Visible = false;
            // 
            // panel4
            // 
            panel4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel4.Controls.Add(print_DataView);
            panel4.Controls.Add(label20);
            panel4.Controls.Add(label17);
            panel4.Controls.Add(label18);
            panel4.Controls.Add(label19);
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Margin = new System.Windows.Forms.Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(936, 113);
            panel4.TabIndex = 26;
            // 
            // print_DataView
            // 
            print_DataView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            print_DataView.Location = new System.Drawing.Point(741, 59);
            print_DataView.Margin = new System.Windows.Forms.Padding(4);
            print_DataView.Name = "print_DataView";
            print_DataView.Size = new System.Drawing.Size(131, 28);
            print_DataView.TabIndex = 25;
            print_DataView.Text = "&Print";
            print_DataView.Click += Print_DataView_Click;
            // 
            // label20
            // 
            label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label20.Location = new System.Drawing.Point(38, 17);
            label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(358, 37);
            label20.TabIndex = 16;
            label20.Text = "Bindet die Komponente an ein DataView-Objekt.";
            // 
            // label17
            // 
            label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label17.Location = new System.Drawing.Point(404, 17);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(28, 19);
            label17.TabIndex = 18;
            label17.Text = "US:";
            // 
            // label18
            // 
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label18.Location = new System.Drawing.Point(4, 17);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(28, 19);
            label18.TabIndex = 19;
            label18.Text = "D:";
            // 
            // label19
            // 
            label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label19.Location = new System.Drawing.Point(439, 17);
            label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(436, 37);
            label19.TabIndex = 17;
            label19.Text = "Binds the component to a DataView object.";
            // 
            // tpDbCommand
            // 
            tpDbCommand.Controls.Add(panel6);
            tpDbCommand.Location = new System.Drawing.Point(4, 24);
            tpDbCommand.Margin = new System.Windows.Forms.Padding(4);
            tpDbCommand.Name = "tpDbCommand";
            tpDbCommand.Size = new System.Drawing.Size(910, 116);
            tpDbCommand.TabIndex = 1;
            tpDbCommand.Text = "DbCommand";
            tpDbCommand.UseVisualStyleBackColor = true;
            tpDbCommand.Visible = false;
            // 
            // panel6
            // 
            panel6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel6.Controls.Add(print_Reader);
            panel6.Controls.Add(label12);
            panel6.Controls.Add(label9);
            panel6.Controls.Add(label10);
            panel6.Controls.Add(label11);
            panel6.Location = new System.Drawing.Point(0, 0);
            panel6.Margin = new System.Windows.Forms.Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(936, 113);
            panel6.TabIndex = 25;
            // 
            // print_Reader
            // 
            print_Reader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            print_Reader.Location = new System.Drawing.Point(741, 59);
            print_Reader.Margin = new System.Windows.Forms.Padding(4);
            print_Reader.Name = "print_Reader";
            print_Reader.Size = new System.Drawing.Size(131, 28);
            print_Reader.TabIndex = 23;
            print_Reader.Text = "&Print";
            print_Reader.Click += Print_Reader_Click;
            // 
            // label12
            // 
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label12.Location = new System.Drawing.Point(38, 17);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(358, 37);
            label12.TabIndex = 24;
            label12.Text = "Bindet die Komponente an ein OleDbCommand-Objekt.";
            // 
            // label9
            // 
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(404, 17);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(28, 19);
            label9.TabIndex = 18;
            label9.Text = "US:";
            // 
            // label10
            // 
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label10.Location = new System.Drawing.Point(4, 17);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(28, 19);
            label10.TabIndex = 19;
            label10.Text = "D:";
            // 
            // label11
            // 
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label11.Location = new System.Drawing.Point(439, 17);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(436, 37);
            label11.TabIndex = 17;
            label11.Text = "Binds the component to an OleDbCommand object.";
            // 
            // tpDataTable
            // 
            tpDataTable.Controls.Add(panel7);
            tpDataTable.Location = new System.Drawing.Point(4, 24);
            tpDataTable.Margin = new System.Windows.Forms.Padding(4);
            tpDataTable.Name = "tpDataTable";
            tpDataTable.Size = new System.Drawing.Size(910, 116);
            tpDataTable.TabIndex = 2;
            tpDataTable.Text = "DataTable";
            tpDataTable.UseVisualStyleBackColor = true;
            tpDataTable.Visible = false;
            // 
            // panel7
            // 
            panel7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel7.Controls.Add(print_DataTable);
            panel7.Controls.Add(label16);
            panel7.Controls.Add(label13);
            panel7.Controls.Add(label99);
            panel7.Controls.Add(label15);
            panel7.Location = new System.Drawing.Point(0, 0);
            panel7.Margin = new System.Windows.Forms.Padding(4);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(936, 113);
            panel7.TabIndex = 28;
            // 
            // print_DataTable
            // 
            print_DataTable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            print_DataTable.Location = new System.Drawing.Point(741, 59);
            print_DataTable.Margin = new System.Windows.Forms.Padding(4);
            print_DataTable.Name = "print_DataTable";
            print_DataTable.Size = new System.Drawing.Size(131, 28);
            print_DataTable.TabIndex = 27;
            print_DataTable.Text = "&Print";
            print_DataTable.Click += Print_DataTable_Click;
            // 
            // label16
            // 
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label16.Location = new System.Drawing.Point(38, 17);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(358, 22);
            label16.TabIndex = 16;
            label16.Text = "Bindet die Komponente an ein DataTable-Objekt.";
            // 
            // label13
            // 
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label13.Location = new System.Drawing.Point(404, 17);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(28, 19);
            label13.TabIndex = 18;
            label13.Text = "US:";
            // 
            // label99
            // 
            label99.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label99.Location = new System.Drawing.Point(4, 17);
            label99.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label99.Name = "label99";
            label99.Size = new System.Drawing.Size(28, 19);
            label99.TabIndex = 19;
            label99.Text = "D:";
            // 
            // label15
            // 
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label15.Location = new System.Drawing.Point(439, 17);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(436, 22);
            label15.TabIndex = 17;
            label15.Text = "Binds the component to a DataTable object.";
            // 
            // tpGenericList
            // 
            tpGenericList.Controls.Add(panel8);
            tpGenericList.Location = new System.Drawing.Point(4, 24);
            tpGenericList.Margin = new System.Windows.Forms.Padding(4);
            tpGenericList.Name = "tpGenericList";
            tpGenericList.Padding = new System.Windows.Forms.Padding(4);
            tpGenericList.Size = new System.Drawing.Size(910, 116);
            tpGenericList.TabIndex = 7;
            tpGenericList.Text = "Generic List";
            tpGenericList.UseVisualStyleBackColor = true;
            tpGenericList.Visible = false;
            // 
            // panel8
            // 
            panel8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel8.Controls.Add(print_GenericList);
            panel8.Controls.Add(label79);
            panel8.Controls.Add(label77);
            panel8.Controls.Add(label76);
            panel8.Controls.Add(label78);
            panel8.Location = new System.Drawing.Point(0, 0);
            panel8.Margin = new System.Windows.Forms.Padding(4);
            panel8.Name = "panel8";
            panel8.Size = new System.Drawing.Size(936, 113);
            panel8.TabIndex = 30;
            // 
            // print_GenericList
            // 
            print_GenericList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            print_GenericList.Location = new System.Drawing.Point(741, 59);
            print_GenericList.Margin = new System.Windows.Forms.Padding(4);
            print_GenericList.Name = "print_GenericList";
            print_GenericList.Size = new System.Drawing.Size(131, 28);
            print_GenericList.TabIndex = 29;
            print_GenericList.Text = "&Print";
            print_GenericList.Click += Print_GenericList_Click;
            // 
            // label79
            // 
            label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label79.Location = new System.Drawing.Point(38, 17);
            label79.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label79.Name = "label79";
            label79.Size = new System.Drawing.Size(358, 19);
            label79.TabIndex = 20;
            label79.Text = "Bindet die Komponente an eine generische Liste.";
            // 
            // label77
            // 
            label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label77.Location = new System.Drawing.Point(4, 17);
            label77.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label77.Name = "label77";
            label77.Size = new System.Drawing.Size(28, 19);
            label77.TabIndex = 24;
            label77.Text = "D:";
            // 
            // label76
            // 
            label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label76.Location = new System.Drawing.Point(404, 17);
            label76.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label76.Name = "label76";
            label76.Size = new System.Drawing.Size(28, 19);
            label76.TabIndex = 23;
            label76.Text = "US:";
            // 
            // label78
            // 
            label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label78.Location = new System.Drawing.Point(439, 17);
            label78.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label78.Name = "label78";
            label78.Size = new System.Drawing.Size(391, 19);
            label78.TabIndex = 21;
            label78.Text = "Binds the component to a generic list.";
            // 
            // tabSQLServer
            // 
            tabSQLServer.Controls.Add(panel9);
            tabSQLServer.Location = new System.Drawing.Point(4, 24);
            tabSQLServer.Margin = new System.Windows.Forms.Padding(4);
            tabSQLServer.Name = "tabSQLServer";
            tabSQLServer.Padding = new System.Windows.Forms.Padding(4);
            tabSQLServer.Size = new System.Drawing.Size(910, 116);
            tabSQLServer.TabIndex = 8;
            tabSQLServer.Text = "SQL Server";
            tabSQLServer.UseVisualStyleBackColor = true;
            tabSQLServer.Visible = false;
            // 
            // panel9
            // 
            panel9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel9.Controls.Add(label115);
            panel9.Controls.Add(print_SQL);
            panel9.Controls.Add(label111);
            panel9.Controls.Add(label114);
            panel9.Controls.Add(label113);
            panel9.Controls.Add(label112);
            panel9.Controls.Add(tbConnectionString);
            panel9.Location = new System.Drawing.Point(0, 0);
            panel9.Margin = new System.Windows.Forms.Padding(4);
            panel9.Name = "panel9";
            panel9.Size = new System.Drawing.Size(901, 113);
            panel9.TabIndex = 35;
            // 
            // label115
            // 
            label115.AutoSize = true;
            label115.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label115.Location = new System.Drawing.Point(4, 63);
            label115.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label115.Name = "label115";
            label115.Size = new System.Drawing.Size(97, 13);
            label115.TabIndex = 34;
            label115.Text = "Connection-String: ";
            // 
            // print_SQL
            // 
            print_SQL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            print_SQL.Location = new System.Drawing.Point(741, 59);
            print_SQL.Margin = new System.Windows.Forms.Padding(4);
            print_SQL.Name = "print_SQL";
            print_SQL.Size = new System.Drawing.Size(131, 28);
            print_SQL.TabIndex = 33;
            print_SQL.Text = "&Print";
            print_SQL.Click += Print_SQL_Click;
            // 
            // label111
            // 
            label111.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label111.Location = new System.Drawing.Point(404, 17);
            label111.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label111.Name = "label111";
            label111.Size = new System.Drawing.Size(28, 19);
            label111.TabIndex = 27;
            label111.Text = "US:";
            // 
            // label114
            // 
            label114.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label114.Location = new System.Drawing.Point(38, 17);
            label114.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label114.Name = "label114";
            label114.Size = new System.Drawing.Size(330, 19);
            label114.TabIndex = 25;
            label114.Text = "Bindet die Komponente an einen SqlConnectionDataProvider.";
            // 
            // label113
            // 
            label113.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label113.Location = new System.Drawing.Point(439, 17);
            label113.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label113.Name = "label113";
            label113.Size = new System.Drawing.Size(435, 19);
            label113.TabIndex = 26;
            label113.Text = "Binds the component to a SqlConnectionDataProvider.";
            // 
            // label112
            // 
            label112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label112.Location = new System.Drawing.Point(4, 17);
            label112.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label112.Name = "label112";
            label112.Size = new System.Drawing.Size(28, 19);
            label112.TabIndex = 28;
            label112.Text = "D:";
            // 
            // tbConnectionString
            // 
            tbConnectionString.BackColor = System.Drawing.SystemColors.Window;
            tbConnectionString.Location = new System.Drawing.Point(99, 59);
            tbConnectionString.Margin = new System.Windows.Forms.Padding(4);
            tbConnectionString.Name = "tbConnectionString";
            tbConnectionString.Size = new System.Drawing.Size(564, 23);
            tbConnectionString.TabIndex = 29;
            tbConnectionString.Text = "Data Source=<ComputerName>\\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated Security=True;Encrypt=False;";
            tbConnectionString.WordWrap = false;
            // 
            // tabOdata
            // 
            tabOdata.Controls.Add(panel10);
            tabOdata.Location = new System.Drawing.Point(4, 24);
            tabOdata.Margin = new System.Windows.Forms.Padding(4);
            tabOdata.Name = "tabOdata";
            tabOdata.Padding = new System.Windows.Forms.Padding(4);
            tabOdata.Size = new System.Drawing.Size(910, 116);
            tabOdata.TabIndex = 9;
            tabOdata.Text = "OData";
            tabOdata.UseVisualStyleBackColor = true;
            tabOdata.Visible = false;
            // 
            // panel10
            // 
            panel10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel10.Controls.Add(label116);
            panel10.Controls.Add(printOdataBtn);
            panel10.Controls.Add(label117);
            panel10.Controls.Add(odataUrlTb);
            panel10.Controls.Add(label119);
            panel10.Controls.Add(label120);
            panel10.Controls.Add(label118);
            panel10.Location = new System.Drawing.Point(0, 0);
            panel10.Margin = new System.Windows.Forms.Padding(4);
            panel10.Name = "panel10";
            panel10.Size = new System.Drawing.Size(936, 113);
            panel10.TabIndex = 35;
            // 
            // label116
            // 
            label116.AutoSize = true;
            label116.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label116.Location = new System.Drawing.Point(4, 63);
            label116.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label116.Name = "label116";
            label116.Size = new System.Drawing.Size(26, 13);
            label116.TabIndex = 34;
            label116.Text = "Url: ";
            // 
            // printOdataBtn
            // 
            printOdataBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            printOdataBtn.Location = new System.Drawing.Point(741, 59);
            printOdataBtn.Margin = new System.Windows.Forms.Padding(4);
            printOdataBtn.Name = "printOdataBtn";
            printOdataBtn.Size = new System.Drawing.Size(131, 28);
            printOdataBtn.TabIndex = 33;
            printOdataBtn.Text = "&Print";
            printOdataBtn.Click += PrintOdataBtn_Click;
            // 
            // label117
            // 
            label117.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label117.Location = new System.Drawing.Point(404, 17);
            label117.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label117.Name = "label117";
            label117.Size = new System.Drawing.Size(28, 19);
            label117.TabIndex = 27;
            label117.Text = "US:";
            // 
            // odataUrlTb
            // 
            odataUrlTb.BackColor = System.Drawing.SystemColors.Window;
            odataUrlTb.Location = new System.Drawing.Point(38, 59);
            odataUrlTb.Margin = new System.Windows.Forms.Padding(4);
            odataUrlTb.Name = "odataUrlTb";
            odataUrlTb.Size = new System.Drawing.Size(625, 23);
            odataUrlTb.TabIndex = 29;
            odataUrlTb.Text = "http://services.odata.org/V3/Northwind/Northwind.svc/";
            // 
            // label119
            // 
            label119.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label119.Location = new System.Drawing.Point(439, 17);
            label119.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label119.Name = "label119";
            label119.Size = new System.Drawing.Size(425, 19);
            label119.TabIndex = 26;
            label119.Text = "Binds the component to an ODataDataProvider.";
            // 
            // label120
            // 
            label120.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label120.Location = new System.Drawing.Point(38, 17);
            label120.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label120.Name = "label120";
            label120.Size = new System.Drawing.Size(358, 19);
            label120.TabIndex = 25;
            label120.Text = "Bindet die Komponente an einen ODataDataProvider.";
            // 
            // label118
            // 
            label118.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label118.Location = new System.Drawing.Point(4, 17);
            label118.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label118.Name = "label118";
            label118.Size = new System.Drawing.Size(28, 19);
            label118.TabIndex = 28;
            label118.Text = "D:";
            // 
            // tabRest
            // 
            tabRest.Controls.Add(panel11);
            tabRest.Location = new System.Drawing.Point(4, 24);
            tabRest.Margin = new System.Windows.Forms.Padding(4);
            tabRest.Name = "tabRest";
            tabRest.Padding = new System.Windows.Forms.Padding(4);
            tabRest.Size = new System.Drawing.Size(910, 116);
            tabRest.TabIndex = 10;
            tabRest.Text = "REST";
            tabRest.UseVisualStyleBackColor = true;
            tabRest.Visible = false;
            // 
            // panel11
            // 
            panel11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel11.Controls.Add(label206);
            panel11.Controls.Add(restPrintBtn);
            panel11.Controls.Add(label202);
            panel11.Controls.Add(label205);
            panel11.Controls.Add(label204);
            panel11.Controls.Add(label203);
            panel11.Controls.Add(restUrlTb);
            panel11.Location = new System.Drawing.Point(0, 0);
            panel11.Margin = new System.Windows.Forms.Padding(4);
            panel11.Name = "panel11";
            panel11.Size = new System.Drawing.Size(936, 113);
            panel11.TabIndex = 35;
            // 
            // label206
            // 
            label206.AutoSize = true;
            label206.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label206.Location = new System.Drawing.Point(4, 63);
            label206.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label206.Name = "label206";
            label206.Size = new System.Drawing.Size(26, 13);
            label206.TabIndex = 35;
            label206.Text = "Url: ";
            // 
            // restPrintBtn
            // 
            restPrintBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            restPrintBtn.Location = new System.Drawing.Point(741, 59);
            restPrintBtn.Margin = new System.Windows.Forms.Padding(4);
            restPrintBtn.Name = "restPrintBtn";
            restPrintBtn.Size = new System.Drawing.Size(131, 28);
            restPrintBtn.TabIndex = 33;
            restPrintBtn.Text = "&Print";
            restPrintBtn.Click += RestPrintBtn_Click;
            // 
            // label202
            // 
            label202.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label202.Location = new System.Drawing.Point(404, 17);
            label202.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label202.Name = "label202";
            label202.Size = new System.Drawing.Size(28, 19);
            label202.TabIndex = 27;
            label202.Text = "US:";
            // 
            // label205
            // 
            label205.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label205.Location = new System.Drawing.Point(38, 17);
            label205.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label205.Name = "label205";
            label205.Size = new System.Drawing.Size(358, 19);
            label205.TabIndex = 25;
            label205.Text = "Bindet die Komponente an einen RestDataProvider.";
            // 
            // label204
            // 
            label204.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label204.Location = new System.Drawing.Point(439, 17);
            label204.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label204.Name = "label204";
            label204.Size = new System.Drawing.Size(435, 19);
            label204.TabIndex = 26;
            label204.Text = "Binds the component to a RestDataProvider.";
            // 
            // label203
            // 
            label203.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label203.Location = new System.Drawing.Point(4, 17);
            label203.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label203.Name = "label203";
            label203.Size = new System.Drawing.Size(28, 19);
            label203.TabIndex = 28;
            label203.Text = "D:";
            // 
            // restUrlTb
            // 
            restUrlTb.BackColor = System.Drawing.SystemColors.Window;
            restUrlTb.Location = new System.Drawing.Point(38, 59);
            restUrlTb.Margin = new System.Windows.Forms.Padding(4);
            restUrlTb.Name = "restUrlTb";
            restUrlTb.Size = new System.Drawing.Size(625, 23);
            restUrlTb.TabIndex = 29;
            restUrlTb.Text = "http://www.pegelonline.wsv.de/webservices/rest-api/v2/stations/KONSTANZ/W/measurements.json?start=P30D";
            // 
            // tabPage1
            // 
            tabPage1.Location = new System.Drawing.Point(4, 25);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new System.Drawing.Size(704, 99);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "DataSet";
            // 
            // comboBox1
            // 
            comboBox1.Location = new System.Drawing.Point(16, 66);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(416, 23);
            comboBox1.TabIndex = 32;
            // 
            // comboBox2
            // 
            comboBox2.Location = new System.Drawing.Point(16, 66);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(416, 23);
            comboBox2.TabIndex = 32;
            // 
            // comboBox3
            // 
            comboBox3.Location = new System.Drawing.Point(16, 66);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(416, 23);
            comboBox3.TabIndex = 32;
            // 
            // comboBox4
            // 
            comboBox4.Location = new System.Drawing.Point(16, 66);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(416, 23);
            comboBox4.TabIndex = 32;
            // 
            // comboBox5
            // 
            comboBox5.Location = new System.Drawing.Point(16, 66);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new System.Drawing.Size(416, 23);
            comboBox5.TabIndex = 32;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(116, 67);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(334, 23);
            textBox3.TabIndex = 29;
            textBox3.Text = "Data Source=<ComputerName>\\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated Security=True;Encrypt=False;";
            // 
            // tabPage37
            // 
            tabPage37.Location = new System.Drawing.Point(0, 0);
            tabPage37.Name = "tabPage37";
            tabPage37.Size = new System.Drawing.Size(200, 100);
            tabPage37.TabIndex = 0;
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(33, 68);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(417, 23);
            textBox4.TabIndex = 39;
            textBox4.Text = "http://services.odata.org/V3/Northwind/Northwind.svc/";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(918, 146);
            Controls.Add(tabControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "List & Label Cross Platform Databinding Sample";
            TransparencyKey = System.Drawing.Color.FromArgb(64, 0, 64);
            Load += Form1_Load;
            tabControl.ResumeLayout(false);
            tpDataSet.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tpXML.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tpDataViewManager.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tpDataView.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tpDbCommand.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tpDataTable.ResumeLayout(false);
            panel7.ResumeLayout(false);
            tpGenericList.ResumeLayout(false);
            panel8.ResumeLayout(false);
            tabSQLServer.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tabOdata.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            tabRest.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        internal ListLabel LL;
        //internal ListLabelPreviewControl LLPreviewControl;
        private System.Windows.Forms.TabPage tabSQLServer;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.TabPage tpGenericList;
        private System.Windows.Forms.TabPage tpDataTable;
        private System.Windows.Forms.TabPage tpDbCommand;
        private System.Windows.Forms.TabPage tpDataView;
        private System.Windows.Forms.TabPage tpDataViewManager;
        private System.Windows.Forms.TabPage tpXML;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TabPage tabPage37;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TabPage tabOdata;
        private System.Windows.Forms.TextBox odataUrlTb;
        private System.Windows.Forms.TabPage tabRest;
        private System.Windows.Forms.TextBox restUrlTb;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Button print_SQL;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Button print_GenericList;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Button print_DataTable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button print_Reader;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button print_DataView;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbCustomerNames;
        private System.Windows.Forms.Button print_DataViewManager;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button print_XML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Button printOdataBtn;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Button restPrintBtn;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.Label label203;
        private System.Windows.Forms.Label label204;
        private System.Windows.Forms.Label label205;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label206;
        private System.Windows.Forms.TabPage tpDataSet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button print_DataSet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}
