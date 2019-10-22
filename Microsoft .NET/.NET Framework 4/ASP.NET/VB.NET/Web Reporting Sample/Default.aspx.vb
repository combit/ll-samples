Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections.Generic
Imports combit.ListLabel25.Repository
Imports System.Linq

Namespace WebReporting
    ''' <summary>
    ''' Summary description for Default.
    ''' </summary>
    Partial Public Class [Default]
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(sender As Object, e As System.EventArgs)
            'D:    ComboBox mit den Listen fuellen
            'US:   Fill combobox with the available reports
            If Not Page.IsPostBack Then
                FillCombo()
                ContentContainer.Attributes("src") = Request.ApplicationPath.TrimEnd("/"c) + "/SamplePages/StartPage.aspx"
            End If

            Dim t As String = DropDownListProjectFile.SelectedValue
        End Sub

        Private Sub FillCombo()
            Try
                'D: List Projekte der DropDownlist hinzufügen
                'US: Get all files from the \Reports directory
                DropDownListProjectFile.Items.Clear()

                Dim reportList As New List(Of ListItem)()

                For Each repositoryItem As CustomizedRepostoryItem
                    In RepositoryHelper.GetCurrentRepository().GetAllItems().OfType(Of CustomizedRepostoryItem)()
                    If RepositoryItemType.IsProjectType(repositoryItem.Type, False) AndAlso repositoryItem.ShowInToolbar Then
                        reportList.Add(New ListItem(If(repositoryItem.ExtractDisplayName(), repositoryItem.InternalID), repositoryItem.InternalID))

                    End If
                Next
                reportList.Sort(Function(a, b) a.Text.CompareTo(b.Text))
                DropDownListProjectFile.DataTextField = "Text"
                DropDownListProjectFile.DataValueField = "Value"
                DropDownListProjectFile.DataSource = reportList
                DropDownListProjectFile.DataBind()
            Catch ex As Exception
                Response.Write(ex.ToString())
            End Try
        End Sub

        Protected Sub DesignReport(sender As Object, e As System.EventArgs)
            If DropDownListProjectFile.SelectedItem IsNot Nothing Then
                'D: Ausgewählte Projektdatei und Format
                'US: Get the choosen project file and format
                Dim reportRepositoryID As String = DropDownListProjectFile.SelectedItem.Value
                ContentContainer.Attributes("src") = [String].Format("{0}/SamplePages/WebDesignerLauncher.aspx?reportRepositoryID={1}", Request.ApplicationPath.TrimEnd("/"c), reportRepositoryID)
            End If
        End Sub

        Protected Sub CreateNewProject(sender As Object, e As System.EventArgs)
            ContentContainer.Attributes("src") = Request.ApplicationPath.TrimEnd("/"c) + "/SamplePages/AddItem.aspx"
        End Sub


        Protected Sub StartPage(sender As Object, e As System.EventArgs)
            ContentContainer.Attributes("src") = Request.ApplicationPath.TrimEnd("/"c) + "/SamplePages/StartPage.aspx"
        End Sub

        Protected Sub ViewReport()
            If DropDownListProjectFile.SelectedItem IsNot Nothing Then
                'D: Ausgewählte Projektdatei und Format
                'US: Get the choosen project file and format
                Dim reportRepositoryID As String = DropDownListProjectFile.SelectedItem.Value
                ContentContainer.Attributes("src") = Convert.ToString(Request.ApplicationPath.TrimEnd("/"c) + "/SamplePages/HTML5Viewer.aspx?reportRepositoryID=") & reportRepositoryID
            End If
        End Sub

        Protected Sub DropDownListProjectFile_SelectedIndexChanged(sender As Object, e As EventArgs)
            ViewReport()
        End Sub
    End Class
End Namespace
