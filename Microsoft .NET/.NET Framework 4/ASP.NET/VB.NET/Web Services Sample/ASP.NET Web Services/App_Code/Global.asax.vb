Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.SessionState
Imports combit.ListLabel25

Namespace ASP.NET_Web_Services
    Public Class [Global]
        Inherits System.Web.HttpApplication
        ' global List & Label job for better performance
        Private _baseLL As ListLabel

        Protected Sub Application_Start(sender As Object, e As EventArgs)
            _baseLL = New ListLabel()
        End Sub

        Protected Sub Application_End(sender As Object, e As EventArgs)
            _baseLL.Dispose()
        End Sub
    End Class
End Namespace
