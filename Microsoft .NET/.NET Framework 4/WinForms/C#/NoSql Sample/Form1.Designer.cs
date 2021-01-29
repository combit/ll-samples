namespace DataProvidersWithoutSolidStructure
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LL = new combit.Reporting.ListLabel(this.components);
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTable = new System.Windows.Forms.Label();
            this.buttonLogo = new System.Windows.Forms.Button();
            this.textBoxLogo = new System.Windows.Forms.TextBox();
            this.labelLogo = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonToAvailableFields = new System.Windows.Forms.Button();
            this.buttonToSelectedFields = new System.Windows.Forms.Button();
            this.listBoxSelectedFields = new System.Windows.Forms.ListBox();
            this.listBoxAvailableFields = new System.Windows.Forms.ListBox();
            this.labelSelectedFields = new System.Windows.Forms.Label();
            this.labelAvailableFields = new System.Windows.Forms.Label();
            this.buttonDesign = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDataProviderTest = new System.Windows.Forms.Button();
            this.buttonNextTabpage1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelDBName = new System.Windows.Forms.Label();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelKeyspace = new System.Windows.Forms.Label();
            this.textBoxKeyspace = new System.Windows.Forms.TextBox();
            this.labelObjects = new System.Windows.Forms.Label();
            this.textBoxObjects = new System.Windows.Forms.TextBox();
            this.labelDomain = new System.Windows.Forms.Label();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.labelTableID = new System.Windows.Forms.Label();
            this.textBoxTableID = new System.Windows.Forms.TextBox();
            this.checkBoxFirstRowAreColumnNames = new System.Windows.Forms.CheckBox();
            this.labelRefreshToken = new System.Windows.Forms.Label();
            this.textBoxRefreshToken = new System.Windows.Forms.TextBox();
            this.textBoxClientID = new System.Windows.Forms.TextBox();
            this.labelClientSecret = new System.Windows.Forms.Label();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.labelClientID = new System.Windows.Forms.Label();
            this.labelProvider = new System.Windows.Forms.Label();
            this.comboBoxDataProvider = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonBackTabpage2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(52, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(422, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dieses Beispiel zeigt die Verwendung von NoSql Datenprovidern.";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "US:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(52, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(422, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "This sample shows the usage of NoSql data providers.";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(23, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "D:  ";
            // 
            // LL
            // 
            this.LL.AutoDestination = combit.Reporting.LlPrintMode.Preview;
            this.LL.AutoPrinterSettingsStream = null;
            this.LL.AutoProjectStream = null;
            this.LL.AutoShowPrintOptions = false;
            this.LL.AutoShowSelectFile = false;
            this.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad;
            this.LL.DrilldownAvailable = true;
            this.LL.EMFResolution = 100;
            this.LL.FileRepository = null;
            this.LL.GenericMaximumRecordCount = -1;
            this.LL.LockNextChar = 8288;
            this.LL.MaxRTFVersion = 65280;
            this.LL.PhantomSpace = 8203;
            this.LL.PreviewControl = null;
            this.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_10;
            this.LL.UseHardwareCopiesForLabels = false;
            this.LL.UseTableSchemaForDesignMode = false;
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.ItemHeight = 13;
            this.comboBoxTable.Location = new System.Drawing.Point(6, 43);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(602, 21);
            this.comboBoxTable.TabIndex = 11;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTable_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.labelTable);
            this.groupBox1.Controls.Add(this.buttonLogo);
            this.groupBox1.Controls.Add(this.textBoxLogo);
            this.groupBox1.Controls.Add(this.labelLogo);
            this.groupBox1.Controls.Add(this.textBoxTitle);
            this.groupBox1.Controls.Add(this.labelTitle);
            this.groupBox1.Controls.Add(this.buttonToAvailableFields);
            this.groupBox1.Controls.Add(this.buttonToSelectedFields);
            this.groupBox1.Controls.Add(this.listBoxSelectedFields);
            this.groupBox1.Controls.Add(this.listBoxAvailableFields);
            this.groupBox1.Controls.Add(this.labelSelectedFields);
            this.groupBox1.Controls.Add(this.labelAvailableFields);
            this.groupBox1.Controls.Add(this.comboBoxTable);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 337);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Layout";
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Location = new System.Drawing.Point(7, 22);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(37, 13);
            this.labelTable.TabIndex = 21;
            this.labelTable.Text = "Table:";
            // 
            // buttonLogo
            // 
            this.buttonLogo.Location = new System.Drawing.Point(581, 305);
            this.buttonLogo.Name = "buttonLogo";
            this.buttonLogo.Size = new System.Drawing.Size(27, 19);
            this.buttonLogo.TabIndex = 18;
            this.buttonLogo.Text = "...";
            this.buttonLogo.Click += new System.EventHandler(this.ButtonLogo_Click);
            // 
            // textBoxLogo
            // 
            this.textBoxLogo.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLogo.Location = new System.Drawing.Point(6, 304);
            this.textBoxLogo.Name = "textBoxLogo";
            this.textBoxLogo.Size = new System.Drawing.Size(569, 20);
            this.textBoxLogo.TabIndex = 17;
            // 
            // labelLogo
            // 
            this.labelLogo.AutoSize = true;
            this.labelLogo.Location = new System.Drawing.Point(6, 283);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(34, 13);
            this.labelLogo.TabIndex = 18;
            this.labelLogo.Text = "Logo:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTitle.Location = new System.Drawing.Point(6, 256);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(602, 20);
            this.textBoxTitle.TabIndex = 16;
            this.textBoxTitle.Text = "Dynamically created project";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(7, 235);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(30, 13);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.Text = "Title:";
            // 
            // buttonToAvailableFields
            // 
            this.buttonToAvailableFields.Location = new System.Drawing.Point(290, 163);
            this.buttonToAvailableFields.Name = "buttonToAvailableFields";
            this.buttonToAvailableFields.Size = new System.Drawing.Size(35, 30);
            this.buttonToAvailableFields.TabIndex = 15;
            this.buttonToAvailableFields.Text = "<";
            this.buttonToAvailableFields.Click += new System.EventHandler(this.SelectField_Click);
            // 
            // buttonToSelectedFields
            // 
            this.buttonToSelectedFields.Location = new System.Drawing.Point(290, 127);
            this.buttonToSelectedFields.Name = "buttonToSelectedFields";
            this.buttonToSelectedFields.Size = new System.Drawing.Size(35, 30);
            this.buttonToSelectedFields.TabIndex = 13;
            this.buttonToSelectedFields.Text = ">";
            this.buttonToSelectedFields.Click += new System.EventHandler(this.SelectField_Click);
            // 
            // listBoxSelectedFields
            // 
            this.listBoxSelectedFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxSelectedFields.Location = new System.Drawing.Point(331, 96);
            this.listBoxSelectedFields.Name = "listBoxSelectedFields";
            this.listBoxSelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSelectedFields.Size = new System.Drawing.Size(277, 121);
            this.listBoxSelectedFields.Sorted = true;
            this.listBoxSelectedFields.TabIndex = 14;
            this.listBoxSelectedFields.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxSelectedFields_DrawItem);
            this.listBoxSelectedFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxSelectedFields_MouseDoubleClick);
            // 
            // listBoxAvailableFields
            // 
            this.listBoxAvailableFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxAvailableFields.Location = new System.Drawing.Point(6, 96);
            this.listBoxAvailableFields.Name = "listBoxAvailableFields";
            this.listBoxAvailableFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAvailableFields.Size = new System.Drawing.Size(278, 121);
            this.listBoxAvailableFields.Sorted = true;
            this.listBoxAvailableFields.TabIndex = 12;
            this.listBoxAvailableFields.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxAvailableFields_DrawItem);
            this.listBoxAvailableFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxAvailableFields_MouseDoubleClick);
            // 
            // labelSelectedFields
            // 
            this.labelSelectedFields.AutoSize = true;
            this.labelSelectedFields.Location = new System.Drawing.Point(331, 75);
            this.labelSelectedFields.Name = "labelSelectedFields";
            this.labelSelectedFields.Size = new System.Drawing.Size(82, 13);
            this.labelSelectedFields.TabIndex = 11;
            this.labelSelectedFields.Text = "Selected Fields:";
            // 
            // labelAvailableFields
            // 
            this.labelAvailableFields.AutoSize = true;
            this.labelAvailableFields.Location = new System.Drawing.Point(7, 75);
            this.labelAvailableFields.Name = "labelAvailableFields";
            this.labelAvailableFields.Size = new System.Drawing.Size(83, 13);
            this.labelAvailableFields.TabIndex = 10;
            this.labelAvailableFields.Text = "Available Fields:";
            // 
            // buttonDesign
            // 
            this.buttonDesign.Location = new System.Drawing.Point(402, 353);
            this.buttonDesign.Name = "buttonDesign";
            this.buttonDesign.Size = new System.Drawing.Size(106, 26);
            this.buttonDesign.TabIndex = 19;
            this.buttonDesign.Text = "Design...";
            this.buttonDesign.Click += new System.EventHandler(this.DesignProject_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "sunshine.gif";
            this.openFileDialog1.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|A" +
    "ll Files (*.*)|*.*";
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(514, 353);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(106, 26);
            this.buttonPreview.TabIndex = 20;
            this.buttonPreview.Text = "Preview...";
            this.buttonPreview.Click += new System.EventHandler(this.PrintProject_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 66);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(631, 427);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDataProviderTest);
            this.tabPage1.Controls.Add(this.buttonNextTabpage1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.labelProvider);
            this.tabPage1.Controls.Add(this.comboBoxDataProvider);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(623, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. Data provider settings";
            // 
            // buttonDataProviderTest
            // 
            this.buttonDataProviderTest.Location = new System.Drawing.Point(402, 353);
            this.buttonDataProviderTest.Name = "buttonDataProviderTest";
            this.buttonDataProviderTest.Size = new System.Drawing.Size(106, 26);
            this.buttonDataProviderTest.TabIndex = 9;
            this.buttonDataProviderTest.Text = "Test";
            this.buttonDataProviderTest.Click += new System.EventHandler(this.ButtonDataProviderTest_Click);
            // 
            // buttonNextTabpage1
            // 
            this.buttonNextTabpage1.Enabled = false;
            this.buttonNextTabpage1.Location = new System.Drawing.Point(514, 353);
            this.buttonNextTabpage1.Name = "buttonNextTabpage1";
            this.buttonNextTabpage1.Size = new System.Drawing.Size(106, 26);
            this.buttonNextTabpage1.TabIndex = 10;
            this.buttonNextTabpage1.Text = "Next >";
            this.buttonNextTabpage1.Click += new System.EventHandler(this.ButtonNavigate);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(3, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(617, 298);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Provider Parameter";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelAddress);
            this.flowLayoutPanel1.Controls.Add(this.textBoxAddress);
            this.flowLayoutPanel1.Controls.Add(this.labelUsername);
            this.flowLayoutPanel1.Controls.Add(this.textBoxUsername);
            this.flowLayoutPanel1.Controls.Add(this.labelPassword);
            this.flowLayoutPanel1.Controls.Add(this.textBoxPassword);
            this.flowLayoutPanel1.Controls.Add(this.labelDBName);
            this.flowLayoutPanel1.Controls.Add(this.textBoxDBName);
            this.flowLayoutPanel1.Controls.Add(this.labelPort);
            this.flowLayoutPanel1.Controls.Add(this.textBoxPort);
            this.flowLayoutPanel1.Controls.Add(this.labelKeyspace);
            this.flowLayoutPanel1.Controls.Add(this.textBoxKeyspace);
            this.flowLayoutPanel1.Controls.Add(this.labelObjects);
            this.flowLayoutPanel1.Controls.Add(this.textBoxObjects);
            this.flowLayoutPanel1.Controls.Add(this.labelDomain);
            this.flowLayoutPanel1.Controls.Add(this.textBoxDomain);
            this.flowLayoutPanel1.Controls.Add(this.labelTableID);
            this.flowLayoutPanel1.Controls.Add(this.textBoxTableID);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxFirstRowAreColumnNames);
            this.flowLayoutPanel1.Controls.Add(this.labelRefreshToken);
            this.flowLayoutPanel1.Controls.Add(this.textBoxRefreshToken);
            this.flowLayoutPanel1.Controls.Add(this.textBoxClientID);
            this.flowLayoutPanel1.Controls.Add(this.labelClientSecret);
            this.flowLayoutPanel1.Controls.Add(this.textBoxClientSecret);
            this.flowLayoutPanel1.Controls.Add(this.labelClientID);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(605, 273);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(3, 5);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 22;
            this.labelAddress.Text = "Address:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxAddress.Location = new System.Drawing.Point(3, 26);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(599, 20);
            this.textBoxAddress.TabIndex = 2;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(3, 54);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 24;
            this.labelUsername.Text = "Username:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUsername.Location = new System.Drawing.Point(3, 75);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(599, 20);
            this.textBoxUsername.TabIndex = 3;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(3, 103);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 26;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPassword.Location = new System.Drawing.Point(3, 124);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(599, 20);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelDBName
            // 
            this.labelDBName.AutoSize = true;
            this.labelDBName.Location = new System.Drawing.Point(3, 152);
            this.labelDBName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelDBName.Name = "labelDBName";
            this.labelDBName.Size = new System.Drawing.Size(85, 13);
            this.labelDBName.TabIndex = 31;
            this.labelDBName.Text = "Database name:";
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDBName.Location = new System.Drawing.Point(3, 173);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(599, 20);
            this.textBoxDBName.TabIndex = 5;
            this.textBoxDBName.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(3, 201);
            this.labelPort.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 33;
            this.labelPort.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPort.Location = new System.Drawing.Point(3, 222);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(599, 20);
            this.textBoxPort.TabIndex = 6;
            this.textBoxPort.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelKeyspace
            // 
            this.labelKeyspace.AutoSize = true;
            this.labelKeyspace.Location = new System.Drawing.Point(3, 250);
            this.labelKeyspace.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelKeyspace.Name = "labelKeyspace";
            this.labelKeyspace.Size = new System.Drawing.Size(57, 13);
            this.labelKeyspace.TabIndex = 36;
            this.labelKeyspace.Text = "Keyspace:";
            // 
            // textBoxKeyspace
            // 
            this.textBoxKeyspace.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxKeyspace.Location = new System.Drawing.Point(608, 3);
            this.textBoxKeyspace.Name = "textBoxKeyspace";
            this.textBoxKeyspace.Size = new System.Drawing.Size(599, 20);
            this.textBoxKeyspace.TabIndex = 7;
            this.textBoxKeyspace.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelObjects
            // 
            this.labelObjects.AutoSize = true;
            this.labelObjects.Location = new System.Drawing.Point(608, 31);
            this.labelObjects.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelObjects.Name = "labelObjects";
            this.labelObjects.Size = new System.Drawing.Size(175, 13);
            this.labelObjects.TabIndex = 35;
            this.labelObjects.Text = "Tables (comma-separated) optional:";
            // 
            // textBoxObjects
            // 
            this.textBoxObjects.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxObjects.Location = new System.Drawing.Point(608, 52);
            this.textBoxObjects.Name = "textBoxObjects";
            this.textBoxObjects.Size = new System.Drawing.Size(599, 20);
            this.textBoxObjects.TabIndex = 8;
            this.textBoxObjects.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelDomain
            // 
            this.labelDomain.AutoSize = true;
            this.labelDomain.Location = new System.Drawing.Point(608, 80);
            this.labelDomain.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelDomain.Name = "labelDomain";
            this.labelDomain.Size = new System.Drawing.Size(46, 13);
            this.labelDomain.TabIndex = 24;
            this.labelDomain.Text = "Domain:";
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDomain.Location = new System.Drawing.Point(608, 101);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(599, 20);
            this.textBoxDomain.TabIndex = 23;
            this.textBoxDomain.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelTableID
            // 
            this.labelTableID.AutoSize = true;
            this.labelTableID.Location = new System.Drawing.Point(608, 129);
            this.labelTableID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelTableID.Name = "labelTableID";
            this.labelTableID.Size = new System.Drawing.Size(51, 13);
            this.labelTableID.TabIndex = 24;
            this.labelTableID.Text = "Table ID:";
            // 
            // textBoxTableID
            // 
            this.textBoxTableID.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTableID.Location = new System.Drawing.Point(608, 150);
            this.textBoxTableID.Name = "textBoxTableID";
            this.textBoxTableID.Size = new System.Drawing.Size(599, 20);
            this.textBoxTableID.TabIndex = 23;
            this.textBoxTableID.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // checkBoxFirstRowAreColumnNames
            // 
            this.checkBoxFirstRowAreColumnNames.AutoSize = true;
            this.checkBoxFirstRowAreColumnNames.Location = new System.Drawing.Point(608, 183);
            this.checkBoxFirstRowAreColumnNames.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.checkBoxFirstRowAreColumnNames.Name = "checkBoxFirstRowAreColumnNames";
            this.checkBoxFirstRowAreColumnNames.Size = new System.Drawing.Size(198, 17);
            this.checkBoxFirstRowAreColumnNames.TabIndex = 24;
            this.checkBoxFirstRowAreColumnNames.Text = "The first row contains column names";
            this.checkBoxFirstRowAreColumnNames.CheckedChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelRefreshToken
            // 
            this.labelRefreshToken.AutoSize = true;
            this.labelRefreshToken.Location = new System.Drawing.Point(608, 215);
            this.labelRefreshToken.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelRefreshToken.Name = "labelRefreshToken";
            this.labelRefreshToken.Size = new System.Drawing.Size(77, 13);
            this.labelRefreshToken.TabIndex = 24;
            this.labelRefreshToken.Text = "Refresh token:";
            // 
            // textBoxRefreshToken
            // 
            this.textBoxRefreshToken.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRefreshToken.Location = new System.Drawing.Point(608, 236);
            this.textBoxRefreshToken.Name = "textBoxRefreshToken";
            this.textBoxRefreshToken.Size = new System.Drawing.Size(599, 20);
            this.textBoxRefreshToken.TabIndex = 23;
            this.textBoxRefreshToken.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // textBoxClientID
            // 
            this.textBoxClientID.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxClientID.Location = new System.Drawing.Point(1213, 3);
            this.textBoxClientID.Name = "textBoxClientID";
            this.textBoxClientID.Size = new System.Drawing.Size(599, 20);
            this.textBoxClientID.TabIndex = 25;
            this.textBoxClientID.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelClientSecret
            // 
            this.labelClientSecret.AutoSize = true;
            this.labelClientSecret.Location = new System.Drawing.Point(1213, 31);
            this.labelClientSecret.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelClientSecret.Name = "labelClientSecret";
            this.labelClientSecret.Size = new System.Drawing.Size(68, 13);
            this.labelClientSecret.TabIndex = 26;
            this.labelClientSecret.Text = "Client secret:";
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxClientSecret.Location = new System.Drawing.Point(1213, 52);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.Size = new System.Drawing.Size(599, 20);
            this.textBoxClientSecret.TabIndex = 25;
            this.textBoxClientSecret.TextChanged += new System.EventHandler(this.ControlInputChanged);
            // 
            // labelClientID
            // 
            this.labelClientID.AutoSize = true;
            this.labelClientID.Location = new System.Drawing.Point(1213, 80);
            this.labelClientID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelClientID.Name = "labelClientID";
            this.labelClientID.Size = new System.Drawing.Size(50, 13);
            this.labelClientID.TabIndex = 26;
            this.labelClientID.Text = "Client ID:";
            // 
            // labelProvider
            // 
            this.labelProvider.AutoSize = true;
            this.labelProvider.Location = new System.Drawing.Point(3, 0);
            this.labelProvider.Name = "labelProvider";
            this.labelProvider.Size = new System.Drawing.Size(49, 13);
            this.labelProvider.TabIndex = 26;
            this.labelProvider.Text = "Provider:";
            // 
            // comboBoxDataProvider
            // 
            this.comboBoxDataProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataProvider.ItemHeight = 13;
            this.comboBoxDataProvider.Location = new System.Drawing.Point(3, 18);
            this.comboBoxDataProvider.Name = "comboBoxDataProvider";
            this.comboBoxDataProvider.Size = new System.Drawing.Size(617, 21);
            this.comboBoxDataProvider.TabIndex = 1;
            this.comboBoxDataProvider.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProvider_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonBackTabpage2);
            this.tabPage2.Controls.Add(this.buttonDesign);
            this.tabPage2.Controls.Add(this.buttonPreview);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(623, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2. Project settings";
            // 
            // buttonBackTabpage2
            // 
            this.buttonBackTabpage2.Location = new System.Drawing.Point(3, 353);
            this.buttonBackTabpage2.Name = "buttonBackTabpage2";
            this.buttonBackTabpage2.Size = new System.Drawing.Size(106, 26);
            this.buttonBackTabpage2.TabIndex = 21;
            this.buttonBackTabpage2.Text = "< Back";
            this.buttonBackTabpage2.Click += new System.EventHandler(this.ButtonNavigate);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 489);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List & Label C# NoSql DataProvider Sample";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private combit.Reporting.ListLabel LL;
        private System.Windows.Forms.ComboBox comboBoxTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelSelectedFields;
        private System.Windows.Forms.Label labelAvailableFields;
        private System.Windows.Forms.ListBox listBoxAvailableFields;
        private System.Windows.Forms.Button buttonToAvailableFields;
        private System.Windows.Forms.Button buttonToSelectedFields;
        private System.Windows.Forms.ListBox listBoxSelectedFields;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonLogo;
        private System.Windows.Forms.TextBox textBoxLogo;
        private System.Windows.Forms.Label labelTable;
        private System.Windows.Forms.Button buttonDesign;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        #endregion
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelDBName;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelKeyspace;
        private System.Windows.Forms.TextBox textBoxKeyspace;
        private System.Windows.Forms.Label labelObjects;
        private System.Windows.Forms.TextBox textBoxObjects;
        private System.Windows.Forms.Label labelProvider;
        private System.Windows.Forms.ComboBox comboBoxDataProvider;
        private System.Windows.Forms.Button buttonNextTabpage1;
        private System.Windows.Forms.Button buttonDataProviderTest;
        private System.Windows.Forms.Button buttonBackTabpage2;
        private System.Windows.Forms.Label labelDomain;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.Label labelTableID;
        private System.Windows.Forms.TextBox textBoxTableID;
        private System.Windows.Forms.CheckBox checkBoxFirstRowAreColumnNames;
        private System.Windows.Forms.Label labelRefreshToken;
        private System.Windows.Forms.TextBox textBoxRefreshToken;
        private System.Windows.Forms.Label labelClientID;
        private System.Windows.Forms.TextBox textBoxClientID;
        private System.Windows.Forms.Label labelClientSecret;
        private System.Windows.Forms.TextBox textBoxClientSecret;
    }
}
