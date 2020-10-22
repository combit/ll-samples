Option Infer On
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Threading
Imports combit.Reporting.Repository

Namespace WebReporting
    Partial Public Class StartPage
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If Request.QueryString("action") IsNot Nothing AndAlso Request.QueryString("action") = "DeleteItem" Then
                Dim repoItemId As String = Request.QueryString("reportRepositoryID")
                If repoItemId IsNot Nothing Then
                    repoItemId = HttpUtility.UrlDecode(repoItemId)
                    If combit.Reporting.Repository.RepositoryItem.IsValidItemId(repoItemId) Then
                        RepositoryHelper.GetCurrentRepository().DeleteItem(repoItemId)
                    End If
                End If
            ElseIf Request.QueryString("action") IsNot Nothing AndAlso Request.QueryString("action") = "DownloadItem" Then
                Dim repoItemId As String = Request.QueryString("reportRepositoryID")
                If repoItemId IsNot Nothing Then
                    repoItemId = HttpUtility.UrlDecode(repoItemId)
                    If combit.Reporting.Repository.RepositoryItem.IsValidItemId(repoItemId) Then
                        Dim repository = RepositoryHelper.GetCurrentRepository()
                        Dim itemToDownload = DirectCast(repository.GetItem(repoItemId), CustomizedRepostoryItem)

                        ' D:    Dateinamen bestimmen. Verwende den ursprünglichen Dateinamen (vor dem Import), den Anzeigenamen (aus dem Designer) oder die RepositoryItem-ID.
                        ' US:   Get the file name. Use the original filename (before the import), the display name (from the Designer) or the repository item ID.
                        Dim fileName As String = itemToDownload.OriginalFileName
                        If String.IsNullOrEmpty(fileName) Then
                            fileName = itemToDownload.ExtractDisplayName() & ".bin"
                        End If
                        If String.IsNullOrEmpty(fileName) Then
                            fileName = itemToDownload.InternalID & ".bin"
                        End If

                        Using memoryStream = New MemoryStream()
                            repository.LoadItem(repoItemId, memoryStream, CancellationToken.None)
                            Response.Clear()
                            Response.ContentType = "application/octet-stream"
                            Response.AddHeader("Content-Disposition", Convert.ToString("attachment; filename=") & fileName)
                            Dim buffer As Byte() = memoryStream.ToArray()
                            Response.OutputStream.Write(buffer, 0, buffer.Length)
                            Response.Flush()
                            Response.[End]()

                        End Using
                    End If

                End If
            End If

            If Not IsPostBack Then
                LiteralReadMe.Text = File.ReadAllText(Server.MapPath("~/Readme.html"))
                Dim repositoryItems As IEnumerable(Of CustomizedRepostoryItem) = RepositoryHelper.GetCurrentRepository().GetAllItems().OfType(Of CustomizedRepostoryItem)()

                ' D:   Sortiere die Liste der Repository-Items alphabetisch nach Anzeigename.
                ' US:  Sort the repository item list alphabetically by the display name.
                repositoryItems = From r In repositoryItems Order By If(r.ExtractDisplayName(), r.InternalID) Select r
                RepeaterRepository.DataSource = repositoryItems
                RepeaterRepository.DataBind()
            End If
        End Sub

        Protected Sub RepeaterRepository_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim repoItem As CustomizedRepostoryItem = TryCast(e.Item.DataItem, CustomizedRepostoryItem)

                ' D:   Lese den Anzeigenamen des Repository-Items aus. Dieser ist optional und kann null sein! Daher Fallback auf die Repository-ID.
                ' US:  Get the repository item's display name. This name is optional and may be null! So fallback to the repository ID.
                DirectCast(e.Item.FindControl("LabelItemName"), Label).Text = If(repoItem.ExtractDisplayName(), repoItem.InternalID + " (no display name defined)")

                Dim encodedId As String = HttpUtility.UrlEncode(repoItem.InternalID)
                Dim linkViewer As HyperLink = DirectCast(e.Item.FindControl("LinkHtml5Viewer"), HyperLink)
                linkViewer.NavigateUrl = Convert.ToString("~/SamplePages/HTML5Viewer.aspx?reportRepositoryID=") & encodedId
                Dim linkDesigner As HyperLink = DirectCast(e.Item.FindControl("LinkDesigner"), HyperLink)
                linkDesigner.NavigateUrl = Convert.ToString("~/SamplePages/WebDesignerLauncher.aspx?reportRepositoryID=") & encodedId
                Dim linkDownload As HyperLink = DirectCast(e.Item.FindControl("LinkDownload"), HyperLink)
                linkDownload.NavigateUrl = Convert.ToString("~/SamplePages/StartPage.aspx?action=DownloadItem&reportRepositoryID=") & encodedId

                If RepositoryItemType.IsProjectType(repoItem.Type, False) Then
                    ' Show Designer/Html5Viewer links only for project files
                    linkViewer.Visible = True
                    linkDesigner.Visible = True
                End If

                Dim linkDelete As HyperLink = DirectCast(e.Item.FindControl("LinkDelete"), HyperLink)
                linkDelete.NavigateUrl = Convert.ToString("~/SamplePages/StartPage.aspx?action=DeleteItem&reportRepositoryID=") & encodedId
            End If
        End Sub
    End Class
End Namespace
