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

    <STAThread>
    Public Shared Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetProcessDPIAware() As Boolean
    End Function

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            ResetError()
            comboBoxBib.Items.Clear()

            'D: Erstelle ClientContext Objekt
            'US: create ClientContext object 
            Using context As New ClientContext(txtServer.Text)

                'D: Setze Berechtigungen
                'US: set credentials
                If Not String.IsNullOrEmpty(txtName.Text) AndAlso Not String.IsNullOrEmpty(txtPassword.Text) Then
                    context.Credentials = New NetworkCredential(txtName.Text, txtPassword.Text)

                End If

                'D: Lade Listen
                'US: load lists
                Dim lists As ListCollection = context.Web.Lists

                context.Load(lists)
                context.ExecuteQuery()

                'D: Alle Listen durchlaufen und einen Eintrag in der ComboBox machen
                'US: iterate through all lists and add an entry to the ComboBox
                For Each list As List In lists
                    If list.BaseTemplate = CInt(ListTemplateType.DocumentLibrary) Then
                        comboBoxBib.Items.Add(list.Title)
                    End If
                Next

                comboBoxBib.SelectedIndex = 0
            End Using
        Catch ex As Exception
            ShowError(ex.Message)
        End Try

    End Sub

    Private Sub ShowError(ByVal exceptionMessage As String)
        pictureBox1.Visible = True
        lblInfo.Visible = True
        lblInfo.Text = exceptionMessage
        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(lblInfo, exceptionMessage)
    End Sub

    Private Sub ResetError()
        pictureBox1.Visible = False
        lblInfo.Visible = False
        lblInfo.Text = String.Empty
    End Sub

    Private Sub ShowInfo(ByVal InformationMessage As String)
        pictureBox1.Visible = False
        lblInfo.Visible = True
        lblInfo.Text = InformationMessage
        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(lblInfo, InformationMessage)
    End Sub

    Private Sub BtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            'D: Setze Datenquelle
            'US: set data source
            _ll.DataSource = CreateDbCommandSetDataProvider()
            Using exportStream As New MemoryStream()
                'D: Erstelle Export Konfiguration
                'US: create export configuration
                Dim exportTarget As LlExportTarget = GetExportTargetFromIndex()
                Dim exportConfiguration As New ExportConfiguration(exportTarget, exportStream, "..\..\..\simple.lst")
                exportConfiguration.Path = txtFileName.Text + GetExtension(exportTarget)

                'D: Setze SharePoint Verbindungsoptionen
                'US: set sharepoint connection information
                Dim sharePointConnectionInformation As New SharePointConnectionInformation(txtServer.Text, comboBoxBib.SelectedItem.ToString())
                sharePointConnectionInformation.OverwriteExistingFile = chkOverwriteFile.Checked

                If Not String.IsNullOrEmpty(txtName.Text) AndAlso Not String.IsNullOrEmpty(txtPassword.Text) Then
                    sharePointConnectionInformation.NetworkCredential = New NetworkCredential(txtName.Text, txtPassword.Text)
                End If

                _ll.Export(exportConfiguration, sharePointConnectionInformation)

                ShowInfo(My.Resources.InfoExportSucceeded)
            End Using
            'Catch ex2 As Microsoft.SharePoint.Client.ServerException
            '    ShowError(ex2.Message)

        Catch ex As Exception
            ShowError(ex.Message)

        End Try

        'Catch ex2 As Microsoft.SharePoint.Client.ServerException
        '    MessageBox.Show(ex2.Message)
        'End Try

    End Sub

    Private Shared Function CreateDbCommandSetDataProvider() As DbCommandSetDataProvider
        Dim databasePath As String = String.Empty
        Dim installKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll")
        If installKey IsNot Nothing Then
            databasePath = DirectCast(installKey.GetValue("NWINDPath", String.Empty), String)
        End If

        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath)
        conn.Open()
        Dim cmd As New OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID = Categories.CategoryID)", conn)
        conn.Close()

        Dim provider As New DbCommandSetDataProvider()
        provider.AddCommand(cmd, "Products", "[{0}]", Nothing)

        Return provider
    End Function

    Private Function GetExportTargetFromIndex() As LlExportTarget
        Dim selectedIndex As Integer = comboBoxFormat.SelectedIndex
        Select Case selectedIndex
            Case 0
                Return LlExportTarget.Pdf
            Case 1
                Return LlExportTarget.Xls
            Case 2
                Return LlExportTarget.Xlsx
            Case 3
                Return LlExportTarget.Rtf
            Case 4
                Return LlExportTarget.MultiTiff
            Case Else
                Return LlExportTarget.Pdf
        End Select
    End Function

    Private Shared Function GetExtension(ByVal exportTarget As LlExportTarget) As String
        Select Case exportTarget
            Case LlExportTarget.MultiTiff
                Return ".tif"
            Case LlExportTarget.Pdf
                Return ".pdf"
            Case LlExportTarget.Rtf
                Return ".rtf"
            Case LlExportTarget.Xls
                Return ".xls"
            Case LlExportTarget.Xlsx
                Return ".xlsx"
            Case Else
                Return String.Empty
        End Select
    End Function

    Private Sub ComboBoxBib_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboBoxBib.SelectedIndexChanged
        groupBox2.Enabled = (comboBoxBib.Items.Count > 0)
        btnExport.Enabled = (comboBoxBib.Items.Count > 0)
    End Sub

    Private Sub ComboBoxBib_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboBoxBib.DropDown
        If comboBoxBib.Items.Count = 0 Then
            BtnRefresh_Click(Me.btnRefresh, Nothing)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        'D: Öffne Downloadseite
        'US: Open download site
        Try
            Process.Start("http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=21786")
        Catch generatedExceptionName As Win32Exception
        Catch generatedExceptionName As ObjectDisposedException
        Catch generatedExceptionName As FileNotFoundException
        End Try
    End Sub
End Class
