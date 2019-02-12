Imports combit.ListLabel24
Imports MetroFramework.Forms
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Namespace Custom_Logger_Sample
    Partial Class Form1
        Inherits MetroFramework.Forms.MetroForm

        Public Sub New()
            Directory.SetCurrentDirectory("..\..\..\")
            InitializeComponent()
        End Sub

        Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            ' DE: Um die Log-Ausgaben von List & Label zu verarbeiten, muss ein Logger-Objekt an den ListLabel-Konstruktor
            '     übergeben werden, das das ILlLogger-Interface implementiert. Dieses Beispiel enthält Referenzimplementierungen
            '     dieser Schnittstelle für die Frameworks NLog, log4net sowie eine Ausgabe in ein ListView.

            ' US: To capture log output from List & Label, an object implementing the ILlLogger interface must be passed to the ListLabel constructor.
            '     This sample contains reference implementations of this interface for the NLog and log4net frameworks, as well as
            '     logger which writes to a ListView.


            ' DE:  Kategorienauswahl speichern
            ' US:  Store log category selection

            Dim selectedCategories = New LogCategories()
            selectedCategories.EnablePrinterInformation = chkPrinterInfo.Checked
            selectedCategories.EnableDataProvider = chkDataProvider.Checked
            selectedCategories.EnableLicensing = chkLicensing.Checked
            selectedCategories.EnableDotNetComponent = chkNetFx.Checked
            selectedCategories.EnableApiCalls = chkNativeAPI.Checked
            selectedCategories.EnableOther = chkOther.Checked


            ' DE:  Logger für NLog, log4net oder ListView anlegen
            ' US:  Create logger for NLog, log4net or the ListView
            Dim logger As ILlLogger = Nothing

            ' Adapter for NLog Framework

            If tabsLogType.SelectedTab.ToString() = tabPageNLog.ToString() Then
                Dim nlogLog = NLog.LogManager.GetLogger("ListLabelSample")
                logger = New ListLabel2NLogAdapter(nlogLog, selectedCategories)

                ' Adapter for log4net Framework
            ElseIf tabsLogType.SelectedTab.ToString() = tabPageLog4Net.ToString() Then
                log4net.Config.XmlConfigurator.ConfigureAndWatch(New FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")))
                Dim log4netLog = log4net.LogManager.GetLogger("ListLabelSample")
                logger = New ListLabel2Log4NetAdapter(log4netLog, selectedCategories)

                ' Log to ListView
            ElseIf tabsLogType.SelectedTab.ToString() = tabPageListView.ToString() Then
                listviewMessages.Items.Clear()
                logger = New ListViewLogger(listviewMessages, selectedCategories, chkIncludeDebugLevel.Checked)
            End If


            Dim dataProvider = GenericList.GetGenericList()

            ' DE:  Optional kann ein eigener Logger für den Datenprovider gesetzt werden, falls nicht, wird der Logger der ListLabel-Komponente geerbt.
            ' US:  Optionally a dedicated logger can be assigned to the data provider. If not set, the logger of the ListLabel component is inherited.

            'if (dataProvider is ISupportsLogger)
            '{
            '    (dataProvider as ISupportsLogger).SetLogger(new ExampleLogger(),  /* overrideExisting: */ true);
            '}


            ' DE:  Der benutzerdefinierte Logger wird im Konstruktor übergeben. Achtung: Die Eigenschaft "Debug" des ListLabel-Objekts wird bei Angabe eines eigenen Loggers ignoriert.
            ' US:  The user-defined logger is passed to the constructor. Note: The 'Debug' property of the ListLabel object is ignored when a custom logger is used.
            Using LL = New ListLabel(logger)
                Try
                    ' D:   Den Datenprovider bei List & Label anmelden und den Designer starten
                    ' US:  Pass the data provider to List & Label and start the Designer

                    LL.DataSource = dataProvider
                    LL.AutoProjectFile = "genericlist.lst"
                    LL.AutoShowSelectFile = False
                    LL.Export(New ExportConfiguration(LlExportTarget.Pdf, Path.GetTempFileName(), LL.AutoProjectFile))

                    If tabsLogType.SelectedTab.ToString() <> tabPageListView.ToString() Then
                        If MessageBox.Show("Print is complete. Open Log File?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            BtnOpenLogFile_Click(Nothing, Nothing)
                        End If
                    End If
                Catch ex As ListLabelException
                    MessageBox.Show("Information: " + ex.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End Using
        End Sub

        Private Sub Form1_Load(sender As Object, e As EventArgs)
            tabsLogType.SelectedIndex = 0
        End Sub

        Private Sub BtnOpenLogFile_Click(sender As Object, e As EventArgs) Handles btnOpenLogFile_NLog.Click, btnOpenLogFile_Log4Net.Click
            Dim fileName
            If tabsLogType.SelectedTab.ToString() = tabPageLog4Net.ToString() Then
                fileName = "llsample_log4net.log"
            Else
                fileName = "llsample_nlog.log"
            End If

            Dim logPath = Path.Combine(Path.GetTempPath(), fileName)

            If Not File.Exists(logPath) OrElse New FileInfo(logPath).Length = 0 Then
                MessageBox.Show("No log file has been created yet or log file is empty.")
                Return
            End If

            Process.Start(New ProcessStartInfo(logPath) With {.UseShellExecute = True})
        End Sub

    End Class

    ' DE:  Hilfsklasse zum Speichern der Logkategorienauswahl
    ' US:  Helper class to store the log category selection
    Public Class LogCategories
        Public EnablePrinterInformation As Boolean
        Public EnableDataProvider As Boolean
        Public EnableLicensing As Boolean
        Public EnableDotNetComponent As Boolean
        Public EnableApiCalls As Boolean
        Public EnableOther As Boolean

        ' List & Label has more categories, but those are the most important
    End Class
End Namespace
