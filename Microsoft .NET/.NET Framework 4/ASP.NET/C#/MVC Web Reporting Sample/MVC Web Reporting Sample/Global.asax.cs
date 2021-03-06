﻿using combit.Reporting.Web;
using combit.Reporting.Web.WindowsClientWebDesigner.Server;

using System.IO;
using System.Web.Mvc;
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

            RepositoryDatabaseFile = Server.MapPath("~/App_Data/repository.db");
            TempDirectory = Server.MapPath("~/App_Data/TempFiles");

            // D:   Festlegen, welche Setup-Datei an Clients ohne Web Designer-Installation ausgeliefert wird.
            // US:  Define which setup file to deploy to clients without a Web Designer installation.
            WindowsClientWebDesignerConfig.WindowsClientWebDesignerSetupFile = Server.MapPath("~/WebDesigner/LL26WebDesignerSetup.exe");

            // D:   Für Forms- und Windows Authentifizierung kann der Web Designer automatisch die benötigten Informationen übernehmen (z.B. Login-Cookie).
            //      WebDesignerAuthenticationModes.None erlaubt die Verwendung ohne Authentifizierung.
            // US:  For Forms- and Windows authentication, the Web Designer can automatically grab the required information (e.g. login cookies).
            //      WebDesignerAuthenticationModes.None allows to use no authentication at all.
            WindowsClientWebDesignerConfig.AuthenticationMode = WindowsClientWebDesignerAuthenticationModes.Automatic;
        }
        
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //D: WebAPI/MVC-Routen von Html5Viewer und Web Designer registrieren. 
            //US: Register the WebAPI/MVC routes of the Html5Viewer and Web Designer.
            Html5ViewerConfig.RegisterRoutes(routes);
            WindowsClientWebDesignerConfig.RegisterRoutes(routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Sample", action = "Index", id = UrlParameter.Optional }
            );
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
