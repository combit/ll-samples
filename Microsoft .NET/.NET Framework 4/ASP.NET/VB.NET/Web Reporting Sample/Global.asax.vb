Imports combit.Reporting
Imports combit.Reporting.Web
Imports System.Web.Routing
Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Caching
Imports combit.Reporting.Web.WindowsClientWebDesigner.Server

Namespace WebReporting
    'D:  Bitte beachten Sie die Hinweise zu den benötigten Verweisen und NuGet-Packages in der readme.txt im ASP.NET-Beispielverzeichnis.
    'US: Please note the hints on the necessary references and NuGet Packages in the readme.txt in the ASP.NET sample directory.

    Public Class [Global]
        Inherits System.Web.HttpApplication
        ' global List & Label job for better performance
        Private _baseLL As ListLabel
        Private _reportsPath As String
        Public Shared Property TempDirectory() As String
            Get
                Return m_TempDirectory
            End Get
            Private Set
                m_TempDirectory = Value
            End Set
        End Property
        Private Shared m_TempDirectory As String

        Public Shared Property RepositoryDatabaseFile() As String
            Get
                Return m_RepositoryDatabaseFile
            End Get
            Private Set
                m_RepositoryDatabaseFile = Value
            End Set
        End Property
        Private Shared m_RepositoryDatabaseFile As String

        Protected Sub Application_Start(sender As [Object], e As EventArgs)
            _baseLL = New ListLabel()

            RepositoryDatabaseFile = Server.MapPath("~/App_Data/repository.db")

            TempDirectory = Server.MapPath("~/TempFiles")

            'D: WebAPI des Html5Viewers registrieren. 
            'US: Register the viewer API
            Html5ViewerConfig.RegisterRoutes(RouteTable.Routes)
            WindowsClientWebDesignerConfig.RegisterRoutes(RouteTable.Routes)

            ' D:   Festlegen, welche Setup-Datei an Clients ohne Web Designer-Installation ausgeliefert wird.
            ' US:  Define which setup file to deploy to clients without a Web Designer installation.
            WindowsClientWebDesignerConfig.WindowsClientWebDesignerSetupFile = Server.MapPath("~/WebDesigner/LL26WebDesignerSetup.exe")

            ' D:   Für Forms- und Windows Authentifizierung kann der Web Designer automatisch die benötigten Informationen übernehmen (z.B. Login-Cookie).
            '      WebDesignerAuthenticationModes.None erlaubt die Verwendung ohne Authentifizierung.
            ' US:  For Forms- and Windows authentication, the Web Designer can automatically grab the required information (e.g. login cookies).
            '      WebDesignerAuthenticationModes.None allows to use no authentication at all.
            WindowsClientWebDesignerConfig.AuthenticationMode = WindowsClientWebDesignerAuthenticationModes.Automatic

            ' D: Lizenzschlüssel für List & Label setzen. Auf Nicht-Entwicklungsrechnern wird ein Lizenzfehler angezeigt, falls dieser nicht gesetzt wurde.
            ' US: Set license key for List & Label (client + server). If not set, a license error will be displayed on non-development machines.
            ' WebDesignerConfig.LicensingInfo = "insert license here";

            _reportsPath = Server.MapPath("~/reports/")

        End Sub

        Protected Sub Application_End(sender As Object, e As EventArgs)
            _baseLL.Dispose()

            'DE: Cache mit Daten leeren
            'US: Clear data cache
            Dim cacheKeys As List(Of String) = MemoryCache.[Default].[Select](Function(kvp) kvp.Key).ToList()
            For Each cacheKey As String In cacheKeys
                MemoryCache.[Default].Remove(cacheKey)
            Next

            Try
                Directory.Delete(TempDirectory, True)
            Catch generatedExceptionName As IOException
            End Try
        End Sub

    End Class
End Namespace
