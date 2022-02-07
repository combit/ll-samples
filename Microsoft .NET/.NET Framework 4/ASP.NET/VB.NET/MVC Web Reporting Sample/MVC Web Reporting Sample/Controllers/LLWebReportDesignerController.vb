Imports combit.Reporting
Imports combit.Reporting.Web.WebReportDesigner.Server

Namespace WebReporting.Controllers
    Public Class LLWebReportDesignerController
        Inherits WebReportDesignerController

        Public Overrides Sub OnProvideListLabel(ByVal provideListLabelContext As ProvideListLabelContext)
            Dim ll As ListLabel = DefaultSettings.GetListLabelInstance(provideListLabelContext.RepositoryId, Nothing)
            provideListLabelContext.NewInstance = ll
        End Sub

        Public Overrides Sub OnProvideRepository(ByVal provideFileRepositoryContext As ProvideRepositoryContext)
            provideFileRepositoryContext.FileRepository = DefaultSettings.GetBaseRepository()
        End Sub

        Public Overrides Sub OnProvideWebReportDesignerSessionOptions(ByVal provideWebReportDesignerSessionOptionsContext As ProvideWebReportDesignerSessionOptionsContext)
            MyBase.OnProvideWebReportDesignerSessionOptions(provideWebReportDesignerSessionOptionsContext)
        End Sub

        Public Overrides Sub OnProvideProhibitedActions(ByVal provideProhibitedActionsContext As ProvideProhibitedActionsContext)
            For Each action In DefaultSettings.GetProhibitedActions()
                provideProhibitedActionsContext.ProhibitedActions.Add(action)
            Next
        End Sub
    End Class
End Namespace
