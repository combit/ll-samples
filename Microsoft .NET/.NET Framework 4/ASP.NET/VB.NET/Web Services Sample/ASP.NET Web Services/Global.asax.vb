Imports System.Data.OleDb
Imports System.Web.Routing
Imports combit.Reporting
Imports combit.Reporting.Web
Imports combit.Reporting.DataProviders
Imports System.IO


Public Class Global_asax
    Inherits System.Web.HttpApplication
    ' global List & Label job for better performance
    Private _baseLL As ListLabel
    Private _appDataPath As String
    Private _reportsPath As String

    Protected Sub Application_Start(sender As Object, e As EventArgs)
        _baseLL = New ListLabel()

        'D: WebAPI des Html5Viewers registrieren. 
        'US: Register the viewer API
        Html5ViewerConfig.RegisterRoutes(RouteTable.Routes)
        AddHandler Html5ViewerConfig.OnListLabelRequest, AddressOf Services_OnListLabelRequest

        _appDataPath = Server.MapPath("~/App_Data")
        _reportsPath = Server.MapPath("~/reports/")
    End Sub

    Protected Sub Application_End(sender As Object, e As EventArgs)
        _baseLL.Dispose()
    End Sub

    'D: Dieses Ereignis wird vom Html5Viewer ausgelöst
    'US: This event will be triggerd by the Html5Viewer
    Private Sub Services_OnListLabelRequest(sender As Object, e As ListLabelRequestEventArgs)
        Dim provider As IDataProvider = Nothing
        Dim dataMember As String = String.Empty

        ' we use the instanceName 
        Dim reportParts As String() = e.ReportName.Split("|"c)
        Dim report As String = reportParts(0)
        Dim dataSourceId As String = reportParts(1)

        Try
            'D: Datenquelle auswählen
            'US: Chose data source
            Select Case dataSourceId.ToUpperInvariant()
                Case "XML1"
                    provider = New XmlDataProvider(Path.Combine(_appDataPath, "data.xml"))
                    dataMember = "book"
                    Exit Select
                Case "XML2"
                    provider = New XmlDataProvider(Path.Combine(_appDataPath, "data2.xml"))
                    dataMember = "Companies"
                    Exit Select
                Case "JSON"
                    provider = New JsonDataProvider(File.ReadAllText(Path.Combine(_appDataPath, "data.json")))
                    Exit Select
                Case "OBJECT"
                    provider = New ObjectDataProvider(combit.Services.GenericList.GetGenericList())
                    Exit Select
                Case "OLEDB"
                    provider = New OleDbConnectionDataProvider(New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Mode=Read;data source=" + Path.Combine(_appDataPath, "NWIND.MDB")))
                    dataMember = "Customers"
                    Exit Select
                Case "CSV"
                    provider = New CsvDataProvider(Path.Combine(_appDataPath, "iislog.csv"), True, "Log", ControlChars.Tab, 0, False)
                    Exit Select
            End Select

            ' D: List & Label Objekt erzeugen 
            ' US: Create List & Label object 
            Dim ll As New ListLabel()

            ll.DataSource = provider

            If Not String.IsNullOrEmpty(dataMember) Then
                ll.DataMember = dataMember
            End If

            ll.AutoProjectFile = Convert.ToString((_reportsPath & dataSourceId) + "/") & report
            ll.AutoDestination = LlPrintMode.File

            e.ExportPath = Path.GetTempPath()
            ' set temp directory
            ' return the instance
            e.NewInstance = ll
        Catch llException As ListLabelException
            System.Diagnostics.Trace.WriteLine("Print : " & vbLf & "List & Label Exception:" + llException.Message)
            Return
        Catch baseException As Exception
            System.Diagnostics.Trace.WriteLine("Print : " & vbLf & " Exception:" + baseException.ToString())
            Return
        End Try
    End Sub
End Class

