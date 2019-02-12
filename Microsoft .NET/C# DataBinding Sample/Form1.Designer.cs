using combit.ListLabel24;
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
            this.components = new System.ComponentModel.Container();
            this.LL = new combit.ListLabel24.ListLabel(this.components);
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tpDataSet = new System.Windows.Forms.TabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.design_DataSet = new MetroFramework.Controls.MetroButton();
            this.print_DataSet = new MetroFramework.Controls.MetroButton();
            this.label8 = new MetroFramework.Controls.MetroLabel();
            this.label7 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.tpXML = new System.Windows.Forms.TabPage();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.print_XML = new MetroFramework.Controls.MetroButton();
            this.design_XML = new MetroFramework.Controls.MetroButton();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.tpDataViewManager = new System.Windows.Forms.TabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.cbCustomerNames = new MetroFramework.Controls.MetroComboBox();
            this.print_DataViewManager = new MetroFramework.Controls.MetroButton();
            this.label21 = new MetroFramework.Controls.MetroLabel();
            this.design_DataViewManager = new MetroFramework.Controls.MetroButton();
            this.label23 = new MetroFramework.Controls.MetroLabel();
            this.label22 = new MetroFramework.Controls.MetroLabel();
            this.label24 = new MetroFramework.Controls.MetroLabel();
            this.tpDataView = new System.Windows.Forms.TabPage();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.design_DataView = new MetroFramework.Controls.MetroButton();
            this.print_DataView = new MetroFramework.Controls.MetroButton();
            this.label20 = new MetroFramework.Controls.MetroLabel();
            this.label17 = new MetroFramework.Controls.MetroLabel();
            this.label18 = new MetroFramework.Controls.MetroLabel();
            this.label19 = new MetroFramework.Controls.MetroLabel();
            this.tpDbCommand = new System.Windows.Forms.TabPage();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.print_Reader = new MetroFramework.Controls.MetroButton();
            this.design_Reader = new MetroFramework.Controls.MetroButton();
            this.label12 = new MetroFramework.Controls.MetroLabel();
            this.label9 = new MetroFramework.Controls.MetroLabel();
            this.label10 = new MetroFramework.Controls.MetroLabel();
            this.label11 = new MetroFramework.Controls.MetroLabel();
            this.tpDataTable = new System.Windows.Forms.TabPage();
            this.metroPanel7 = new MetroFramework.Controls.MetroPanel();
            this.design_DataTable = new MetroFramework.Controls.MetroButton();
            this.print_DataTable = new MetroFramework.Controls.MetroButton();
            this.label16 = new MetroFramework.Controls.MetroLabel();
            this.label13 = new MetroFramework.Controls.MetroLabel();
            this.label99 = new MetroFramework.Controls.MetroLabel();
            this.label15 = new MetroFramework.Controls.MetroLabel();
            this.tpGenericList = new System.Windows.Forms.TabPage();
            this.metroPanel8 = new MetroFramework.Controls.MetroPanel();
            this.print_GenericList = new MetroFramework.Controls.MetroButton();
            this.design_GenericList = new MetroFramework.Controls.MetroButton();
            this.label79 = new MetroFramework.Controls.MetroLabel();
            this.label77 = new MetroFramework.Controls.MetroLabel();
            this.label76 = new MetroFramework.Controls.MetroLabel();
            this.label78 = new MetroFramework.Controls.MetroLabel();
            this.tabSQLServer = new System.Windows.Forms.TabPage();
            this.metroPanel9 = new MetroFramework.Controls.MetroPanel();
            this.label115 = new MetroFramework.Controls.MetroLabel();
            this.print_SQL = new MetroFramework.Controls.MetroButton();
            this.design_SQL = new MetroFramework.Controls.MetroButton();
            this.label111 = new MetroFramework.Controls.MetroLabel();
            this.label114 = new MetroFramework.Controls.MetroLabel();
            this.label113 = new MetroFramework.Controls.MetroLabel();
            this.label112 = new MetroFramework.Controls.MetroLabel();
            this.tbConnectionString = new MetroFramework.Controls.MetroTextBox();
            this.tabOdata = new System.Windows.Forms.TabPage();
            this.metroPanel10 = new MetroFramework.Controls.MetroPanel();
            this.label116 = new MetroFramework.Controls.MetroLabel();
            this.printOdataBtn = new MetroFramework.Controls.MetroButton();
            this.label117 = new MetroFramework.Controls.MetroLabel();
            this.designOdataBtn = new MetroFramework.Controls.MetroButton();
            this.odataUrlTb = new MetroFramework.Controls.MetroTextBox();
            this.label119 = new MetroFramework.Controls.MetroLabel();
            this.label120 = new MetroFramework.Controls.MetroLabel();
            this.label118 = new MetroFramework.Controls.MetroLabel();
            this.tabRest = new System.Windows.Forms.TabPage();
            this.metroPanel11 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.restPrintBtn = new MetroFramework.Controls.MetroButton();
            this.restDesignBtn = new MetroFramework.Controls.MetroButton();
            this.label202 = new MetroFramework.Controls.MetroLabel();
            this.label205 = new MetroFramework.Controls.MetroLabel();
            this.label204 = new MetroFramework.Controls.MetroLabel();
            this.label203 = new MetroFramework.Controls.MetroLabel();
            this.restUrlTb = new MetroFramework.Controls.MetroTextBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.LLPreviewControl = new combit.ListLabel24.ListLabelPreviewControl(this.components);
            this.progressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.comboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.comboBox3 = new MetroFramework.Controls.MetroComboBox();
            this.comboBox4 = new MetroFramework.Controls.MetroComboBox();
            this.comboBox5 = new MetroFramework.Controls.MetroComboBox();
            this.textBox3 = new MetroFramework.Controls.MetroTextBox();
            this.tabPage37 = new System.Windows.Forms.TabPage();
            this.textBox4 = new MetroFramework.Controls.MetroTextBox();
            this.tabControl.SuspendLayout();
            this.tpDataSet.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.tpXML.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            this.tpDataViewManager.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.tpDataView.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.tpDbCommand.SuspendLayout();
            this.metroPanel6.SuspendLayout();
            this.tpDataTable.SuspendLayout();
            this.metroPanel7.SuspendLayout();
            this.tpGenericList.SuspendLayout();
            this.metroPanel8.SuspendLayout();
            this.tabSQLServer.SuspendLayout();
            this.metroPanel9.SuspendLayout();
            this.tabOdata.SuspendLayout();
            this.metroPanel10.SuspendLayout();
            this.tabRest.SuspendLayout();
            this.metroPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // LL
            // 
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_100;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            this.LL.AutoDefineField += new combit.ListLabel24.AutoDefineElementHandler(this.LL_AutoDefineField);
            this.LL.NotifyProgress += new combit.ListLabel24.NotifyProgressHandler(this.LL_NotifyProgress);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpDataSet);
            this.tabControl.Controls.Add(this.tpXML);
            this.tabControl.Controls.Add(this.tpDataViewManager);
            this.tabControl.Controls.Add(this.tpDataView);
            this.tabControl.Controls.Add(this.tpDbCommand);
            this.tabControl.Controls.Add(this.tpDataTable);
            this.tabControl.Controls.Add(this.tpGenericList);
            this.tabControl.Controls.Add(this.tabSQLServer);
            this.tabControl.Controls.Add(this.tabOdata);
            this.tabControl.Controls.Add(this.tabRest);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(20, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(763, 140);
            this.tabControl.Style = MetroFramework.MetroColorStyle.Blue;
            this.tabControl.TabIndex = 8;
            this.tabControl.UseSelectable = true;
            // 
            // tpDataSet
            // 
            this.tpDataSet.Controls.Add(this.metroPanel2);
            this.tpDataSet.Location = new System.Drawing.Point(4, 38);
            this.tpDataSet.Name = "tpDataSet";
            this.tpDataSet.Size = new System.Drawing.Size(755, 98);
            this.tpDataSet.TabIndex = 0;
            this.tpDataSet.Text = "DataSet";
            this.tpDataSet.UseVisualStyleBackColor = true;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel2.Controls.Add(this.design_DataSet);
            this.metroPanel2.Controls.Add(this.print_DataSet);
            this.metroPanel2.Controls.Add(this.label8);
            this.metroPanel2.Controls.Add(this.label7);
            this.metroPanel2.Controls.Add(this.label2);
            this.metroPanel2.Controls.Add(this.label6);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(753, 98);
            this.metroPanel2.TabIndex = 18;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // design_DataSet
            // 
            this.design_DataSet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.design_DataSet.Location = new System.Drawing.Point(512, 59);
            this.design_DataSet.Name = "design_DataSet";
            this.design_DataSet.Size = new System.Drawing.Size(112, 24);
            this.design_DataSet.TabIndex = 16;
            this.design_DataSet.Text = "&Design";
            this.design_DataSet.UseSelectable = true;
            this.design_DataSet.Click += new System.EventHandler(this.Design_DataSet_Click);
            // 
            // print_DataSet
            // 
            this.print_DataSet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_DataSet.Location = new System.Drawing.Point(641, 59);
            this.print_DataSet.Name = "print_DataSet";
            this.print_DataSet.Size = new System.Drawing.Size(112, 24);
            this.print_DataSet.TabIndex = 17;
            this.print_DataSet.Text = "&Print";
            this.print_DataSet.UseSelectable = true;
            this.print_DataSet.Click += new System.EventHandler(this.Print_DataSet_Click);
            // 
            // label8
            // 
            this.label8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label8.Location = new System.Drawing.Point(33, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(307, 32);
            this.label8.TabIndex = 12;
            this.label8.Text = "Bindet die Komponente an ein dynamisch erstelltes DataSet-Objekt mit DataRelation" +
    "s.";
            this.label8.WrapToLine = true;
            // 
            // label7
            // 
            this.label7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label7.Location = new System.Drawing.Point(376, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(374, 32);
            this.label7.TabIndex = 13;
            this.label7.Text = "Binds the component to a dynamically created DataSet containing DataRelations.";
            this.label7.WrapToLine = true;
            // 
            // label2
            // 
            this.label2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(346, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "US:";
            // 
            // label6
            // 
            this.label6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "D:";
            // 
            // tpXML
            // 
            this.tpXML.Controls.Add(this.metroPanel5);
            this.tpXML.Location = new System.Drawing.Point(4, 35);
            this.tpXML.Name = "tpXML";
            this.tpXML.Size = new System.Drawing.Size(755, 101);
            this.tpXML.TabIndex = 5;
            this.tpXML.Text = "XML";
            this.tpXML.UseVisualStyleBackColor = true;
            this.tpXML.Visible = false;
            // 
            // metroPanel5
            // 
            this.metroPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel5.Controls.Add(this.print_XML);
            this.metroPanel5.Controls.Add(this.design_XML);
            this.metroPanel5.Controls.Add(this.label3);
            this.metroPanel5.Controls.Add(this.label1);
            this.metroPanel5.Controls.Add(this.label5);
            this.metroPanel5.Controls.Add(this.label4);
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(0, 0);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(753, 98);
            this.metroPanel5.TabIndex = 22;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // print_XML
            // 
            this.print_XML.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_XML.Location = new System.Drawing.Point(641, 59);
            this.print_XML.Name = "print_XML";
            this.print_XML.Size = new System.Drawing.Size(112, 24);
            this.print_XML.TabIndex = 21;
            this.print_XML.Text = "&Print";
            this.print_XML.UseSelectable = true;
            this.print_XML.Click += new System.EventHandler(this.Print_XML_Click);
            // 
            // design_XML
            // 
            this.design_XML.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.design_XML.Location = new System.Drawing.Point(512, 59);
            this.design_XML.Name = "design_XML";
            this.design_XML.Size = new System.Drawing.Size(112, 24);
            this.design_XML.TabIndex = 20;
            this.design_XML.Text = "&Design";
            this.design_XML.UseSelectable = true;
            this.design_XML.Click += new System.EventHandler(this.Design_XML_Click);
            // 
            // label3
            // 
            this.label3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "D:";
            this.label3.WrapToLine = true;
            // 
            // label1
            // 
            this.label1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(346, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "US:";
            this.label1.WrapToLine = true;
            // 
            // label5
            // 
            this.label5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(33, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Bindet die Komponente an die Beispiel XML-Datei.";
            this.label5.WrapToLine = true;
            // 
            // label4
            // 
            this.label4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(376, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(374, 32);
            this.label4.TabIndex = 17;
            this.label4.Text = "Binds the component to the sample XML file.";
            this.label4.WrapToLine = true;
            // 
            // tpDataViewManager
            // 
            this.tpDataViewManager.Controls.Add(this.metroPanel3);
            this.tpDataViewManager.Location = new System.Drawing.Point(4, 35);
            this.tpDataViewManager.Name = "tpDataViewManager";
            this.tpDataViewManager.Size = new System.Drawing.Size(755, 101);
            this.tpDataViewManager.TabIndex = 6;
            this.tpDataViewManager.Text = "DataViewManager";
            this.tpDataViewManager.UseVisualStyleBackColor = true;
            this.tpDataViewManager.Visible = false;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel3.Controls.Add(this.cbCustomerNames);
            this.metroPanel3.Controls.Add(this.print_DataViewManager);
            this.metroPanel3.Controls.Add(this.label21);
            this.metroPanel3.Controls.Add(this.design_DataViewManager);
            this.metroPanel3.Controls.Add(this.label23);
            this.metroPanel3.Controls.Add(this.label22);
            this.metroPanel3.Controls.Add(this.label24);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(753, 98);
            this.metroPanel3.TabIndex = 33;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // cbCustomerNames
            // 
            this.cbCustomerNames.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbCustomerNames.ItemHeight = 19;
            this.cbCustomerNames.Location = new System.Drawing.Point(33, 60);
            this.cbCustomerNames.Name = "cbCustomerNames";
            this.cbCustomerNames.Size = new System.Drawing.Size(296, 25);
            this.cbCustomerNames.Style = MetroFramework.MetroColorStyle.Blue;
            this.cbCustomerNames.TabIndex = 32;
            this.cbCustomerNames.UseSelectable = true;
            // 
            // print_DataViewManager
            // 
            this.print_DataViewManager.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_DataViewManager.Location = new System.Drawing.Point(641, 59);
            this.print_DataViewManager.Name = "print_DataViewManager";
            this.print_DataViewManager.Size = new System.Drawing.Size(112, 24);
            this.print_DataViewManager.TabIndex = 31;
            this.print_DataViewManager.Text = "&Print";
            this.print_DataViewManager.UseSelectable = true;
            this.print_DataViewManager.Click += new System.EventHandler(this.Print_DataViewManager_Click);
            // 
            // label21
            // 
            this.label21.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label21.Location = new System.Drawing.Point(346, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 24);
            this.label21.TabIndex = 28;
            this.label21.Text = "US:";
            this.label21.WrapToLine = true;
            // 
            // design_DataViewManager
            // 
            this.design_DataViewManager.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.design_DataViewManager.Location = new System.Drawing.Point(512, 59);
            this.design_DataViewManager.Name = "design_DataViewManager";
            this.design_DataViewManager.Size = new System.Drawing.Size(112, 24);
            this.design_DataViewManager.TabIndex = 30;
            this.design_DataViewManager.Text = "&Design";
            this.design_DataViewManager.UseSelectable = true;
            this.design_DataViewManager.Click += new System.EventHandler(this.Design_DataViewManager_Click);
            // 
            // label23
            // 
            this.label23.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label23.Location = new System.Drawing.Point(376, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(374, 32);
            this.label23.TabIndex = 27;
            this.label23.Text = "Binds the component to a DataView object. Choose a filter for the company name.";
            this.label23.WrapToLine = true;
            // 
            // label22
            // 
            this.label22.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label22.Location = new System.Drawing.Point(3, 15);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 24);
            this.label22.TabIndex = 29;
            this.label22.Text = "D:";
            this.label22.WrapToLine = true;
            // 
            // label24
            // 
            this.label24.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label24.Location = new System.Drawing.Point(33, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(307, 40);
            this.label24.TabIndex = 26;
            this.label24.Text = "Bindet die Komponente an ein DataViewManager-Objekt. Sie können einen Filter für " +
    "den Firmennamen wählen.";
            this.label24.WrapToLine = true;
            // 
            // tpDataView
            // 
            this.tpDataView.Controls.Add(this.metroPanel4);
            this.tpDataView.Location = new System.Drawing.Point(4, 35);
            this.tpDataView.Name = "tpDataView";
            this.tpDataView.Size = new System.Drawing.Size(755, 101);
            this.tpDataView.TabIndex = 3;
            this.tpDataView.Text = "DataView";
            this.tpDataView.UseVisualStyleBackColor = true;
            this.tpDataView.Visible = false;
            // 
            // metroPanel4
            // 
            this.metroPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel4.Controls.Add(this.design_DataView);
            this.metroPanel4.Controls.Add(this.print_DataView);
            this.metroPanel4.Controls.Add(this.label20);
            this.metroPanel4.Controls.Add(this.label17);
            this.metroPanel4.Controls.Add(this.label18);
            this.metroPanel4.Controls.Add(this.label19);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(0, 0);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(753, 98);
            this.metroPanel4.TabIndex = 26;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // design_DataView
            // 
            this.design_DataView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.design_DataView.Location = new System.Drawing.Point(512, 59);
            this.design_DataView.Name = "design_DataView";
            this.design_DataView.Size = new System.Drawing.Size(112, 24);
            this.design_DataView.TabIndex = 24;
            this.design_DataView.Text = "&Design";
            this.design_DataView.UseSelectable = true;
            this.design_DataView.Click += new System.EventHandler(this.Design_DataView_Click);
            // 
            // print_DataView
            // 
            this.print_DataView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_DataView.Location = new System.Drawing.Point(641, 59);
            this.print_DataView.Name = "print_DataView";
            this.print_DataView.Size = new System.Drawing.Size(112, 24);
            this.print_DataView.TabIndex = 25;
            this.print_DataView.Text = "&Print";
            this.print_DataView.UseSelectable = true;
            this.print_DataView.Click += new System.EventHandler(this.Print_DataView_Click);
            // 
            // label20
            // 
            this.label20.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label20.Location = new System.Drawing.Point(33, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(307, 32);
            this.label20.TabIndex = 16;
            this.label20.Text = "Bindet die Komponente an ein DataView-Objekt.";
            this.label20.WrapToLine = true;
            // 
            // label17
            // 
            this.label17.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label17.Location = new System.Drawing.Point(346, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 18;
            this.label17.Text = "US:";
            this.label17.WrapToLine = true;
            // 
            // label18
            // 
            this.label18.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label18.Location = new System.Drawing.Point(3, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 16);
            this.label18.TabIndex = 19;
            this.label18.Text = "D:";
            this.label18.WrapToLine = true;
            // 
            // label19
            // 
            this.label19.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label19.Location = new System.Drawing.Point(376, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(374, 32);
            this.label19.TabIndex = 17;
            this.label19.Text = "Binds the component to a DataView object.";
            this.label19.WrapToLine = true;
            // 
            // tpDbCommand
            // 
            this.tpDbCommand.Controls.Add(this.metroPanel6);
            this.tpDbCommand.Location = new System.Drawing.Point(4, 35);
            this.tpDbCommand.Name = "tpDbCommand";
            this.tpDbCommand.Size = new System.Drawing.Size(755, 101);
            this.tpDbCommand.TabIndex = 1;
            this.tpDbCommand.Text = "DbCommand";
            this.tpDbCommand.UseVisualStyleBackColor = true;
            this.tpDbCommand.Visible = false;
            // 
            // metroPanel6
            // 
            this.metroPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel6.Controls.Add(this.print_Reader);
            this.metroPanel6.Controls.Add(this.design_Reader);
            this.metroPanel6.Controls.Add(this.label12);
            this.metroPanel6.Controls.Add(this.label9);
            this.metroPanel6.Controls.Add(this.label10);
            this.metroPanel6.Controls.Add(this.label11);
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 10;
            this.metroPanel6.Location = new System.Drawing.Point(0, 0);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(753, 98);
            this.metroPanel6.TabIndex = 25;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            // 
            // print_Reader
            // 
            this.print_Reader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_Reader.Location = new System.Drawing.Point(641, 59);
            this.print_Reader.Name = "print_Reader";
            this.print_Reader.Size = new System.Drawing.Size(112, 24);
            this.print_Reader.TabIndex = 23;
            this.print_Reader.Text = "&Print";
            this.print_Reader.UseSelectable = true;
            this.print_Reader.Click += new System.EventHandler(this.Print_Reader_Click);
            // 
            // design_Reader
            // 
            this.design_Reader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.design_Reader.Location = new System.Drawing.Point(512, 59);
            this.design_Reader.Name = "design_Reader";
            this.design_Reader.Size = new System.Drawing.Size(112, 24);
            this.design_Reader.TabIndex = 22;
            this.design_Reader.Text = "&Design";
            this.design_Reader.UseSelectable = true;
            this.design_Reader.Click += new System.EventHandler(this.Design_Reader_Click);
            // 
            // label12
            // 
            this.label12.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label12.Location = new System.Drawing.Point(33, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(307, 32);
            this.label12.TabIndex = 24;
            this.label12.Text = "Bindet die Komponente an ein OleDbCommand-Objekt.";
            this.label12.WrapToLine = true;
            // 
            // label9
            // 
            this.label9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label9.Location = new System.Drawing.Point(346, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "US:";
            this.label9.WrapToLine = true;
            // 
            // label10
            // 
            this.label10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label10.Location = new System.Drawing.Point(3, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "D:";
            this.label10.WrapToLine = true;
            // 
            // label11
            // 
            this.label11.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label11.Location = new System.Drawing.Point(376, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(374, 32);
            this.label11.TabIndex = 17;
            this.label11.Text = "Binds the component to an OleDbCommand object.";
            this.label11.WrapToLine = true;
            // 
            // tpDataTable
            // 
            this.tpDataTable.Controls.Add(this.metroPanel7);
            this.tpDataTable.Location = new System.Drawing.Point(4, 35);
            this.tpDataTable.Name = "tpDataTable";
            this.tpDataTable.Size = new System.Drawing.Size(755, 101);
            this.tpDataTable.TabIndex = 2;
            this.tpDataTable.Text = "DataTable";
            this.tpDataTable.UseVisualStyleBackColor = true;
            this.tpDataTable.Visible = false;
            // 
            // metroPanel7
            // 
            this.metroPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel7.Controls.Add(this.design_DataTable);
            this.metroPanel7.Controls.Add(this.print_DataTable);
            this.metroPanel7.Controls.Add(this.label16);
            this.metroPanel7.Controls.Add(this.label13);
            this.metroPanel7.Controls.Add(this.label99);
            this.metroPanel7.Controls.Add(this.label15);
            this.metroPanel7.HorizontalScrollbarBarColor = true;
            this.metroPanel7.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel7.HorizontalScrollbarSize = 10;
            this.metroPanel7.Location = new System.Drawing.Point(0, 0);
            this.metroPanel7.Name = "metroPanel7";
            this.metroPanel7.Size = new System.Drawing.Size(753, 98);
            this.metroPanel7.TabIndex = 28;
            this.metroPanel7.VerticalScrollbarBarColor = true;
            this.metroPanel7.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel7.VerticalScrollbarSize = 10;
            // 
            // design_DataTable
            // 
            this.design_DataTable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.design_DataTable.Location = new System.Drawing.Point(512, 59);
            this.design_DataTable.Name = "design_DataTable";
            this.design_DataTable.Size = new System.Drawing.Size(112, 24);
            this.design_DataTable.TabIndex = 26;
            this.design_DataTable.Text = "&Design";
            this.design_DataTable.UseSelectable = true;
            this.design_DataTable.Click += new System.EventHandler(this.Design_DataTable_Click);
            // 
            // print_DataTable
            // 
            this.print_DataTable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_DataTable.Location = new System.Drawing.Point(641, 59);
            this.print_DataTable.Name = "print_DataTable";
            this.print_DataTable.Size = new System.Drawing.Size(112, 24);
            this.print_DataTable.TabIndex = 27;
            this.print_DataTable.Text = "&Print";
            this.print_DataTable.UseSelectable = true;
            this.print_DataTable.Click += new System.EventHandler(this.Print_DataTable_Click);
            // 
            // label16
            // 
            this.label16.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label16.Location = new System.Drawing.Point(33, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(307, 32);
            this.label16.TabIndex = 16;
            this.label16.Text = "Bindet die Komponente an ein DataTable-Objekt.";
            this.label16.WrapToLine = true;
            // 
            // label13
            // 
            this.label13.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label13.Location = new System.Drawing.Point(346, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 18;
            this.label13.Text = "US:";
            this.label13.WrapToLine = true;
            // 
            // label99
            // 
            this.label99.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label99.Location = new System.Drawing.Point(3, 15);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(24, 16);
            this.label99.TabIndex = 19;
            this.label99.Text = "D:";
            this.label99.WrapToLine = true;
            // 
            // label15
            // 
            this.label15.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label15.Location = new System.Drawing.Point(376, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(374, 32);
            this.label15.TabIndex = 17;
            this.label15.Text = "Binds the component to a DataTable object.";
            this.label15.WrapToLine = true;
            // 
            // tpGenericList
            // 
            this.tpGenericList.Controls.Add(this.metroPanel8);
            this.tpGenericList.Location = new System.Drawing.Point(4, 35);
            this.tpGenericList.Name = "tpGenericList";
            this.tpGenericList.Padding = new System.Windows.Forms.Padding(3);
            this.tpGenericList.Size = new System.Drawing.Size(755, 101);
            this.tpGenericList.TabIndex = 7;
            this.tpGenericList.Text = "Generic List";
            this.tpGenericList.UseVisualStyleBackColor = true;
            this.tpGenericList.Visible = false;
            // 
            // metroPanel8
            // 
            this.metroPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel8.Controls.Add(this.print_GenericList);
            this.metroPanel8.Controls.Add(this.design_GenericList);
            this.metroPanel8.Controls.Add(this.label79);
            this.metroPanel8.Controls.Add(this.label77);
            this.metroPanel8.Controls.Add(this.label76);
            this.metroPanel8.Controls.Add(this.label78);
            this.metroPanel8.HorizontalScrollbarBarColor = true;
            this.metroPanel8.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel8.HorizontalScrollbarSize = 10;
            this.metroPanel8.Location = new System.Drawing.Point(0, 0);
            this.metroPanel8.Name = "metroPanel8";
            this.metroPanel8.Size = new System.Drawing.Size(753, 98);
            this.metroPanel8.TabIndex = 30;
            this.metroPanel8.VerticalScrollbarBarColor = true;
            this.metroPanel8.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel8.VerticalScrollbarSize = 10;
            // 
            // print_GenericList
            // 
            this.print_GenericList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_GenericList.Location = new System.Drawing.Point(641, 59);
            this.print_GenericList.Name = "print_GenericList";
            this.print_GenericList.Size = new System.Drawing.Size(112, 24);
            this.print_GenericList.TabIndex = 29;
            this.print_GenericList.Text = "&Print";
            this.print_GenericList.UseSelectable = true;
            this.print_GenericList.Click += new System.EventHandler(this.Print_GenericList_Click);
            // 
            // design_GenericList
            // 
            this.design_GenericList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.design_GenericList.Location = new System.Drawing.Point(512, 59);
            this.design_GenericList.Name = "design_GenericList";
            this.design_GenericList.Size = new System.Drawing.Size(112, 24);
            this.design_GenericList.TabIndex = 28;
            this.design_GenericList.Text = "&Design";
            this.design_GenericList.UseSelectable = true;
            this.design_GenericList.Click += new System.EventHandler(this.Design_GenericList_Click);
            // 
            // label79
            // 
            this.label79.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label79.Location = new System.Drawing.Point(33, 15);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(307, 32);
            this.label79.TabIndex = 20;
            this.label79.Text = "Bindet die Komponente an eine generische Liste.";
            this.label79.WrapToLine = true;
            // 
            // label77
            // 
            this.label77.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label77.Location = new System.Drawing.Point(3, 15);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(24, 16);
            this.label77.TabIndex = 24;
            this.label77.Text = "D:";
            this.label77.WrapToLine = true;
            // 
            // label76
            // 
            this.label76.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label76.Location = new System.Drawing.Point(346, 15);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(24, 16);
            this.label76.TabIndex = 23;
            this.label76.Text = "US:";
            // 
            // label78
            // 
            this.label78.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label78.Location = new System.Drawing.Point(376, 15);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(373, 32);
            this.label78.TabIndex = 21;
            this.label78.Text = "Binds the component to a generic list.";
            this.label78.WrapToLine = true;
            // 
            // tabSQLServer
            // 
            this.tabSQLServer.Controls.Add(this.metroPanel9);
            this.tabSQLServer.Location = new System.Drawing.Point(4, 35);
            this.tabSQLServer.Name = "tabSQLServer";
            this.tabSQLServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQLServer.Size = new System.Drawing.Size(755, 101);
            this.tabSQLServer.TabIndex = 8;
            this.tabSQLServer.Text = "SQL Server";
            this.tabSQLServer.UseVisualStyleBackColor = true;
            this.tabSQLServer.Visible = false;
            // 
            // metroPanel9
            // 
            this.metroPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel9.Controls.Add(this.label115);
            this.metroPanel9.Controls.Add(this.print_SQL);
            this.metroPanel9.Controls.Add(this.design_SQL);
            this.metroPanel9.Controls.Add(this.label111);
            this.metroPanel9.Controls.Add(this.label114);
            this.metroPanel9.Controls.Add(this.label113);
            this.metroPanel9.Controls.Add(this.label112);
            this.metroPanel9.Controls.Add(this.tbConnectionString);
            this.metroPanel9.HorizontalScrollbarBarColor = true;
            this.metroPanel9.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel9.HorizontalScrollbarSize = 10;
            this.metroPanel9.Location = new System.Drawing.Point(0, 0);
            this.metroPanel9.Name = "metroPanel9";
            this.metroPanel9.Size = new System.Drawing.Size(753, 98);
            this.metroPanel9.TabIndex = 35;
            this.metroPanel9.VerticalScrollbarBarColor = true;
            this.metroPanel9.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel9.VerticalScrollbarSize = 10;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label115.Location = new System.Drawing.Point(1, 64);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(103, 15);
            this.label115.TabIndex = 34;
            this.label115.Text = "Connection-String: ";
            this.label115.WrapToLine = true;
            // 
            // print_SQL
            // 
            this.print_SQL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.print_SQL.Location = new System.Drawing.Point(641, 59);
            this.print_SQL.Name = "print_SQL";
            this.print_SQL.Size = new System.Drawing.Size(112, 24);
            this.print_SQL.TabIndex = 33;
            this.print_SQL.Text = "&Print";
            this.print_SQL.UseSelectable = true;
            this.print_SQL.Click += new System.EventHandler(this.Print_SQL_Click);
            // 
            // design_SQL
            // 
            this.design_SQL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.design_SQL.Location = new System.Drawing.Point(512, 59);
            this.design_SQL.Name = "design_SQL";
            this.design_SQL.Size = new System.Drawing.Size(112, 24);
            this.design_SQL.TabIndex = 32;
            this.design_SQL.Text = "&Design";
            this.design_SQL.UseSelectable = true;
            this.design_SQL.Click += new System.EventHandler(this.Design_SQL_Click);
            // 
            // label111
            // 
            this.label111.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label111.Location = new System.Drawing.Point(346, 15);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(24, 16);
            this.label111.TabIndex = 27;
            this.label111.Text = "US:";
            this.label111.WrapToLine = true;
            // 
            // label114
            // 
            this.label114.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label114.Location = new System.Drawing.Point(33, 15);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(315, 32);
            this.label114.TabIndex = 25;
            this.label114.Text = "Bindet die Komponente an einen SqlConnectionDataProvider.";
            this.label114.WrapToLine = true;
            // 
            // label113
            // 
            this.label113.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label113.Location = new System.Drawing.Point(376, 15);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(373, 32);
            this.label113.TabIndex = 26;
            this.label113.Text = "Binds the component to a SqlConnectionDataProvider.";
            this.label113.WrapToLine = true;
            // 
            // label112
            // 
            this.label112.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label112.Location = new System.Drawing.Point(3, 15);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(24, 16);
            this.label112.TabIndex = 28;
            this.label112.Text = "D:";
            this.label112.WrapToLine = true;
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.BackColor = System.Drawing.SystemColors.Window;
            this.tbConnectionString.Lines = new string[] {
        "Data Source=<ComputerName>\\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated S" +
            "ecurity=True"};
            this.tbConnectionString.Location = new System.Drawing.Point(104, 61);
            this.tbConnectionString.MaxLength = 32767;
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.PasswordChar = '\0';
            this.tbConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbConnectionString.SelectedText = "";
            this.tbConnectionString.Size = new System.Drawing.Size(374, 20);
            this.tbConnectionString.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbConnectionString.TabIndex = 29;
            this.tbConnectionString.Text = "Data Source=<ComputerName>\\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated S" +
    "ecurity=True";
            this.tbConnectionString.UseCustomBackColor = true;
            this.tbConnectionString.UseSelectable = true;
            this.tbConnectionString.WordWrap = false;
            // 
            // tabOdata
            // 
            this.tabOdata.Controls.Add(this.metroPanel10);
            this.tabOdata.Location = new System.Drawing.Point(4, 35);
            this.tabOdata.Name = "tabOdata";
            this.tabOdata.Padding = new System.Windows.Forms.Padding(3);
            this.tabOdata.Size = new System.Drawing.Size(755, 101);
            this.tabOdata.TabIndex = 9;
            this.tabOdata.Text = "OData";
            this.tabOdata.UseVisualStyleBackColor = true;
            this.tabOdata.Visible = false;
            // 
            // metroPanel10
            // 
            this.metroPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel10.Controls.Add(this.label116);
            this.metroPanel10.Controls.Add(this.printOdataBtn);
            this.metroPanel10.Controls.Add(this.label117);
            this.metroPanel10.Controls.Add(this.designOdataBtn);
            this.metroPanel10.Controls.Add(this.odataUrlTb);
            this.metroPanel10.Controls.Add(this.label119);
            this.metroPanel10.Controls.Add(this.label120);
            this.metroPanel10.Controls.Add(this.label118);
            this.metroPanel10.HorizontalScrollbarBarColor = true;
            this.metroPanel10.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel10.HorizontalScrollbarSize = 10;
            this.metroPanel10.Location = new System.Drawing.Point(0, 0);
            this.metroPanel10.Name = "metroPanel10";
            this.metroPanel10.Size = new System.Drawing.Size(753, 98);
            this.metroPanel10.TabIndex = 35;
            this.metroPanel10.VerticalScrollbarBarColor = true;
            this.metroPanel10.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel10.VerticalScrollbarSize = 10;
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label116.Location = new System.Drawing.Point(1, 64);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(27, 15);
            this.label116.TabIndex = 34;
            this.label116.Text = "Url: ";
            this.label116.WrapToLine = true;
            // 
            // printOdataBtn
            // 
            this.printOdataBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.printOdataBtn.Location = new System.Drawing.Point(641, 59);
            this.printOdataBtn.Name = "printOdataBtn";
            this.printOdataBtn.Size = new System.Drawing.Size(112, 24);
            this.printOdataBtn.TabIndex = 33;
            this.printOdataBtn.Text = "&Print";
            this.printOdataBtn.UseSelectable = true;
            this.printOdataBtn.Click += new System.EventHandler(this.PrintOdataBtn_Click);
            // 
            // label117
            // 
            this.label117.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label117.Location = new System.Drawing.Point(346, 15);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(24, 16);
            this.label117.TabIndex = 27;
            this.label117.Text = "US:";
            this.label117.WrapToLine = true;
            // 
            // designOdataBtn
            // 
            this.designOdataBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.designOdataBtn.Location = new System.Drawing.Point(512, 59);
            this.designOdataBtn.Name = "designOdataBtn";
            this.designOdataBtn.Size = new System.Drawing.Size(112, 24);
            this.designOdataBtn.TabIndex = 32;
            this.designOdataBtn.Text = "&Design";
            this.designOdataBtn.UseSelectable = true;
            this.designOdataBtn.Click += new System.EventHandler(this.DesignOdataBtn_Click);
            // 
            // odataUrlTb
            // 
            this.odataUrlTb.BackColor = System.Drawing.SystemColors.Window;
            this.odataUrlTb.Lines = new string[] {
        "http://services.odata.org/V3/Northwind/Northwind.svc/"};
            this.odataUrlTb.Location = new System.Drawing.Point(31, 61);
            this.odataUrlTb.MaxLength = 32767;
            this.odataUrlTb.Name = "odataUrlTb";
            this.odataUrlTb.PasswordChar = '\0';
            this.odataUrlTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.odataUrlTb.SelectedText = "";
            this.odataUrlTb.Size = new System.Drawing.Size(447, 20);
            this.odataUrlTb.Style = MetroFramework.MetroColorStyle.Blue;
            this.odataUrlTb.TabIndex = 29;
            this.odataUrlTb.Text = "http://services.odata.org/V3/Northwind/Northwind.svc/";
            this.odataUrlTb.UseCustomBackColor = true;
            this.odataUrlTb.UseSelectable = true;
            // 
            // label119
            // 
            this.label119.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label119.Location = new System.Drawing.Point(376, 15);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(373, 32);
            this.label119.TabIndex = 26;
            this.label119.Text = "Binds the component to an ODataDataProvider.";
            this.label119.WrapToLine = true;
            // 
            // label120
            // 
            this.label120.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label120.Location = new System.Drawing.Point(33, 15);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(307, 32);
            this.label120.TabIndex = 25;
            this.label120.Text = "Bindet die Komponente an einen ODataDataProvider.";
            this.label120.WrapToLine = true;
            // 
            // label118
            // 
            this.label118.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label118.Location = new System.Drawing.Point(3, 15);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(24, 16);
            this.label118.TabIndex = 28;
            this.label118.Text = "D:";
            this.label118.WrapToLine = true;
            // 
            // tabRest
            // 
            this.tabRest.Controls.Add(this.metroPanel11);
            this.tabRest.Location = new System.Drawing.Point(4, 35);
            this.tabRest.Name = "tabRest";
            this.tabRest.Padding = new System.Windows.Forms.Padding(3);
            this.tabRest.Size = new System.Drawing.Size(755, 101);
            this.tabRest.TabIndex = 10;
            this.tabRest.Text = "REST";
            this.tabRest.UseVisualStyleBackColor = true;
            this.tabRest.Visible = false;
            // 
            // metroPanel11
            // 
            this.metroPanel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel11.Controls.Add(this.metroLabel1);
            this.metroPanel11.Controls.Add(this.restPrintBtn);
            this.metroPanel11.Controls.Add(this.restDesignBtn);
            this.metroPanel11.Controls.Add(this.label202);
            this.metroPanel11.Controls.Add(this.label205);
            this.metroPanel11.Controls.Add(this.label204);
            this.metroPanel11.Controls.Add(this.label203);
            this.metroPanel11.Controls.Add(this.restUrlTb);
            this.metroPanel11.HorizontalScrollbarBarColor = true;
            this.metroPanel11.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel11.HorizontalScrollbarSize = 10;
            this.metroPanel11.Location = new System.Drawing.Point(0, 0);
            this.metroPanel11.Name = "metroPanel11";
            this.metroPanel11.Size = new System.Drawing.Size(753, 98);
            this.metroPanel11.TabIndex = 35;
            this.metroPanel11.VerticalScrollbarBarColor = true;
            this.metroPanel11.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel11.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(1, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(27, 15);
            this.metroLabel1.TabIndex = 35;
            this.metroLabel1.Text = "Url: ";
            this.metroLabel1.WrapToLine = true;
            // 
            // restPrintBtn
            // 
            this.restPrintBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.restPrintBtn.Location = new System.Drawing.Point(641, 59);
            this.restPrintBtn.Name = "restPrintBtn";
            this.restPrintBtn.Size = new System.Drawing.Size(112, 24);
            this.restPrintBtn.TabIndex = 33;
            this.restPrintBtn.Text = "&Print";
            this.restPrintBtn.UseSelectable = true;
            this.restPrintBtn.Click += new System.EventHandler(this.RestPrintBtn_Click);
            // 
            // restDesignBtn
            // 
            this.restDesignBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.restDesignBtn.Location = new System.Drawing.Point(512, 59);
            this.restDesignBtn.Name = "restDesignBtn";
            this.restDesignBtn.Size = new System.Drawing.Size(112, 24);
            this.restDesignBtn.TabIndex = 32;
            this.restDesignBtn.Text = "&Design";
            this.restDesignBtn.UseSelectable = true;
            this.restDesignBtn.Click += new System.EventHandler(this.RestDesignBtn_Click);
            // 
            // label202
            // 
            this.label202.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label202.Location = new System.Drawing.Point(346, 15);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(24, 16);
            this.label202.TabIndex = 27;
            this.label202.Text = "US:";
            this.label202.WrapToLine = true;
            // 
            // label205
            // 
            this.label205.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label205.Location = new System.Drawing.Point(33, 15);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(307, 32);
            this.label205.TabIndex = 25;
            this.label205.Text = "Bindet die Komponente an einen RestDataProvider.";
            this.label205.WrapToLine = true;
            // 
            // label204
            // 
            this.label204.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label204.Location = new System.Drawing.Point(376, 15);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(373, 32);
            this.label204.TabIndex = 26;
            this.label204.Text = "Binds the component to a RestDataProvider.";
            this.label204.WrapToLine = true;
            // 
            // label203
            // 
            this.label203.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label203.Location = new System.Drawing.Point(3, 15);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(24, 16);
            this.label203.TabIndex = 28;
            this.label203.Text = "D:";
            this.label203.WrapToLine = true;
            // 
            // restUrlTb
            // 
            this.restUrlTb.BackColor = System.Drawing.SystemColors.Window;
            this.restUrlTb.Lines = new string[] {
        "http://www.pegelonline.wsv.de/webservices/rest-api/v2/stations/KONSTANZ/W/measurements.json?start=P30D"};
            this.restUrlTb.Location = new System.Drawing.Point(31, 61);
            this.restUrlTb.MaxLength = 32767;
            this.restUrlTb.Name = "restUrlTb";
            this.restUrlTb.PasswordChar = '\0';
            this.restUrlTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.restUrlTb.SelectedText = "";
            this.restUrlTb.Size = new System.Drawing.Size(447, 20);
            this.restUrlTb.Style = MetroFramework.MetroColorStyle.Blue;
            this.restUrlTb.TabIndex = 29;
            this.restUrlTb.Text = "http://www.pegelonline.wsv.de/webservices/rest-api/v2/stations/KONSTANZ/W/measurements.json?start=P30D";
            this.restUrlTb.UseCustomBackColor = true;
            this.restUrlTb.UseSelectable = true;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(20, 708);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(763, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 13;
            // 
            // LLPreviewControl
            // 
            this.LLPreviewControl.AllowRbuttonUsage = true;
            this.LLPreviewControl.BackColor = System.Drawing.SystemColors.Window;
            this.LLPreviewControl.CloseMode = combit.ListLabel24.LlPreviewControlCloseMode.DeleteFile;
            this.LLPreviewControl.CurrentPage = 0;
            this.LLPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LLPreviewControl.ForceReadOnly = false;
            this.LLPreviewControl.Location = new System.Drawing.Point(20, 200);
            this.LLPreviewControl.Name = "LLPreviewControl";
            this.LLPreviewControl.Size = new System.Drawing.Size(763, 508);
            this.LLPreviewControl.SlideshowMode = false;
            this.LLPreviewControl.TabIndex = 14;
            this.LLPreviewControl.Text = "listLabelPreviewControl1";
            this.LLPreviewControl.ToolbarButtons.Exit = combit.ListLabel24.LlButtonState.Invisible;
            this.LLPreviewControl.ToolbarButtons.GotoFirst = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.GotoLast = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.GotoNext = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.GotoPrev = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.NextFile = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.PageRange = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.PreviousFile = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.PrintAllPages = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.PrintCurrentPage = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.PrintToFax = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.SaveAs = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.SearchNext = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.SearchOptions = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.SearchStart = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.SearchText = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.SendTo = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.SlideshowMode = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.ZoomCombo = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.ZoomReset = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.ZoomRevert = combit.ListLabel24.LlButtonState.Default;
            this.LLPreviewControl.ToolbarButtons.ZoomTimes2 = combit.ListLabel24.LlButtonState.Default;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(1, -922);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(144, 16);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(704, 99);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DataSet";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(16, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(416, 21);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.UseSelectable = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Location = new System.Drawing.Point(16, 66);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(416, 21);
            this.comboBox2.TabIndex = 32;
            this.comboBox2.UseSelectable = true;
            // 
            // comboBox3
            // 
            this.comboBox3.Location = new System.Drawing.Point(16, 66);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(416, 21);
            this.comboBox3.TabIndex = 32;
            this.comboBox3.UseSelectable = true;
            // 
            // comboBox4
            // 
            this.comboBox4.Location = new System.Drawing.Point(16, 66);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(416, 21);
            this.comboBox4.TabIndex = 32;
            this.comboBox4.UseSelectable = true;
            // 
            // comboBox5
            // 
            this.comboBox5.Location = new System.Drawing.Point(16, 66);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(416, 21);
            this.comboBox5.TabIndex = 32;
            this.comboBox5.UseSelectable = true;
            // 
            // textBox3
            // 
            this.textBox3.Lines = new string[] {
        "Data Source=<ComputerName>\\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated S" +
            "ecurity=True"};
            this.textBox3.Location = new System.Drawing.Point(116, 67);
            this.textBox3.MaxLength = 32767;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox3.SelectedText = "";
            this.textBox3.Size = new System.Drawing.Size(334, 20);
            this.textBox3.TabIndex = 29;
            this.textBox3.Text = "Data Source=<ComputerName>\\SQLEXPRESS;Initial Catalog=<DatabaseName>;Integrated S" +
    "ecurity=True";
            this.textBox3.UseSelectable = true;
            // 
            // tabPage37
            // 
            this.tabPage37.Location = new System.Drawing.Point(0, 0);
            this.tabPage37.Name = "tabPage37";
            this.tabPage37.Size = new System.Drawing.Size(200, 100);
            this.tabPage37.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.Lines = new string[] {
        "http://services.odata.org/V3/Northwind/Northwind.svc/"};
            this.textBox4.Location = new System.Drawing.Point(33, 68);
            this.textBox4.MaxLength = 32767;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox4.SelectedText = "";
            this.textBox4.Size = new System.Drawing.Size(417, 20);
            this.textBox4.TabIndex = 39;
            this.textBox4.Text = "http://services.odata.org/V3/Northwind/Northwind.svc/";
            this.textBox4.UseSelectable = true;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(803, 750);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LLPreviewControl);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(803, 750);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "List & Label C# Databinding Sample";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tpDataSet.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.tpXML.ResumeLayout(false);
            this.metroPanel5.ResumeLayout(false);
            this.tpDataViewManager.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.tpDataView.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.tpDbCommand.ResumeLayout(false);
            this.metroPanel6.ResumeLayout(false);
            this.tpDataTable.ResumeLayout(false);
            this.metroPanel7.ResumeLayout(false);
            this.tpGenericList.ResumeLayout(false);
            this.metroPanel8.ResumeLayout(false);
            this.tabSQLServer.ResumeLayout(false);
            this.metroPanel9.ResumeLayout(false);
            this.metroPanel9.PerformLayout();
            this.tabOdata.ResumeLayout(false);
            this.metroPanel10.ResumeLayout(false);
            this.metroPanel10.PerformLayout();
            this.tabRest.ResumeLayout(false);
            this.metroPanel11.ResumeLayout(false);
            this.metroPanel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal ListLabel LL;
        private System.Windows.Forms.StatusBar statusBar1;
        internal ListLabelPreviewControl LLPreviewControl;
        private MetroFramework.Controls.MetroProgressBar progressBar1;
        private System.Windows.Forms.TabPage tabSQLServer; 
        private MetroFramework.Controls.MetroTextBox tbConnectionString; 
        private System.Windows.Forms.TabPage tpGenericList;
        private System.Windows.Forms.TabPage tpDataTable;
        private System.Windows.Forms.TabPage tpDbCommand;
        private System.Windows.Forms.TabPage tpDataView;
        private System.Windows.Forms.TabPage tpDataViewManager;
        private System.Windows.Forms.TabPage tpXML;
        private System.Windows.Forms.TabPage tpDataSet;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTextBox textBox3;
        private System.Windows.Forms.TabPage tabPage37;
        private MetroFramework.Controls.MetroTextBox textBox4;
        private System.Windows.Forms.TabPage tabOdata;
        private MetroFramework.Controls.MetroTextBox odataUrlTb;
        private System.Windows.Forms.TabPage tabRest;
        private MetroFramework.Controls.MetroTextBox restUrlTb;
        private System.Windows.Forms.TabPage tabPage1;
        private MetroFramework.Controls.MetroComboBox comboBox1;
        private MetroFramework.Controls.MetroComboBox comboBox2;
        private MetroFramework.Controls.MetroComboBox comboBox3;
        private MetroFramework.Controls.MetroLabel label115;
        private MetroFramework.Controls.MetroButton print_SQL;
        private MetroFramework.Controls.MetroButton design_SQL;
        private MetroFramework.Controls.MetroLabel label111;
        private MetroFramework.Controls.MetroLabel label112;
        private MetroFramework.Controls.MetroLabel label113;
        private MetroFramework.Controls.MetroLabel label114;
        private MetroFramework.Controls.MetroButton print_GenericList;
        private MetroFramework.Controls.MetroButton design_GenericList;
        private MetroFramework.Controls.MetroLabel label76;
        private MetroFramework.Controls.MetroLabel label77;
        private MetroFramework.Controls.MetroLabel label78;
        private MetroFramework.Controls.MetroLabel label79;
        private MetroFramework.Controls.MetroButton print_DataTable;
        private MetroFramework.Controls.MetroButton design_DataTable;
        private MetroFramework.Controls.MetroLabel label13;
        private MetroFramework.Controls.MetroLabel label99;
        private MetroFramework.Controls.MetroLabel label15;
        private MetroFramework.Controls.MetroLabel label16;
        private MetroFramework.Controls.MetroLabel label12;
        private MetroFramework.Controls.MetroButton print_Reader;
        private MetroFramework.Controls.MetroButton design_Reader;
        private MetroFramework.Controls.MetroLabel label9;
        private MetroFramework.Controls.MetroLabel label10;
        private MetroFramework.Controls.MetroLabel label11;
        private MetroFramework.Controls.MetroButton print_DataView;
        private MetroFramework.Controls.MetroButton design_DataView;
        private MetroFramework.Controls.MetroLabel label17;
        private MetroFramework.Controls.MetroLabel label18;
        private MetroFramework.Controls.MetroLabel label19;
        private MetroFramework.Controls.MetroLabel label20;
        private MetroFramework.Controls.MetroComboBox cbCustomerNames;
        private MetroFramework.Controls.MetroButton print_DataViewManager;
        private MetroFramework.Controls.MetroButton design_DataViewManager;
        private MetroFramework.Controls.MetroLabel label21;
        private MetroFramework.Controls.MetroLabel label22;
        private MetroFramework.Controls.MetroLabel label23;
        private MetroFramework.Controls.MetroLabel label24;
        private MetroFramework.Controls.MetroButton print_XML;
        private MetroFramework.Controls.MetroButton design_XML;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroButton print_DataSet;
        private MetroFramework.Controls.MetroButton design_DataSet;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Controls.MetroLabel label7;
        private MetroFramework.Controls.MetroLabel label8;
        private MetroFramework.Controls.MetroComboBox comboBox4;
        private MetroFramework.Controls.MetroComboBox comboBox5;
        private MetroFramework.Controls.MetroLabel label116;
        private MetroFramework.Controls.MetroButton printOdataBtn;
        private MetroFramework.Controls.MetroButton designOdataBtn;
        private MetroFramework.Controls.MetroLabel label117;
        private MetroFramework.Controls.MetroLabel label118;
        private MetroFramework.Controls.MetroLabel label119;
        private MetroFramework.Controls.MetroLabel label120;
        private MetroFramework.Controls.MetroButton restPrintBtn;
        private MetroFramework.Controls.MetroButton restDesignBtn;
        private MetroFramework.Controls.MetroLabel label202;
        private MetroFramework.Controls.MetroLabel label203;
        private MetroFramework.Controls.MetroLabel label204;
        private MetroFramework.Controls.MetroLabel label205;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private MetroFramework.Controls.MetroPanel metroPanel7;
        private MetroFramework.Controls.MetroPanel metroPanel8;
        private MetroFramework.Controls.MetroPanel metroPanel9;
        private MetroFramework.Controls.MetroPanel metroPanel10;
        private MetroFramework.Controls.MetroPanel metroPanel11;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
