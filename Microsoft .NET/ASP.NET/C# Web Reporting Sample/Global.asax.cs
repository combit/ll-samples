using System;
using combit.ListLabel24;
using combit.ListLabel24.Web;
using System.Web.Routing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using combit.ListLabel24.Web.WebDesigner.Server;

namespace WebReporting
{
    //D:  Bitte beachten Sie die Hinweise zu den benötigten Verweisen und NuGet-Packages in der readme.txt im ASP.NET-Beispielverzeichnis.
    //US: Please note the hints on the necessary references and NuGet Packages in the readme.txt in the ASP.NET sample directory.

    public class Global : System.Web.HttpApplication
    {
        // global List & Label job for better performance
        private ListLabel _baseLL;
        private string _reportsPath;
        public static string TempDirectory { get; private set; }

        public static string RepositoryDatabaseFile { get; private set; }

        protected void Application_Start(Object sender, EventArgs e)
        {
            _baseLL = new ListLabel();

            RepositoryDatabaseFile = Server.MapPath("~/App_Data/repository.db");

            TempDirectory = Server.MapPath("~/TempFiles");

            //D: WebAPI des Html5Viewers registrieren. 
            //US: Register the viewer API
            Html5ViewerConfig.RegisterRoutes(RouteTable.Routes);
            WebDesignerConfig.RegisterRoutes(RouteTable.Routes);

            // D:   Festlegen, welche Setup-Datei an Clients ohne Web Designer-Installation ausgeliefert wird.
            // US:  Define which setup file to deploy to clients without a Web Designer installation.
            WebDesignerConfig.WebDesignerSetupFile = Server.MapPath("~/WebDesigner/LL24WebDesignerSetup.exe");

            // D:   Für Forms- und Windows Authentifizierung kann der Web Designer automatisch die benötigten Informationen übernehmen (z.B. Login-Cookie).
            //      WebDesignerAuthenticationModes.None erlaubt die Verwendung ohne Authentifizierung.
            // US:  For Forms- and Windows authentication, the Web Designer can automatically grab the required information (e.g. login cookies).
            //      WebDesignerAuthenticationModes.None allows to use no authentication at all.
            WebDesignerConfig.AuthenticationMode = WebDesignerAuthenticationModes.Automatic;

            // D: Lizenzschlüssel für List & Label setzen. Auf Nicht-Entwicklungsrechnern wird ein Lizenzfehler angezeigt, falls dieser nicht gesetzt wurde.
            // US: Set license key for List & Label (client + server). If not set, a license error will be displayed on non-development machines.
            // WebDesignerConfig.LicensingInfo = "insert license here";

            _reportsPath = Server.MapPath("~/reports/");

        }

        protected void Application_End(object sender, EventArgs e)
        {
            _baseLL.Dispose();

            //DE: Cache mit Daten leeren
            //US: Clear data cache
            List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                MemoryCache.Default.Remove(cacheKey);
            }

            try
            {
                Directory.Delete(TempDirectory, true);
            }
            catch (IOException) { }
        }

    }
}
