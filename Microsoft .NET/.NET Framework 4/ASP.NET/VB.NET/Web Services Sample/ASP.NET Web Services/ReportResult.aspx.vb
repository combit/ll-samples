Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ASP.NET_Web_Services
    Partial Public Class ReportResult
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(sender As Object, e As EventArgs)
            ' D: Berichtnamen im Titel anzeigen
            ' US: Show report name in title
            Dim report As String = Request.QueryString("file")
            Me.Title = report
        End Sub
    End Class
End Namespace
