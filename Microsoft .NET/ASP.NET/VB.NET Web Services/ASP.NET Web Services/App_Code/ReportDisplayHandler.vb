Imports System.IO

Namespace ASP.NET_Web_Services
    Public NotInheritable Class ReportDisplayHandler
        Implements IHttpHandler

        ''' <summary>
        ''' You will need to configure this handler in the web.config file of your 
        ''' web and register it with IIS before being able to use it. For more information
        ''' see the following link: http://go.microsoft.com/?linkid=8101007
        ''' </summary>
#Region "IHttpHandler Members"

        Public ReadOnly Property IsReusable() As Boolean
            ' Return false in case your Managed Handler cannot be reused for another request.
            ' Usually this would be false in case you have some state information preserved per request.
            Get
                Return True
            End Get
        End Property

        Public Sub ProcessRequest(context As HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
            Try
                Dim contentType As String = Nothing

                'e.g.: Report.2c214866-73d4-4544-934a-38f67bb15bc4.pdf
                Dim fileName As String = context.Request.FilePath

                System.Diagnostics.Trace.WriteLine("ReportDisplayHandler::ProcessRequest : FilePath: " + fileName)

                Dim urlParts As String() = fileName.Split("/"c)

                If urlParts.Length > 0 Then
                    fileName = urlParts(urlParts.Length - 1)
                End If


                Dim fileParts As String() = fileName.Split("."c)
                If fileParts.Length = 3 Then
                    contentType = ASP.NET_Web_Services.MimeTypes.GetMimeTypeByFileExtension("." + fileParts(2))
                End If

                Dim reportResultDir As String = System.IO.Path.GetTempPath()
                Dim absoluteServerFilePath As String = reportResultDir + fileName

                context.Response.Clear()
                context.Response.Buffer = True

                If Not [String].IsNullOrEmpty(contentType) AndAlso File.Exists(absoluteServerFilePath) Then
                    context.Response.ContentType = contentType
                    context.Response.WriteFile(absoluteServerFilePath)
                End If

                context.Response.[End]()

                ' delete after using
                If File.Exists(absoluteServerFilePath) Then
                    File.Delete(absoluteServerFilePath)
                End If
            Catch e As Exception
                System.Diagnostics.Trace.WriteLine("ReportDisplayHandler::ProcessRequest : " & vbLf & "Exception:" + e.ToString())
            End Try
        End Sub

#End Region

        Public ReadOnly Property IsReusable1 As Boolean Implements System.Web.IHttpHandler.IsReusable
            Get
                Return (IsReusable)
            End Get
        End Property
    End Class
End Namespace
