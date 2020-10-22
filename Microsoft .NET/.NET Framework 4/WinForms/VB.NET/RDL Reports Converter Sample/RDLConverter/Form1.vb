Option Infer On
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports combit.Reporting
Imports combit.Reporting.DataProviders
Imports combit.Reporting.Dom
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports System.Globalization
Imports combit.Reporting.Converters
Imports System.Data.SqlClient

Partial Public Class Form1
    Inherits Form
    Private sampleDir As String
    Private installKey As RegistryKey

    Private Property SourceFileName() As String
        Get
            Return textSourceFile.Text
        End Get
        Set
            textSourceFile.Text = Value
        End Set
    End Property

    Private Property TargetFileName() As String
        Get
            Return textTargetFile.Text
        End Get
        Set
            textTargetFile.Text = Value
        End Set
    End Property



    <STAThread>
    Public Shared Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetProcessDPIAware() As Boolean
    End Function

    Public Sub New()
        Directory.SetCurrentDirectory("..\..\..\..\..\..\..\Report Files")
        InitializeComponent()
        installKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll")
        If installKey IsNot Nothing Then
            sampleDir = DirectCast(installKey.GetValue("LL26SampleDir", String.Empty), String)
        End If

        If Not sampleDir.EndsWith("\") Then
            sampleDir += "\"
        End If

        SourceFileName = sampleDir + "Microsoft .NET\.NET Framework 4\WinForms\VB.NET\RDL Reports Converter Sample\RDLConverter\RDLReports.rdl"
        TargetFileName = sampleDir + "Microsoft .NET\.NET Framework 4\WinForms\VB.NET\RDL Reports Converter Sample\RDLConverter\ReportConvert.lst"

        ' D: Setze Cursor an die letzte Position
        ' US: Set cursor to the last position
        textSourceFile.[Select](textSourceFile.Text.Length, 1)
        textTargetFile.[Select](textTargetFile.Text.Length, 1)

        'D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbankpfad auslesen
        'US: Set path to main sample path, read database path
        Directory.SetCurrentDirectory(Application.StartupPath + "\..\..\..\..\..\..\..\Report Files")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        'D: Neue ListLabel Instanz erstellen
        'US: Create new ListLabel instance
        Using ll As New ListLabel()
            Try
                'D: Erstelle ein RptConverter Objekt
                'US: Create an RptConverter object
                Dim rdlConverter As New RdlConverter(SourceFileName)

                'D: Datenquellen aus Bericht auslesen
                'US: Exract report datasources
                Dim commands As Dictionary(Of String, IDbCommand) = rdlConverter.GetDataSource(Nothing)
                Dim dataProvider As New DbCommandSetDataProvider()
                dataProvider.MinimalSelect = False
                dataProvider.PrefixTableNameWithSchema = False
                For Each item In commands
                    dataProvider.AddCommand(item.Value, item.Key)
                Next
                ll.DataSource = dataProvider

                'D: Konvertiere den Bericht
                'US: Convert the report
                Try
                    rdlConverter.ConvertReport(ll, SourceFileName, TargetFileName)
                Catch generatedExceptionName As SqlException
                    Dim msg As String = String.Format("The selected RDL report uses a datasource which is currently not accessible." & vbLf & vbLf & "The connection string is as follows:" & vbLf & """{0}""" & vbLf & vbLf & "Thus the datasource is not accessible we are using sample data to perform a conversion. Errors can be ignored.", commands.First().Value.Connection.ConnectionString)
                    MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Dim ds As New DataSet("SampleDataSet")
                    Dim dt As New DataTable("SampleData")
                    dt.Columns.Add("ID", GetType(Integer))
                    dt.Columns.Add("Name", GetType(String))
                    ds.Tables.Add(dt)

                    Dim sampleRow As DataRow = dt.NewRow()

                    sampleRow.SetField("ID", 1)
                    sampleRow.SetField("Name", "Sample")
                    dt.Rows.Add(sampleRow)

                    ll.DataSource = ds

                    rdlConverter.ConvertReport(ll, SourceFileName, TargetFileName)

                    ll.AutoProjectFile = TargetFileName
                    ll.AutoShowSelectFile = False
                    ll.Design()
                    Return
                End Try
                Dim result As DialogResult = MessageBox.Show("Conversion finished, do you want to open the Designer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'D: Designer mit konvertiertem Bericht öffnen
                'US: Open the Designer with the converted report
                If result = DialogResult.Yes Then
                    ll.AutoProjectFile = TargetFileName
                    ll.AutoShowSelectFile = False
                    ll.Design()
                End If
                'D: Einfaches Fehlerhandling
                'US: Simple error handling                
            Catch ex As Exception
                MessageBox.Show(ex.Source + " " + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Using
    End Sub



    Private Sub SelectSourceFile_Click(sender As Object, e As EventArgs) Handles selectSourceFile.Click
        Try
            'D: RDL Reports Datei auswählen
            'US: Choose the RDL Reports file
            Dim openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "RDL Reports files (*.rdl)|*.rdl|All Files (*.*)|*.*"
            openFileDialog.InitialDirectory = sampleDir + "Microsoft .NET\Report Files"
            If openFileDialog.ShowDialog(Me) = DialogResult.OK Then
                SourceFileName = openFileDialog.FileName
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub SelectTargetFile_Click(sender As Object, e As EventArgs) Handles selectTargetFile.Click
        Try
            Dim saveFileDialog As New SaveFileDialog()
            Dim ci As CultureInfo = CultureInfo.CurrentCulture
            If ci.TwoLetterISOLanguageName = "de" Then
                saveFileDialog.Filter = "List & Label Bericht (*.lst)|*.lst|Alle Dateien (*.*)|*.*"
            Else
                saveFileDialog.Filter = "List & Label Report (*.rpt)|*.rpt|All Files (*.*)|*.*"
            End If

            saveFileDialog.InitialDirectory = sampleDir + "Microsoft .NET\Report Files"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                TargetFileName = saveFileDialog.FileName

            End If
            'D: Einfaches Fehlerhandling
            'US: Simple error handling
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub TextTargetFile_MouseEnter(sender As Object, e As EventArgs) Handles textSourceFile.MouseEnter, textTargetFile.MouseEnter
        If TryCast(sender, TextBox).Name = textSourceFile.Name Then
            toolTip1.Show(textSourceFile.Text, textSourceFile)
        ElseIf TryCast(sender, TextBox).Name = textTargetFile.Name Then
            toolTip1.Show(textTargetFile.Text, textTargetFile)
        End If
    End Sub

    Private Sub TextSourceFile_MouseLeave(sender As Object, e As EventArgs) Handles textSourceFile.MouseLeave, textTargetFile.MouseLeave
        toolTip1.Hide(TryCast(sender, TextBox))
    End Sub

End Class
