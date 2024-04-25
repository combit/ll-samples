using combit.Reporting.Web;
using combit.Reporting.Web.WebReportDesigner.Server;
using combit.Reporting.Web.WebReportViewer;
using combit.Reporting.Web.WindowsClientWebDesigner.Server;

using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebReporting
{
    public class SampleWebReportingApplication : System.Web.HttpApplication
    {

        public static string RepositoryDatabaseFile { get; private set; }
        public static string TempDirectory { get; private set; }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RepositoryDatabaseFile = Server.MapPath("~/App_Data/repository.db");
            TempDirectory = Server.MapPath("~/App_Data/TempFiles");
            WebReportDesignerConfig.TempDirectory = Server.MapPath("~/App_Data/TempFiles");

            // D:   Festlegen, welche Setup-Datei an Clients ohne Web Designer-Installation ausgeliefert wird.
            // US:  Define which setup file to deploy to clients without a Web Designer installation.
            WindowsClientWebDesignerConfig.WindowsClientWebDesignerSetupFile = Server.MapPath("~/WebDesigner/LL29WebDesignerSetup.exe");

            // D:   Für Forms- und Windows Authentifizierung kann der Web Designer automatisch die benötigten Informationen übernehmen (z.B. Login-Cookie).
            //      WebDesignerAuthenticationModes.None erlaubt die Verwendung ohne Authentifizierung.
            // US:  For Forms- and Windows authentication, the Web Designer can automatically grab the required information (e.g. login cookies).
            //      WebDesignerAuthenticationModes.None allows to use no authentication at all.
            WindowsClientWebDesignerConfig.AuthenticationMode = WindowsClientWebDesignerAuthenticationModes.Automatic;
        }
        
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //D: WebAPI/MVC-Routen von Web Designer registrieren. 
            //US: Register the WebAPI/MVC routes of the Web Designer.
            WindowsClientWebDesignerConfig.RegisterRoutes(routes);

            //D: WebAPI/MVC-Routen für Web Report Designer registrieren. 
            //US: Register the WebAPI/MVC routes of the Web Report Designer.
            WebReportDesignerConfig.RegisterRoutes(RouteTable.Routes);

            //D: WebAPI/MVC-Routen für Web Report Viewer registrieren. 
            //US: Register the WebAPI/MVC routes of the Web Report Viewer.
            WebReportViewerConfig.RegisterRoutes(RouteTable.Routes);
        }
  
        protected void Application_End()
        {
            try
            {
                Directory.Delete(TempDirectory, true);
            }
            catch (IOException) { }
        }


    }
}
