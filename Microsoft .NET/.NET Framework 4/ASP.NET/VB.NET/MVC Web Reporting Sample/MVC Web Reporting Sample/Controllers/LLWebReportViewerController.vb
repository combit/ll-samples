Imports combit.Reporting
Imports combit.Reporting.Web.WebReportViewer
Imports System.IO

Namespace WebReporting.Controllers
    Public Class LLWebReportViewerController
        Inherits WebReportViewerController

        Public Overrides Sub OnProvideListLabel(ByVal provideListLabelContext As ProvideListLabelContext)
            Dim repositoryIdOfProject As String = provideListLabelContext.ProjectName
            Dim ll As ListLabel = DefaultSettings.GetListLabelInstance(repositoryIdOfProject, DefaultSettings.GetBaseRepository())
            ll.Core.LlXSetParameter(LlExtensionType.Export, "HTML5", "XHTML.ForceTableLineOneHundredPercentageWidth", "1")
            provideListLabelContext.ExportPath = Path.Combine(SampleWebReportingApplication.TempDirectory, Guid.NewGuid().ToString("D"))
            ll.Variables.Add("ItemList.ItemNo.From", String.Empty)
            ll.Variables.Add("ItemList.ItemNo.To", String.Empty)
            provideListLabelContext.NewInstance = ll
        End Sub

        Public Overrides Sub OnProvideRepository(ByVal provideFileRepositoryContext As ProvideRepositoryContext)
            provideFileRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository()
        End Sub
    End Class
End Namespace
