using combit.Reporting.AdhocDesign.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdhocDesignerSample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // DE:  Registriere die Routen für den Ad-hoc Designer. Wichtig: Dies muss vor dem registrieren der Default-Route passieren.
            // EN:  Let the Ad-hoc Designer register the routes. Important: This must happen before adding the default route!
            AdhocWebDesigner.RegisterRoutes(routes);

            // Default route:
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "AdhocDesignerTest.Controllers", "combit.Reporting.AdhocDesign.Web.Controllers" }
            );
        }
    }
}
