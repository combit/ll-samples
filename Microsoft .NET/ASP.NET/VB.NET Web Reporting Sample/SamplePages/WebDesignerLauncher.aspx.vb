Imports combit.ListLabel24
Imports combit.ListLabel24.Repository

Namespace WebReporting
    ' D:   Liefert eine Seite mit einer HTML/Javascript-Komponente, die den Start des Web Designers auf dem Client auslöst.
    ' US:  Returns a page that contains a HTML/Javascript component which will triggert the start of the Web Designer on the client.
    Partial Public Class WebDesignerLauncher
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(sender As Object, e As EventArgs)
            Dim LL As New ListLabel()
            Try
                Dim reportRepositoryID As String = Request.QueryString("reportRepositoryID")

                If Not RepositoryItem.IsValidItemId(reportRepositoryID) Then
                    ErrorLabel.Text = "RepositoryID invalid!"
                    ErrorLabel.Visible = True
                    DesignerControl1.Visible = False
                ElseIf Not RepositoryHelper.GetCurrentRepository().ContainsItem(reportRepositoryID) Then
                    ErrorLabel.Text = "The selected project does not exist!"
                    ErrorLabel.Visible = True
                    DesignerControl1.Visible = False
                Else
                    ' D:   Lade die zum Report passende Datenquelle.
                    ' US:  Get the corresponding data source for the report.
                    LL.DataSource = RepositoryHelper.GetDataSourceForProject(reportRepositoryID)

                    ' D:   Die Referenz auf das Repository muss an List & Label übergeben werden, damit die Repository-ID des Projekts für 'AutoProjectFile' akzeptiert wird.
                    ' US:  The repository reference must be passed to List & Label to make the repository ID of the project a valid value for the 'AutoProjectFile' property.
                    LL.FileRepository = RepositoryHelper.GetCurrentRepository()

                    ' D:   Anstelle des lokalen Dateipfads wird bei Verwendung von Repositories die ID der Datei im Repository verwendet.
                    ' US:  When using a repository, the ID of the repository item has to be set instead of the local file path.
                    LL.AutoProjectFile = reportRepositoryID
                    LL.AutoProjectType = RepositoryItemType.ToLlProject(RepositoryHelper.GetCurrentRepository().GetItem(reportRepositoryID).Type)

                    Me.DesignerControl1.ParentComponent = LL
                End If
            Catch ex As combit.ListLabel24.ListLabelException
                Response.Write(ex.Message)
                LL.Dispose()
            End Try
        End Sub
    End Class
End Namespace
