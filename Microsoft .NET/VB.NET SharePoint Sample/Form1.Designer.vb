Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports combit.ListLabel24.DataProviders
Imports Microsoft.Win32
Imports System.Data.OleDb
Imports combit.ListLabel24
Imports System.Globalization
Imports Microsoft.SharePoint.Client
Imports System.Net
Imports System.IO
Imports combit.ListLabel24.SharePointExtensions
Imports SharePointSample

Partial Public Class Form1
    Inherits MetroFramework.Forms.MetroForm
    Dim _ll As New ListLabel()

    Public Sub New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _ll = New ListLabel(CultureInfo.CurrentCulture)

        comboBoxFormat.SelectedIndex = 0
    End Sub
    'Form overrides dispose to clean up the component list.
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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim lblServer As MetroFramework.Controls.MetroLabel
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim lblDocBib As MetroFramework.Controls.MetroLabel
        Me.panel2 = New MetroFramework.Controls.MetroPanel()
        Me.button1 = New MetroFramework.Controls.MetroButton()
        Me.label1 = New MetroFramework.Controls.MetroLabel()
        Me.panel1 = New MetroFramework.Controls.MetroPanel()
        Me.lblInfo = New MetroFramework.Controls.MetroLabel()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnExport = New MetroFramework.Controls.MetroButton()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkOverwriteFile = New MetroFramework.Controls.MetroCheckBox()
        Me.lblFileName = New MetroFramework.Controls.MetroLabel()
        Me.comboBoxFormat = New MetroFramework.Controls.MetroComboBox()
        Me.txtFileName = New MetroFramework.Controls.MetroTextBox()
        Me.lblFormat = New MetroFramework.Controls.MetroLabel()
        Me.btnRefresh = New MetroFramework.Controls.MetroButton()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New MetroFramework.Controls.MetroTextBox()
        Me.txtName = New MetroFramework.Controls.MetroTextBox()
        Me.lblPassword = New MetroFramework.Controls.MetroLabel()
        Me.lblName = New MetroFramework.Controls.MetroLabel()
        Me.comboBoxBib = New MetroFramework.Controls.MetroComboBox()
        Me.txtServer = New MetroFramework.Controls.MetroTextBox()
        lblServer = New MetroFramework.Controls.MetroLabel()
        lblDocBib = New MetroFramework.Controls.MetroLabel()
        Me.panel2.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblServer
        '
        lblServer.FontSize = MetroFramework.MetroLabelSize.Small
        resources.ApplyResources(lblServer, "lblServer")
        lblServer.Name = "lblServer"
        '
        'lblDocBib
        '
        lblDocBib.FontSize = MetroFramework.MetroLabelSize.Small
        resources.ApplyResources(lblDocBib, "lblDocBib")
        lblDocBib.Name = "lblDocBib"
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.LightGray
        Me.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel2.Controls.Add(Me.button1)
        Me.panel2.Controls.Add(Me.label1)
        Me.panel2.HorizontalScrollbarBarColor = True
        Me.panel2.HorizontalScrollbarHighlightOnWheel = False
        Me.panel2.HorizontalScrollbarSize = 10
        resources.ApplyResources(Me.panel2, "panel2")
        Me.panel2.Name = "panel2"
        Me.panel2.VerticalScrollbarBarColor = True
        Me.panel2.VerticalScrollbarHighlightOnWheel = False
        Me.panel2.VerticalScrollbarSize = 10
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.button1, "button1")
        Me.button1.Name = "button1"
        Me.button1.TabStop = False
        Me.button1.UseSelectable = True
        '
        'label1
        '
        Me.label1.FontSize = MetroFramework.MetroLabelSize.Small
        resources.ApplyResources(Me.label1, "label1")
        Me.label1.Name = "label1"
        Me.label1.WrapToLine = True
        '
        'panel1
        '
        resources.ApplyResources(Me.panel1, "panel1")
        Me.panel1.BackColor = System.Drawing.Color.LightGray
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.lblInfo)
        Me.panel1.Controls.Add(Me.pictureBox1)
        Me.panel1.HorizontalScrollbarBarColor = True
        Me.panel1.HorizontalScrollbarHighlightOnWheel = False
        Me.panel1.HorizontalScrollbarSize = 10
        Me.panel1.Name = "panel1"
        Me.panel1.VerticalScrollbarBarColor = True
        Me.panel1.VerticalScrollbarHighlightOnWheel = False
        Me.panel1.VerticalScrollbarSize = 10
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblInfo.FontSize = MetroFramework.MetroLabelSize.Small
        resources.ApplyResources(Me.lblInfo, "lblInfo")
        Me.lblInfo.Name = "lblInfo"
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pictureBox1, "pictureBox1")
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.TabStop = False
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Name = "btnExport"
        Me.btnExport.UseSelectable = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.chkOverwriteFile)
        Me.groupBox2.Controls.Add(Me.lblFileName)
        Me.groupBox2.Controls.Add(Me.comboBoxFormat)
        Me.groupBox2.Controls.Add(Me.txtFileName)
        Me.groupBox2.Controls.Add(Me.lblFormat)
        resources.ApplyResources(Me.groupBox2, "groupBox2")
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.TabStop = False
        '
        'chkOverwriteFile
        '
        resources.ApplyResources(Me.chkOverwriteFile, "chkOverwriteFile")
        Me.chkOverwriteFile.Name = "chkOverwriteFile"
        Me.chkOverwriteFile.Style = MetroFramework.MetroColorStyle.Blue
        Me.chkOverwriteFile.UseSelectable = True
        '
        'lblFileName
        '
        Me.lblFileName.FontSize = MetroFramework.MetroLabelSize.Small
        resources.ApplyResources(Me.lblFileName, "lblFileName")
        Me.lblFileName.Name = "lblFileName"
        '
        'comboBoxFormat
        '
        Me.comboBoxFormat.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.comboBoxFormat.FormattingEnabled = True
        resources.ApplyResources(Me.comboBoxFormat, "comboBoxFormat")
        Me.comboBoxFormat.Items.AddRange(New Object() {resources.GetString("comboBoxFormat.Items"), resources.GetString("comboBoxFormat.Items1"), resources.GetString("comboBoxFormat.Items2"), resources.GetString("comboBoxFormat.Items3"), resources.GetString("comboBoxFormat.Items4")})
        Me.comboBoxFormat.Name = "comboBoxFormat"
        Me.comboBoxFormat.Style = MetroFramework.MetroColorStyle.Blue
        Me.comboBoxFormat.UseSelectable = True
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFileName.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtFileName, "txtFileName")
        Me.txtFileName.MaxLength = 32767
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFileName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtFileName.SelectedText = ""
        Me.txtFileName.UseCustomBackColor = True
        Me.txtFileName.UseSelectable = True
        '
        'lblFormat
        '
        Me.lblFormat.FontSize = MetroFramework.MetroLabelSize.Small
        resources.ApplyResources(Me.lblFormat, "lblFormat")
        Me.lblFormat.Name = "lblFormat"
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.UseSelectable = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.txtPassword)
        Me.groupBox1.Controls.Add(Me.txtName)
        Me.groupBox1.Controls.Add(Me.lblPassword)
        Me.groupBox1.Controls.Add(Me.lblName)
        resources.ApplyResources(Me.groupBox1, "groupBox1")
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.MaxLength = 32767
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtPassword.SelectedText = ""
        Me.txtPassword.UseCustomBackColor = True
        Me.txtPassword.UseSelectable = True
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.MaxLength = 32767
        Me.txtName.Name = "txtName"
        Me.txtName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtName.SelectedText = ""
        Me.txtName.UseCustomBackColor = True
        Me.txtName.UseSelectable = True
        '
        'lblPassword
        '
        Me.lblPassword.FontSize = MetroFramework.MetroLabelSize.Small
        resources.ApplyResources(Me.lblPassword, "lblPassword")
        Me.lblPassword.Name = "lblPassword"
        '
        'lblName
        '
        Me.lblName.FontSize = MetroFramework.MetroLabelSize.Small
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'comboBoxBib
        '
        Me.comboBoxBib.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.comboBoxBib.FormattingEnabled = True
        resources.ApplyResources(Me.comboBoxBib, "comboBoxBib")
        Me.comboBoxBib.Name = "comboBoxBib"
        Me.comboBoxBib.Style = MetroFramework.MetroColorStyle.Blue
        Me.comboBoxBib.UseSelectable = True
        '
        'txtServer
        '
        Me.txtServer.BackColor = System.Drawing.SystemColors.Window
        Me.txtServer.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtServer, "txtServer")
        Me.txtServer.MaxLength = 32767
        Me.txtServer.Name = "txtServer"
        Me.txtServer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtServer.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtServer.SelectedText = ""
        Me.txtServer.UseCustomBackColor = True
        Me.txtServer.UseSelectable = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(lblServer)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(lblDocBib)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.comboBoxBib)
        Me.Controls.Add(Me.txtServer)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Resizable = False
        Me.panel2.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
        If _ll IsNot Nothing Then
            _ll.Dispose()
        End If

        MyBase.OnClosing(e)
    End Sub
    Private WithEvents panel2 As MetroFramework.Controls.MetroPanel
    Private WithEvents button1 As MetroFramework.Controls.MetroButton
    Private WithEvents label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents panel1 As MetroFramework.Controls.MetroPanel
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents btnExport As MetroFramework.Controls.MetroButton
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents chkOverwriteFile As MetroFramework.Controls.MetroCheckBox
    Private WithEvents lblFileName As MetroFramework.Controls.MetroLabel
    Private WithEvents comboBoxFormat As MetroFramework.Controls.MetroComboBox
    Private WithEvents txtFileName As MetroFramework.Controls.MetroTextBox
    Private WithEvents lblFormat As MetroFramework.Controls.MetroLabel
    Private WithEvents btnRefresh As MetroFramework.Controls.MetroButton
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtPassword As MetroFramework.Controls.MetroTextBox
    Private WithEvents txtName As MetroFramework.Controls.MetroTextBox
    Private WithEvents lblPassword As MetroFramework.Controls.MetroLabel
    Private WithEvents lblName As MetroFramework.Controls.MetroLabel
    Private WithEvents comboBoxBib As MetroFramework.Controls.MetroComboBox
    Private WithEvents txtServer As MetroFramework.Controls.MetroTextBox
    Private WithEvents lblInfo As MetroFramework.Controls.MetroLabel
End Class
