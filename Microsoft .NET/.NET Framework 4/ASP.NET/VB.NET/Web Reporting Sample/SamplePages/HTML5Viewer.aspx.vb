Imports combit.Reporting
Imports combit.Reporting.Repository
Imports combit.Reporting.Web
Imports System.IO
Imports System.Web

Namespace WebReporting
    ' D:   Öffnet den Html5Viewer für das Projekt mit der angegebenen Repository-ID
    ' US:  Loads the Html5Viewer for the project with with specified repository ID.
    Partial Public Class HTML5Viewer
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            Dim reportRepositoryID As String = Request.QueryString("reportRepositoryID")
            If reportRepositoryID IsNot Nothing Then
                If Not RepositoryItem.IsValidItemId(reportRepositoryID) Then
                    Throw New HttpException(404, "Bad Request")
                End If

                If Not RepositoryHelper.GetCurrentRepository().ContainsItem(reportRepositoryID) Then
                    LabelError.Text = "The selected project does not exist"
                    LabelError.Visible = True
                    Html5ViewerControl1.Visible = False
                    Return
                End If

                If RepositoryHelper.GetCurrentRepository().GetItem(reportRepositoryID).IsEmpty Then
                    LabelError.Text = "The selected project is empty. Please run the Designer first."
                    LabelError.Visible = True
                    Html5ViewerControl1.Visible = False
                    Return
                End If

                ' D:   'ReportName' wird im OnListLabelRequest-Event wieder zurückgeliefert, wo der Pfad zur Projektdatei gesetzt werden muss.
                '      Anstelle des lokalen Dateipfads wird bei Verwendung von Repositories die ID der Datei im Repository verwendet.
                ' US:  The report name is returned in the OnListLabelRequest Event, where we need to set the project file.
                '      When using a repository, the ID of the repository item has to be set instead of the local file path.
                Me.Html5ViewerControl1.ReportName = reportRepositoryID

                ' D:   Html5ViewerControl Options
                ' US:  Html5ViewerControl options
                Dim options As New Html5ViewerOptions()
                AddHandler options.OnListLabelRequest, AddressOf Services_OnListLabelRequest
                options.UseUIMiniStyle = True
                Me.Html5ViewerControl1.Options = options
            End If
        End Sub


        'D: Dieses Ereignis wird vom Html5Viewer ausgelöst
        'US: This event will be triggered by the Html5Viewer
        Private Sub Services_OnListLabelRequest(sender As Object, e As ListLabelRequestEventArgs)
            Dim repositoryIdOfProject As String = e.ReportName

            ' D: List & Label Objekt erzeugen 
            ' US: Create List & Label object 
            Dim ll As New ListLabel()

            ' D:   Lizenzschlüssel für List & Label setzen. Auf Nicht-Entwicklungsrechnern wird ein Lizenzfehler angezeigt, falls dieser nicht gesetzt wurde.
            ' US:  Set license key for List & Label (client + server). If not set, a license error will be displayed on non-development machines.
            ' ll.LicensingInfo = "insert license here";

            Try
                ' D:   Die Referenz auf das Repository muss an List & Label übergeben werden, damit die Repository-ID des Projekts für 'AutoProjectFile' akzeptiert wird.
                ' US:  The repository reference must be passed to List & Label to make the repository ID of the project a valid value for the 'AutoProjectFile' property.
                ll.FileRepository = RepositoryHelper.GetCurrentRepository()
                ll.AutoProjectFile = repositoryIdOfProject

                ' D:   Lade die zum Report passende Datenquelle.
                ' US:  Get the corresponding data source for the report.
                ll.DataSource = RepositoryHelper.GetDataSourceForProject(repositoryIdOfProject)

                ' D:   Der Html5Viewer benötigt ein Verzeichnis für temporäre Dateien. Diese werden einige Minuten nach Schließen eines Html5Viewers automatisch gelöscht.
                ' US:  The Html5Viewer requires a directory for temporary files. Some minutes after a Html5Viewer is closed, these files will be deleted automatically.
                e.ExportPath = Path.Combine([Global].TempDirectory, Guid.NewGuid().ToString("D"))

                e.NewInstance = ll
            Catch LlException As ListLabelException
                Response.Write("<br><br><b>An error occurred:</b> " + LlException.Message)
                ll.Dispose()
                Return
            End Try
        End Sub
    End Class


End Namespace
