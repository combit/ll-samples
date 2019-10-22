Imports System.Data.OleDb
Imports System.IO
Imports System.Web.Script.Services
Imports System.Web.Services
Imports combit.ListLabel25
Imports combit.ListLabel25.DataProviders
Imports combit.ListLabel25.Dom

Namespace combit.Services

    '''<summary>
    '''Summary description for ReportingService
    '''</summary>
    '[WebService(Namespace = "http://tempuri.org/")]
    '[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    '[System.ComponentModel.ToolboxItem(false)]        
    <ScriptService()> _
    Public NotInheritable Class ReportingService
        Inherits System.Web.Services.WebService


        <WebMethod()> _
        <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)> _
        Public Function GetReportTemplates(dataSourceId As String) As Response(Of Report())
            Try
                ' D: Alle Berichte zur Datenquelle auslesen
                ' US: Read all reports by data source
                Dim serverReportsPath As String = Server.MapPath("~/reports") + "\" + dataSourceId
                Dim paths As New List(Of String)()
                paths.AddRange(Directory.GetFiles(serverReportsPath, "*.lst"))
                paths.AddRange(Directory.GetFiles(serverReportsPath, "*.lbl"))
                paths.AddRange(Directory.GetFiles(serverReportsPath, "*.crd"))

                Dim reports As New List(Of Report)()

                Dim image As String, description As String
                'Dim var As String

                For Each report In paths
                    image = GetReportImageUrl(dataSourceId, report)
                    description = GetReportDescription(report)

                    reports.Add(New Report(dataSourceId, report, description, image))
                Next

                Return New Response(Of Report())(reports.ToArray())
            Catch generatedExceptionName As Exception
                Return New Response(Of Report())(New [Error]("<error no data>"))
            End Try
        End Function

        <WebMethod()> _
        <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)> _
        Public Function GetDataSources() As Response(Of DataSource())
            ' D: Alle Datenquellen holen
            ' US: Get all data sources
            Try

                ' D: Hier können zusätzliche Datenquellen angefügt werden
                ' US: Add more data sources here
                Return New Response(Of DataSource())(New DataSource() {New DataSource("OLEDB", "Access datasource", "Northwind Access Database", "images/database.png"), New DataSource("OBJECT", "Object datasource", "Object Data Provider", "images/database.png"), New DataSource("XML1", "XML1 datasource", "Datasource Description", "images/database.png"), New DataSource("XML2", "XML2 datasource", "CRM Customer Data", "images/database.png"), New DataSource("JSON", "JSON datasource", "CRM Customer Data", "images/database.png"), New DataSource("CSV", "CSV datasource", "IIS Logfile", "images/database.png")})
            Catch generatedExceptionName As Exception
                Return New Response(Of DataSource())(New [Error](1000, "<error no data>"))
            End Try
        End Function


        <WebMethod()> _
        <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
        Public Function Print(dataSourceId As String, report As String, format As String) As Response(Of String)
            Dim reportresult As String = String.Empty
            Try
                Dim provider As IDataProvider = Nothing
                Dim dataMember As String = String.Empty

                'D: Datenquelle auswählen
                'US: Chose data source
                Select Case dataSourceId.ToUpperInvariant()
                    Case "XML1"
                        provider = New XmlDataProvider(Path.Combine(Server.MapPath("~/App_Data/"), "data.xml"))
                        dataMember = "book"
                        Exit Select
                    Case "XML2"
                        provider = New XmlDataProvider(Path.Combine(Server.MapPath("~/App_Data"), "data2.xml"))
                        dataMember = "Companies"
                        Exit Select
                    Case "JSON"
                        provider = New Global.combit.ListLabel25.DataProviders.JsonDataProvider(File.ReadAllText(Path.Combine(Server.MapPath("~/App_Data"), "data.json")))
                        Exit Select
                    Case "OBJECT"
                        provider = New ObjectDataProvider(GenericList.GetGenericList())
                        Exit Select
                    Case "OLEDB"
                        provider = New OleDbConnectionDataProvider(New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Mode=Read;data source=" + Path.Combine(Server.MapPath("~/App_Data/"), "NWIND.MDB")))
                        dataMember = "Customers"
                        Exit Select
                    Case "CSV"
                        provider = New CsvDataProvider(Path.Combine(Server.MapPath("~/App_Data"), "iislog.csv"), True, "Log", ControlChars.Tab, 0, False)
                        Exit Select
                    Case Else
                        Return New Response(Of String)(New [Error]("Wrong Datasource: " + dataSourceId.ToUpperInvariant()))
                End Select

                'D: Export Format auswählen
                'US: Chose export formats
                Dim extension As String = String.Empty
                Dim exportTarget As LlExportTarget = LlExportTarget.Pdf
                Select Case format.ToUpperInvariant()
                    Case "PDF"
                        extension = ".pdf"
                        exportTarget = LlExportTarget.Pdf
                        Exit Select
                    Case "DOCX"
                        extension = ".docx"
                        exportTarget = LlExportTarget.Docx
                        Exit Select
                    Case "XLSX"
                        extension = ".xlsx"
                        exportTarget = LlExportTarget.Xlsx
                        Exit Select
                    Case "RTF"
                        extension = ".rtf"
                        exportTarget = LlExportTarget.Rtf
                        Exit Select
                    Case "MHTML"
                        extension = ".mht"
                        exportTarget = LlExportTarget.Mhtml
                        Exit Select
                    Case "MTIFF"
                        extension = ".tif"
                        exportTarget = LlExportTarget.MultiTiff
                        Exit Select
                    Case Else
                        Return New Response(Of String)(New [Error]("Wrong Format: " + format.ToUpperInvariant()))
                End Select

                ' D: List & Label Objekt erzeugen und exportieren
                ' US: Create List & Label object and export
                Using ll As New ListLabel()
                    ll.DataSource = provider

                    If Not String.IsNullOrEmpty(dataMember) Then
                        ll.DataMember = dataMember
                    End If

                    ' D: Eindeutigen Dateinamen erzeugen
                    ' US: Create unique filename
                    reportresult = "Report." + Guid.NewGuid().ToString + extension
                    Dim outputFile As String = System.IO.Path.GetTempPath() + reportresult

                    ll.ExportOptions.Clear()
                    ll.ExportOptions.Add(LlExportOption.PdfFontMode, "6")

                    ' D: Export starten
                    ' US: Start export
                    Dim exportConfiguration As New ExportConfiguration(exportTarget, outputFile, Server.MapPath("~/reports/") + dataSourceId + "/" + report)
                    exportConfiguration.ProjectType = ll.Core.LlUtilsGetProjectType(Server.MapPath("~/reports/") + dataSourceId + "/" + report)
                    ll.Export(exportConfiguration)
                End Using
            Catch llException As ListLabelException
                System.Diagnostics.Trace.WriteLine("Print : " & vbLf & "List & Label Exception:" + llException.Message)
                Return New Response(Of String)(New [Error]("Information: " + llException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception."))
            Catch e As Exception
                System.Diagnostics.Trace.WriteLine("Print : " & vbLf & " Exception:" + e.ToString())
                Return New Response(Of String)(New [Error](e.ToString()))
            End Try

            Return New Response(Of String)(reportresult)
        End Function


        <WebMethod()> _
        <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
        Public Function GetAvailableFormats() As Response(Of ReportFormat())
            'D: Verfügbar Export Formate
            'US: available export formats

            ' D: Hier können zusätzliche Exportformate angefügt werden
            ' US: Add more export formats here
            Return New Response(Of ReportFormat())(New ReportFormat() {New ReportFormat("PDF", "Portable Document Format", ""), New ReportFormat("DOCX", "Microsoft Word Format", ""), New ReportFormat("RTF", "Richtext Format", ""), New ReportFormat("XLSX", "Microsoft Excel Format", ""), New ReportFormat("MHTML", "MIME HTML Format", ""), New ReportFormat("MTIFF", "Multipage Tagged Image File Format", "")})
        End Function

        Friend Shared Function GetReportImageUrl(dataSourceId As String, report As String) As String
            ' D: Bild URL zu Bericht holen
            ' US: Get image URL to report
            Try
                Dim reportDir As String = "/reports/" + dataSourceId + "/"
                Select Case Path.GetExtension(report)
                    Case ".lst"
                        Return reportDir + Path.GetFileName(Path.ChangeExtension(report, "lsv"))
                    Case ".lbl"
                        Return reportDir + Path.GetFileName(Path.ChangeExtension(report, "lbv"))
                    Case ".crd"
                        Return reportDir + Path.GetFileName(Path.ChangeExtension(report, "crv"))
                    Case Else
                        Return String.Empty
                End Select
            Catch generatedExceptionName As Exception
                Return String.Empty
            End Try
        End Function

        Friend Function GetReportDescription(report As String) As String
            ' D: Bericht Beschreibung holen (über DOM)
            ' US: Get report description (using DOM)
            Dim description As String = String.Empty
            Try
                Using ll As New ListLabel()
                    Dim project As ProjectBase = Nothing
                    Select Case ll.Core.LlUtilsGetProjectType(report)
                        Case LlProject.List
                            project = New ProjectList(ll)
                            Exit Select
                        Case LlProject.Card
                            project = New ProjectCard(ll)
                            Exit Select
                        Case LlProject.Label
                            project = New ProjectLabel(ll)
                            Exit Select
                    End Select

                    project.Open(report, LlDomFileMode.Open, LlDomAccessMode.[ReadOnly], True)
                    description = project.ProjectParameters("LL.ProjectDescription").Contents
                    project.Close()
                    project.Dispose()
                End Using
            Catch generatedExceptionName As Exception
            End Try

            Return description
        End Function

    End Class
End Namespace
