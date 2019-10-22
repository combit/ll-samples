Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports combit.ListLabel25.DataProviders
Imports Microsoft.Win32
Imports System.Data.OleDb
Imports combit.ListLabel25
Imports System.Globalization
Imports Microsoft.SharePoint.Client
Imports System.Net
Imports System.IO
Imports combit.ListLabel25.SharePointExtensions
Imports SharePointSample
Partial Public Class Form1
    Inherits Windows.Forms.Form
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim lblServer As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim lblDocBib As System.Windows.Forms.Label
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.button1 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkOverwriteFile = New System.Windows.Forms.CheckBox()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.comboBoxFormat = New System.Windows.Forms.ComboBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.comboBoxBib = New System.Windows.Forms.ComboBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        lblServer = New System.Windows.Forms.Label()
        lblDocBib = New System.Windows.Forms.Label()
        Me.panel2.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblServer
        '
        resources.ApplyResources(lblServer, "lblServer")
        lblServer.Name = "lblServer"
        '
        'lblDocBib
        '
        resources.ApplyResources(lblDocBib, "lblDocBib")
        lblDocBib.Name = "lblDocBib"
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.LightGray
        Me.panel2.Controls.Add(Me.button1)
        Me.panel2.Controls.Add(Me.label1)
        resources.ApplyResources(Me.panel2, "panel2")
        Me.panel2.Name = "panel2"
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.button1, "button1")
        Me.button1.Name = "button1"
        Me.button1.TabStop = False
        Me.button1.UseVisualStyleBackColor = False
        '
        'label1
        '
        resources.ApplyResources(Me.label1, "label1")
        Me.label1.Name = "label1"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.LightGray
        Me.panel1.Controls.Add(Me.lblInfo)
        Me.panel1.Controls.Add(Me.pictureBox1)
        resources.ApplyResources(Me.panel1, "panel1")
        Me.panel1.Name = "panel1"
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.Transparent
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
        '
        'lblFileName
        '
        resources.ApplyResources(Me.lblFileName, "lblFileName")
        Me.lblFileName.Name = "lblFileName"
        '
        'comboBoxFormat
        '
        Me.comboBoxFormat.FormattingEnabled = True
        resources.ApplyResources(Me.comboBoxFormat, "comboBoxFormat")
        Me.comboBoxFormat.Items.AddRange(New Object() {resources.GetString("comboBoxFormat.Items"), resources.GetString("comboBoxFormat.Items1"), resources.GetString("comboBoxFormat.Items2"), resources.GetString("comboBoxFormat.Items3"), resources.GetString("comboBoxFormat.Items4")})
        Me.comboBoxFormat.Name = "comboBoxFormat"
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.txtFileName, "txtFileName")
        Me.txtFileName.Name = "txtFileName"
        '
        'lblFormat
        '
        resources.ApplyResources(Me.lblFormat, "lblFormat")
        Me.lblFormat.Name = "lblFormat"
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Name = "btnRefresh"
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
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.Name = "txtPassword"
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'lblPassword
        '
        resources.ApplyResources(Me.lblPassword, "lblPassword")
        Me.lblPassword.Name = "lblPassword"
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'comboBoxBib
        '
        Me.comboBoxBib.FormattingEnabled = True
        resources.ApplyResources(Me.comboBoxBib, "comboBoxBib")
        Me.comboBoxBib.Name = "comboBoxBib"
        '
        'txtServer
        '
        Me.txtServer.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.txtServer, "txtServer")
        Me.txtServer.Name = "txtServer"
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.panel2.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
        If _ll IsNot Nothing Then
            _ll.Dispose()
        End If
        MyBase.OnClosing(e)
    End Sub
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents btnExport As System.Windows.Forms.Button
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents chkOverwriteFile As System.Windows.Forms.CheckBox
    Private WithEvents lblFileName As System.Windows.Forms.Label
    Private WithEvents comboBoxFormat As System.Windows.Forms.ComboBox
    Private WithEvents txtFileName As System.Windows.Forms.TextBox
    Private WithEvents lblFormat As System.Windows.Forms.Label
    Private WithEvents btnRefresh As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents lblPassword As System.Windows.Forms.Label
    Private WithEvents lblName As System.Windows.Forms.Label
    Private WithEvents comboBoxBib As System.Windows.Forms.ComboBox
    Private WithEvents txtServer As System.Windows.Forms.TextBox
    Private WithEvents lblInfo As System.Windows.Forms.Label
End Class
