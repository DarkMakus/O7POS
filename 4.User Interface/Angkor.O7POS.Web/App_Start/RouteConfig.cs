using System.Web.Mvc;
using System.Web.Routing;

namespace Angkor.O7POS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "LogIn", id = UrlParameter.Optional },
                namespaces: new[] { "Angkor.O7POS.Controller" }
            );
        }
    }
}
