Imports combit.ListLabel24.Web
Imports combit.ListLabel24.Web.WebDesigner.Server
Imports System.IO
Imports System.Web.Mvc
Imports System.Web.Routing

Namespace WebReporting
    Public Class SampleWebReportingApplication
        Inherits System.Web.HttpApplication

        Public Shared Property RepositoryDatabaseFile() As String
            Get
                Return m_RepositoryDatabaseFile
            End Get
            Private Set
                m_RepositoryDatabaseFile = Value
            End Set
        End Property
        Private Shared m_RepositoryDatabaseFile As String
        Public Shared Property TempDirectory() As String
            Get
                Return m_TempDirectory
            End Get
            Private Set
                m_TempDirectory = Value
            End Set
        End Property
        Private Shared m_TempDirectory As String

        Protected Sub Application_Start()
            RegisterRoutes(RouteTable.Routes)

            RepositoryDatabaseFile = Server.MapPath("~/App_Data/repository.db")
            TempDirectory = Server.MapPath("~/App_Data/TempFiles")

            ' D:   Festlegen, welche Setup-Datei an Clients ohne Web Designer-Installation ausgeliefert wird.
            ' US:  Define which setup file to deploy to clients without a Web Designer installation.
            WebDesignerConfig.WebDesignerSetupFile = Server.MapPath("~/WebDesigner/LL24WebDesignerSetup.exe")

            ' D:   Für Forms- und Windows Authentifizierung kann der Web Designer automatisch die benötigten Informationen übernehmen (z.B. Login-Cookie).
            '      WebDesignerAuthenticationModes.None erlaubt die Verwendung ohne Authentifizierung.
            ' US:  For Forms- and Windows authentication, the Web Designer can automatically grab the required information (e.g. login cookies).
            '      WebDesignerAuthenticationModes.None allows to use no authentication at all.
            WebDesignerConfig.AuthenticationMode = WebDesignerAuthenticationModes.Automatic
        End Sub

        Public Sub RegisterRoutes(routes As RouteCollection)
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

            'D: WebAPI/MVC-Routen von Html5Viewer und Web Designer registrieren. 
            'US: Register the WebAPI/MVC routes of the Html5Viewer and Web Designer.
            Html5ViewerConfig.RegisterRoutes(routes)
            WebDesignerConfig.RegisterRoutes(routes)

            routes.MapRoute(name:="Default", url:="{controller}/{action}/{id}", defaults:=New With {
                Key .controller = "Sample",
                Key .action = "Index",
                Key .id = UrlParameter.[Optional]
            })
        End Sub

        Protected Sub Application_End()
            Try
                Directory.Delete(TempDirectory, True)
            Catch generatedExceptionName As IOException
            End Try
        End Sub


    End Class
End Namespace
