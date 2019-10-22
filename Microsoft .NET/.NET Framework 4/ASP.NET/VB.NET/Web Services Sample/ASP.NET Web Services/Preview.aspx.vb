Public Class Preview
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        Dim instance As String = Request.QueryString("instance")
        Me.Title = Convert.ToString("Preview of ") & instance

        ' D: Diese Eigenschaft dient zur Unterscheidung der verschiedenen Reports (siehe OnListLabelRequest)
        ' US: This property helps to distinguish the different reports (see OnListLabelRequest)
        Me.Html5ViewerControl1.ReportName = instance

        ' set the options
        Me.Html5ViewerControl1.Options.ShowToolbarExportButton = False
        Me.Html5ViewerControl1.Options.UseCDNType = Global.combit.ListLabel25.Web.CDNType.JQuery
    End Sub
End Class
