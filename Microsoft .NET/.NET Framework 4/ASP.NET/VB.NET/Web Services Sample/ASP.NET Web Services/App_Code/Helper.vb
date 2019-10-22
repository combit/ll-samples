Namespace ASP.NET_Web_Services
    Public NotInheritable Class MimeTypes
        Private Shared fileExtensions As IDictionary(Of String, String) = New Dictionary(Of String, String)()

        Private Sub New()
        End Sub

        Public Shared Sub Init()
            SyncLock fileExtensions
                If fileExtensions.Count = 0 Then
                    fileExtensions.Add(".bin", "application/octet-stream")
                    fileExtensions.Add(".bmp", "image/bmp")
                    fileExtensions.Add(".doc", "application/msword")
                    fileExtensions.Add(".dot", "application/msword")
                    fileExtensions.Add(".gif", "image/gif")
                    fileExtensions.Add(".htm", "text/html")
                    fileExtensions.Add(".html", "text/html")
                    fileExtensions.Add(".ico", "image/x-icon")
                    fileExtensions.Add(".jpe", "image/jpeg")
                    fileExtensions.Add(".jpeg", "image/jpeg")
                    fileExtensions.Add(".jpg", "image/jpeg")
                    fileExtensions.Add(".mht", "message/rfc822")
                    fileExtensions.Add(".mhtml", "message/rfc822")
                    fileExtensions.Add(".pdf", "application/pdf")
                    fileExtensions.Add(".png", "image/png")
                    fileExtensions.Add(".rtf", "application/rtf")
                    fileExtensions.Add(".rtx", "text/richtext")
                    fileExtensions.Add(".tif", "image/tiff")
                    fileExtensions.Add(".tiff", "image/tiff")
                    fileExtensions.Add(".txt", "text/plain")
                    fileExtensions.Add(".xla", "application/vnd.ms-excel")
                    fileExtensions.Add(".xlc", "application/vnd.ms-excel")
                    fileExtensions.Add(".xlm", "application/vnd.ms-excel")
                    fileExtensions.Add(".xls", "application/vnd.ms-excel")
                    fileExtensions.Add(".xlt", "application/vnd.ms-excel")
                    fileExtensions.Add(".xlw", "application/vnd.ms-excel")

                    fileExtensions.Add(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    fileExtensions.Add(".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template")
                    fileExtensions.Add(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                    fileExtensions.Add(".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template")
                    fileExtensions.Add(".xlam", "application/vnd.ms-excel.addin.macroEnabled.12")
                    fileExtensions.Add(".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12")
                End If
            End SyncLock
        End Sub

        Public Shared Function GetMimeTypeByFileExtension(fileExtension As [String]) As String
            ' D: Gibt einen MIME-Type aufgrund der Dateiendung zurück
            ' US: Get MIME-Type by file extensions
            Init()
            Return If(fileExtensions.ContainsKey(fileExtension), fileExtensions(fileExtension), Nothing)
        End Function
    End Class
End Namespace