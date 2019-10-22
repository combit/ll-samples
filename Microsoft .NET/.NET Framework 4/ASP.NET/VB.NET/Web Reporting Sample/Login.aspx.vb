Imports System.Web.Security
Imports System.Web.UI

Namespace WebReporting
    Partial Public Class Login
        Inherits System.Web.UI.Page
        Protected Sub ButtonLogin_Click(sender As Object, e As EventArgs)
            If Page.IsValid Then
                ' D:   Dummy-Login zur Demonstration der Nutzung des Web Designers mit Forms Authentication
                ' US:  Dummy-Login for demonstration of using the Web Designer with Forms Autentication.
                FormsAuthentication.SetAuthCookie(TextBoxUserName.Text, False)
                Response.Redirect(FormsAuthentication.GetRedirectUrl(TextBoxUserName.Text, False))
            End If
        End Sub
    End Class
End Namespace