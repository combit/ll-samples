Partial Class Form1
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer = Nothing
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LL = new combit.Reporting.ListLabel(Me.components)
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelAddress = New System.Windows.Forms.Label()
        Me.TextBoxAddress = New System.Windows.Forms.TextBox()
        Me.LabelUserName = New System.Windows.Forms.Label()
        Me.TextBoxUsername = New System.Windows.Forms.TextBox()
        Me.LabelPassword = New System.Windows.Forms.Label()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.LabelDBName = New System.Windows.Forms.Label()
        Me.TextBoxDBName = New System.Windows.Forms.TextBox()
        Me.LabelPort = New System.Windows.Forms.Label()
        Me.TextBoxPort = New System.Windows.Forms.TextBox()
        Me.TextBoxKeySpace = New System.Windows.Forms.TextBox()
        Me.TextBoxObjects = New System.Windows.Forms.TextBox()
        Me.TextBoxDomain = New System.Windows.Forms.TextBox()
        Me.TextBoxTableID = New System.Windows.Forms.TextBox()
        Me.CheckBoxFirstRowAreColumnNames = New System.Windows.Forms.CheckBox()
        Me.TextBoxRefreshToken = New System.Windows.Forms.TextBox()
        Me.TextBoxClientID = New System.Windows.Forms.TextBox()
        Me.TextBoxClientSecret = New System.Windows.Forms.TextBox()
        Me.LabelKeyspace = New System.Windows.Forms.Label()
        Me.LabelObjects = New System.Windows.Forms.Label()
        Me.LabelDomain = New System.Windows.Forms.Label()
        Me.LabelTableID = New System.Windows.Forms.Label()
        Me.LabelRefreshToken = New System.Windows.Forms.Label()
        Me.LabelClientID = New System.Windows.Forms.Label()
        Me.LabelClientSecret = New System.Windows.Forms.Label()
        Me.LabelProvider = New System.Windows.Forms.Label()
        Me.ComboBoxDataProvider = New System.Windows.Forms.ComboBox()
        Me.ButtonNextTabpage1 = New System.Windows.Forms.Button()
        Me.buttonDataProviderTest = New System.Windows.Forms.Button()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.ButtonPreview = New System.Windows.Forms.Button()
        Me.ButtonDesign = New System.Windows.Forms.Button()
        Me.ButtonBackTabpage2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonLogo = New System.Windows.Forms.Button()
        Me.TextBoxLogo = New System.Windows.Forms.TextBox()
        Me.LabelLogo = New System.Windows.Forms.Label()
        Me.TextBoxTitle = New System.Windows.Forms.TextBox()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.buttonToAvailableFields = New System.Windows.Forms.Button()
        Me.buttonToSelectedFields = New System.Windows.Forms.Button()
        Me.ListBoxSelectedFields = New System.Windows.Forms.ListBox()
        Me.ListBoxAvailableFields = New System.Windows.Forms.ListBox()
        Me.LabelSelectedFields = New System.Windows.Forms.Label()
        Me.LabelAvailableFields = New System.Windows.Forms.Label()
        Me.ComboBoxTable = New System.Windows.Forms.ComboBox()
        Me.LabelTable = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LL
        '
        Me.LL.AutoDestination = combit.Reporting.LlPrintMode.Preview
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.AutoShowPrintOptions = False
        Me.LL.AutoShowSelectFile = False
        Me.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.GenericMaximumRecordCount = -1
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'tabControl1
        '
        Me.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Location = New System.Drawing.Point(10, 55)
        Me.tabControl1.Multiline = True
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(631, 427)
        Me.tabControl1.TabIndex = 15
        '
        'tabPage1
        '
        Me.tabPage1.BackColor = System.Drawing.Color.Transparent
        Me.tabPage1.Controls.Add(Me.GroupBox2)
        Me.tabPage1.Controls.Add(Me.LabelProvider)
        Me.tabPage1.Controls.Add(Me.ComboBoxDataProvider)
        Me.tabPage1.Controls.Add(Me.ButtonNextTabpage1)
        Me.tabPage1.Controls.Add(Me.buttonDataProviderTest)
        Me.tabPage1.Location = New System.Drawing.Point(4, 25)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Size = New System.Drawing.Size(623, 398)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "1. Data provider settings"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(617, 298)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Provider Parameter"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelAddress)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxAddress)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelUserName)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxUsername)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelPassword)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxPassword)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelDBName)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxDBName)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelPort)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxPort)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxKeySpace)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxObjects)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxDomain)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxTableID)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBoxFirstRowAreColumnNames)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxRefreshToken)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxClientID)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxClientSecret)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelKeyspace)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelObjects)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelDomain)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelTableID)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelRefreshToken)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelClientID)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelClientSecret)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 19)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(605, 273)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'LabelAddress
        '
        Me.LabelAddress.AutoSize = True
        Me.LabelAddress.Location = New System.Drawing.Point(3, 5)
        Me.LabelAddress.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelAddress.Name = "LabelAddress"
        Me.LabelAddress.Size = New System.Drawing.Size(51, 13)
        Me.LabelAddress.TabIndex = 0
        Me.LabelAddress.Text = "Address:"
        '
        'TextBoxAddress
        '
        Me.TextBoxAddress.Location = New System.Drawing.Point(3, 26)
        Me.TextBoxAddress.Name = "TextBoxAddress"
        Me.TextBoxAddress.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxAddress.TabIndex = 1
        '
        'LabelUserName
        '
        Me.LabelUserName.AutoSize = True
        Me.LabelUserName.Location = New System.Drawing.Point(3, 56)
        Me.LabelUserName.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(61, 13)
        Me.LabelUserName.TabIndex = 2
        Me.LabelUserName.Text = "Username:"
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Location = New System.Drawing.Point(3, 77)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxUsername.TabIndex = 3
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.Location = New System.Drawing.Point(3, 107)
        Me.LabelPassword.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(59, 13)
        Me.LabelPassword.TabIndex = 4
        Me.LabelPassword.Text = "Password:"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(3, 128)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxPassword.TabIndex = 5
        '
        'LabelDBName
        '
        Me.LabelDBName.AutoSize = True
        Me.LabelDBName.Location = New System.Drawing.Point(3, 158)
        Me.LabelDBName.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelDBName.Name = "LabelDBName"
        Me.LabelDBName.Size = New System.Drawing.Size(89, 13)
        Me.LabelDBName.TabIndex = 6
        Me.LabelDBName.Text = "Database name:"
        '
        'TextBoxDBName
        '
        Me.TextBoxDBName.Location = New System.Drawing.Point(3, 179)
        Me.TextBoxDBName.Name = "TextBoxDBName"
        Me.TextBoxDBName.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxDBName.TabIndex = 7
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = True
        Me.LabelPort.Location = New System.Drawing.Point(3, 209)
        Me.LabelPort.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(31, 13)
        Me.LabelPort.TabIndex = 8
        Me.LabelPort.Text = "Port:"
        '
        'TextBoxPort
        '
        Me.TextBoxPort.Location = New System.Drawing.Point(3, 230)
        Me.TextBoxPort.Name = "TextBoxPort"
        Me.TextBoxPort.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxPort.TabIndex = 9
        '
        'TextBoxKeySpace
        '
        Me.TextBoxKeySpace.Location = New System.Drawing.Point(608, 3)
        Me.TextBoxKeySpace.Name = "TextBoxKeySpace"
        Me.TextBoxKeySpace.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxKeySpace.TabIndex = 10
        '
        'TextBoxObjects
        '
        Me.TextBoxObjects.Location = New System.Drawing.Point(608, 31)
        Me.TextBoxObjects.Name = "TextBoxObjects"
        Me.TextBoxObjects.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxObjects.TabIndex = 11
        '
        'TextBoxDomain
        '
        Me.TextBoxDomain.Location = New System.Drawing.Point(608, 59)
        Me.TextBoxDomain.Name = "TextBoxDomain"
        Me.TextBoxDomain.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxDomain.TabIndex = 12
        '
        'TextBoxTableID
        '
        Me.TextBoxTableID.Location = New System.Drawing.Point(608, 87)
        Me.TextBoxTableID.Name = "TextBoxTableID"
        Me.TextBoxTableID.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxTableID.TabIndex = 13
        '
        'CheckBoxFirstRowAreColumnNames
        '
        Me.CheckBoxFirstRowAreColumnNames.AutoSize = True
        Me.CheckBoxFirstRowAreColumnNames.Location = New System.Drawing.Point(608, 122)
        Me.CheckBoxFirstRowAreColumnNames.Margin = New System.Windows.Forms.Padding(3, 10, 3, 10)
        Me.CheckBoxFirstRowAreColumnNames.Name = "CheckBoxFirstRowAreColumnNames"
        Me.CheckBoxFirstRowAreColumnNames.Size = New System.Drawing.Size(214, 17)
        Me.CheckBoxFirstRowAreColumnNames.TabIndex = 14
        Me.CheckBoxFirstRowAreColumnNames.Text = "The first row contains column names"
        '
        'TextBoxRefreshToken
        '
        Me.TextBoxRefreshToken.Location = New System.Drawing.Point(608, 152)
        Me.TextBoxRefreshToken.Name = "TextBoxRefreshToken"
        Me.TextBoxRefreshToken.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxRefreshToken.TabIndex = 15
        Me.TextBoxRefreshToken.Text = "textBox1"
        '
        'TextBoxClientID
        '
        Me.TextBoxClientID.Location = New System.Drawing.Point(608, 180)
        Me.TextBoxClientID.Name = "TextBoxClientID"
        Me.TextBoxClientID.Size = New System.Drawing.Size(75, 22)
        Me.TextBoxClientID.TabIndex = 16
        '
        'TextBoxClientSecret
        '
        Me.TextBoxClientSecret.Location = New System.Drawing.Point(608, 208)
        Me.TextBoxClientSecret.Name = "TextBoxClientSecret"
        Me.TextBoxClientSecret.Size = New System.Drawing.Size(599, 22)
        Me.TextBoxClientSecret.TabIndex = 17
        '
        'LabelKeyspace
        '
        Me.LabelKeyspace.AutoSize = True
        Me.LabelKeyspace.Location = New System.Drawing.Point(608, 238)
        Me.LabelKeyspace.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelKeyspace.Name = "LabelKeyspace"
        Me.LabelKeyspace.Size = New System.Drawing.Size(56, 13)
        Me.LabelKeyspace.TabIndex = 18
        Me.LabelKeyspace.Text = "Keyspace:"
        '
        'LabelObjects
        '
        Me.LabelObjects.AutoSize = True
        Me.LabelObjects.Location = New System.Drawing.Point(1213, 5)
        Me.LabelObjects.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelObjects.Name = "LabelObjects"
        Me.LabelObjects.Size = New System.Drawing.Size(148, 13)
        Me.LabelObjects.TabIndex = 19
        Me.LabelObjects.Text = "Objects (comma seperated):"
        '
        'LabelDomain
        '
        Me.LabelDomain.AutoSize = True
        Me.LabelDomain.Location = New System.Drawing.Point(1213, 28)
        Me.LabelDomain.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelDomain.Name = "LabelDomain"
        Me.LabelDomain.Size = New System.Drawing.Size(50, 13)
        Me.LabelDomain.TabIndex = 20
        Me.LabelDomain.Text = "Domain:"
        '
        'LabelTableID
        '
        Me.LabelTableID.AutoSize = True
        Me.LabelTableID.Location = New System.Drawing.Point(1213, 46)
        Me.LabelTableID.Name = "LabelTableID"
        Me.LabelTableID.Size = New System.Drawing.Size(50, 13)
        Me.LabelTableID.TabIndex = 21
        Me.LabelTableID.Text = "Table ID:"
        '
        'LabelRefreshToken
        '
        Me.LabelRefreshToken.AutoSize = True
        Me.LabelRefreshToken.Location = New System.Drawing.Point(1213, 64)
        Me.LabelRefreshToken.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelRefreshToken.Name = "LabelRefreshToken"
        Me.LabelRefreshToken.Size = New System.Drawing.Size(82, 13)
        Me.LabelRefreshToken.TabIndex = 22
        Me.LabelRefreshToken.Text = "Refresh token:"
        '
        'LabelClientID
        '
        Me.LabelClientID.AutoSize = True
        Me.LabelClientID.Location = New System.Drawing.Point(1213, 87)
        Me.LabelClientID.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelClientID.Name = "LabelClientID"
        Me.LabelClientID.Size = New System.Drawing.Size(54, 13)
        Me.LabelClientID.TabIndex = 23
        Me.LabelClientID.Text = "Client ID:"
        '
        'LabelClientSecret
        '
        Me.LabelClientSecret.AutoSize = True
        Me.LabelClientSecret.Location = New System.Drawing.Point(1213, 110)
        Me.LabelClientSecret.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LabelClientSecret.Name = "LabelClientSecret"
        Me.LabelClientSecret.Size = New System.Drawing.Size(73, 13)
        Me.LabelClientSecret.TabIndex = 24
        Me.LabelClientSecret.Text = "Client secret:"
        '
        'LabelProvider
        '
        Me.LabelProvider.AutoSize = True
        Me.LabelProvider.Location = New System.Drawing.Point(3, 0)
        Me.LabelProvider.Name = "LabelProvider"
        Me.LabelProvider.Size = New System.Drawing.Size(49, 13)
        Me.LabelProvider.TabIndex = 19
        Me.LabelProvider.Text = "Provider:"
        '
        'ComboBoxDataProvider
        '
        Me.ComboBoxDataProvider.DropDownWidth = 617
        Me.ComboBoxDataProvider.ItemHeight = 13
        Me.ComboBoxDataProvider.Location = New System.Drawing.Point(3, 18)
        Me.ComboBoxDataProvider.Name = "ComboBoxDataProvider"
        Me.ComboBoxDataProvider.Size = New System.Drawing.Size(617, 21)
        Me.ComboBoxDataProvider.TabIndex = 18
        '
        'ButtonNextTabpage1
        '
        Me.ButtonNextTabpage1.Enabled = False
        Me.ButtonNextTabpage1.Location = New System.Drawing.Point(514, 353)
        Me.ButtonNextTabpage1.Name = "ButtonNextTabpage1"
        Me.ButtonNextTabpage1.Size = New System.Drawing.Size(106, 26)
        Me.ButtonNextTabpage1.TabIndex = 17
        Me.ButtonNextTabpage1.Text = "Next >"
        '
        'buttonDataProviderTest
        '
        Me.buttonDataProviderTest.BackColor = System.Drawing.SystemColors.Control
        Me.buttonDataProviderTest.Location = New System.Drawing.Point(402, 353)
        Me.buttonDataProviderTest.Name = "buttonDataProviderTest"
        Me.buttonDataProviderTest.Size = New System.Drawing.Size(106, 26)
        Me.buttonDataProviderTest.TabIndex = 1
        Me.buttonDataProviderTest.Text = "Test"
        Me.buttonDataProviderTest.UseVisualStyleBackColor = False
        '
        'tabPage2
        '
        Me.tabPage2.BackColor = System.Drawing.Color.Transparent
        Me.tabPage2.Controls.Add(Me.ButtonPreview)
        Me.tabPage2.Controls.Add(Me.ButtonDesign)
        Me.tabPage2.Controls.Add(Me.ButtonBackTabpage2)
        Me.tabPage2.Controls.Add(Me.GroupBox1)
        Me.tabPage2.Location = New System.Drawing.Point(4, 25)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(623, 398)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "2. Project settings"
        '
        'ButtonPreview
        '
        Me.ButtonPreview.Location = New System.Drawing.Point(514, 348)
        Me.ButtonPreview.Name = "ButtonPreview"
        Me.ButtonPreview.Size = New System.Drawing.Size(106, 26)
        Me.ButtonPreview.TabIndex = 16
        Me.ButtonPreview.Text = "Preview..."
        '
        'ButtonDesign
        '
        Me.ButtonDesign.Location = New System.Drawing.Point(402, 348)
        Me.ButtonDesign.Name = "ButtonDesign"
        Me.ButtonDesign.Size = New System.Drawing.Size(106, 26)
        Me.ButtonDesign.TabIndex = 15
        Me.ButtonDesign.Text = "Design..."
        '
        'ButtonBackTabpage2
        '
        Me.ButtonBackTabpage2.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonBackTabpage2.Location = New System.Drawing.Point(3, 348)
        Me.ButtonBackTabpage2.Name = "ButtonBackTabpage2"
        Me.ButtonBackTabpage2.Size = New System.Drawing.Size(106, 26)
        Me.ButtonBackTabpage2.TabIndex = 14
        Me.ButtonBackTabpage2.Text = "< Back"
        Me.ButtonBackTabpage2.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.ButtonLogo)
        Me.GroupBox1.Controls.Add(Me.TextBoxLogo)
        Me.GroupBox1.Controls.Add(Me.LabelLogo)
        Me.GroupBox1.Controls.Add(Me.TextBoxTitle)
        Me.GroupBox1.Controls.Add(Me.LabelTitle)
        Me.GroupBox1.Controls.Add(Me.buttonToAvailableFields)
        Me.GroupBox1.Controls.Add(Me.buttonToSelectedFields)
        Me.GroupBox1.Controls.Add(Me.ListBoxSelectedFields)
        Me.GroupBox1.Controls.Add(Me.ListBoxAvailableFields)
        Me.GroupBox1.Controls.Add(Me.LabelSelectedFields)
        Me.GroupBox1.Controls.Add(Me.LabelAvailableFields)
        Me.GroupBox1.Controls.Add(Me.ComboBoxTable)
        Me.GroupBox1.Controls.Add(Me.LabelTable)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(617, 337)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Project Layout"
        '
        'ButtonLogo
        '
        Me.ButtonLogo.Location = New System.Drawing.Point(581, 305)
        Me.ButtonLogo.Name = "ButtonLogo"
        Me.ButtonLogo.Size = New System.Drawing.Size(27, 19)
        Me.ButtonLogo.TabIndex = 12
        Me.ButtonLogo.Text = "..."
        '
        'TextBoxLogo
        '
        Me.TextBoxLogo.Location = New System.Drawing.Point(6, 304)
        Me.TextBoxLogo.Name = "TextBoxLogo"
        Me.TextBoxLogo.Size = New System.Drawing.Size(569, 20)
        Me.TextBoxLogo.TabIndex = 11
        '
        'LabelLogo
        '
        Me.LabelLogo.AutoSize = True
        Me.LabelLogo.Location = New System.Drawing.Point(6, 283)
        Me.LabelLogo.Name = "LabelLogo"
        Me.LabelLogo.Size = New System.Drawing.Size(34, 13)
        Me.LabelLogo.TabIndex = 10
        Me.LabelLogo.Text = "Logo:"
        '
        'TextBoxTitle
        '
        Me.TextBoxTitle.Location = New System.Drawing.Point(6, 256)
        Me.TextBoxTitle.Name = "TextBoxTitle"
        Me.TextBoxTitle.Size = New System.Drawing.Size(602, 20)
        Me.TextBoxTitle.TabIndex = 9
        Me.TextBoxTitle.Text = "Dynamically created project"
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Location = New System.Drawing.Point(7, 235)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(30, 13)
        Me.LabelTitle.TabIndex = 8
        Me.LabelTitle.Text = "Title:"
        '
        'buttonToAvailableFields
        '
        Me.buttonToAvailableFields.Location = New System.Drawing.Point(290, 163)
        Me.buttonToAvailableFields.Name = "buttonToAvailableFields"
        Me.buttonToAvailableFields.Size = New System.Drawing.Size(35, 30)
        Me.buttonToAvailableFields.TabIndex = 7
        Me.buttonToAvailableFields.Text = "<"
        '
        'buttonToSelectedFields
        '
        Me.buttonToSelectedFields.Location = New System.Drawing.Point(290, 127)
        Me.buttonToSelectedFields.Name = "buttonToSelectedFields"
        Me.buttonToSelectedFields.Size = New System.Drawing.Size(35, 30)
        Me.buttonToSelectedFields.TabIndex = 6
        Me.buttonToSelectedFields.Text = ">"
        '
        'ListBoxSelectedFields
        '
        Me.ListBoxSelectedFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBoxSelectedFields.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ListBoxSelectedFields.Location = New System.Drawing.Point(331, 96)
        Me.ListBoxSelectedFields.Name = "ListBoxSelectedFields"
        Me.ListBoxSelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxSelectedFields.Size = New System.Drawing.Size(277, 121)
        Me.ListBoxSelectedFields.Sorted = True
        Me.ListBoxSelectedFields.TabIndex = 5
        '
        'ListBoxAvailableFields
        '
        Me.ListBoxAvailableFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBoxAvailableFields.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ListBoxAvailableFields.Location = New System.Drawing.Point(6, 96)
        Me.ListBoxAvailableFields.Name = "ListBoxAvailableFields"
        Me.ListBoxAvailableFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxAvailableFields.Size = New System.Drawing.Size(278, 121)
        Me.ListBoxAvailableFields.Sorted = True
        Me.ListBoxAvailableFields.TabIndex = 4
        '
        'LabelSelectedFields
        '
        Me.LabelSelectedFields.AutoSize = True
        Me.LabelSelectedFields.Location = New System.Drawing.Point(331, 75)
        Me.LabelSelectedFields.Name = "LabelSelectedFields"
        Me.LabelSelectedFields.Size = New System.Drawing.Size(82, 13)
        Me.LabelSelectedFields.TabIndex = 3
        Me.LabelSelectedFields.Text = "Selected Fields:"
        '
        'LabelAvailableFields
        '
        Me.LabelAvailableFields.AutoSize = True
        Me.LabelAvailableFields.Location = New System.Drawing.Point(7, 75)
        Me.LabelAvailableFields.Name = "LabelAvailableFields"
        Me.LabelAvailableFields.Size = New System.Drawing.Size(83, 13)
        Me.LabelAvailableFields.TabIndex = 2
        Me.LabelAvailableFields.Text = "Available Fields:"
        '
        'ComboBoxTable
        '
        Me.ComboBoxTable.DropDownWidth = 602
        Me.ComboBoxTable.ItemHeight = 13
        Me.ComboBoxTable.Location = New System.Drawing.Point(6, 43)
        Me.ComboBoxTable.Name = "ComboBoxTable"
        Me.ComboBoxTable.Size = New System.Drawing.Size(602, 21)
        Me.ComboBoxTable.TabIndex = 1
        '
        'LabelTable
        '
        Me.LabelTable.AutoSize = True
        Me.LabelTable.Location = New System.Drawing.Point(7, 22)
        Me.LabelTable.Name = "LabelTable"
        Me.LabelTable.Size = New System.Drawing.Size(37, 13)
        Me.LabelTable.TabIndex = 0
        Me.LabelTable.Text = "Table:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(10, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "US:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(39, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(422, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "This sample shows the usage of NoSql data providers."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(10, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "D:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(39, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(422, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Dieses Beispiel zeigt die Verwendung von NoSql Datenprovidern."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "sunshine.gif"
        Me.OpenFileDialog1.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|A" &
    "ll Files (*.*)|*.*"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(649, 472)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List & Label VB.NET NoSql DataProvider Sample"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LL As combit.Reporting.ListLabel
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As TabPage
    Private WithEvents tabPage2 As TabPage
    Private WithEvents buttonDataProviderTest As System.Windows.Forms.Button
    Private WithEvents ButtonNextTabpage1 As System.Windows.Forms.Button
    Private WithEvents ComboBoxDataProvider As System.Windows.Forms.ComboBox
    Friend WithEvents LabelProvider As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents GroupBox2 As GroupBox
    Private WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Private WithEvents LabelAddress As System.Windows.Forms.Label
    Private WithEvents TextBoxAddress As System.Windows.Forms.TextBox
    Private WithEvents LabelUserName As System.Windows.Forms.Label
    Friend WithEvents TextBoxUsername As System.Windows.Forms.TextBox
    Private WithEvents LabelPassword As System.Windows.Forms.Label
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Private WithEvents LabelDBName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDBName As System.Windows.Forms.TextBox
    Private WithEvents LabelPort As System.Windows.Forms.Label
    Private WithEvents TextBoxPort As System.Windows.Forms.TextBox
    Private WithEvents GroupBox1 As GroupBox
    Private WithEvents ComboBoxTable As System.Windows.Forms.ComboBox
    Friend WithEvents LabelTable As System.Windows.Forms.Label
    Private WithEvents LabelAvailableFields As System.Windows.Forms.Label
    Private WithEvents ListBoxAvailableFields As ListBox
    Private WithEvents LabelSelectedFields As System.Windows.Forms.Label
    Private WithEvents ListBoxSelectedFields As ListBox
    Private WithEvents buttonToAvailableFields As System.Windows.Forms.Button
    Private WithEvents buttonToSelectedFields As System.Windows.Forms.Button
    Private WithEvents LabelLogo As System.Windows.Forms.Label
    Private WithEvents TextBoxTitle As System.Windows.Forms.TextBox
    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents TextBoxLogo As System.Windows.Forms.TextBox
    Private WithEvents ButtonLogo As System.Windows.Forms.Button
    Private WithEvents ButtonPreview As System.Windows.Forms.Button
    Private WithEvents ButtonDesign As System.Windows.Forms.Button
    Private WithEvents ButtonBackTabpage2 As System.Windows.Forms.Button
    Private WithEvents OpenFileDialog1 As OpenFileDialog
    Private WithEvents TextBoxKeySpace As System.Windows.Forms.TextBox
    Private WithEvents TextBoxObjects As System.Windows.Forms.TextBox
    Private WithEvents TextBoxDomain As System.Windows.Forms.TextBox
    Private WithEvents TextBoxTableID As System.Windows.Forms.TextBox
    Private WithEvents CheckBoxFirstRowAreColumnNames As System.Windows.Forms.CheckBox
    Private WithEvents TextBoxRefreshToken As System.Windows.Forms.TextBox
    Private WithEvents TextBoxClientID As System.Windows.Forms.TextBox
    Private WithEvents TextBoxClientSecret As System.Windows.Forms.TextBox
    Friend WithEvents LabelKeyspace As System.Windows.Forms.Label
    Private WithEvents LabelObjects As System.Windows.Forms.Label
    Private WithEvents LabelDomain As System.Windows.Forms.Label
    Private WithEvents LabelTableID As System.Windows.Forms.Label
    Private WithEvents LabelRefreshToken As System.Windows.Forms.Label
    Private WithEvents LabelClientID As System.Windows.Forms.Label
    Private WithEvents LabelClientSecret As System.Windows.Forms.Label
End Class
