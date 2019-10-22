using combit.ListLabel25.AdhocDesign.Web;
using System.Web.Routing;

namespace AdhocDesignerSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // DE:  Konfigurieren der globalen Einstellungen des Ad-hoc Designers beim Anwendungsstart.
            // EN:  Configure the global settings of the Ad-hoc Designer during application startup.
            AdhocWebDesigner.Setup(new AdhocWebDesignerSettings()
            {
                // SessionManager = ...   (optional)
            });
        }
    }
}
