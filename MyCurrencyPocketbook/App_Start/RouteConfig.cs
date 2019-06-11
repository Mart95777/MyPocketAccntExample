using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyCurrencyPocketbook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Demo1",
                url: "Demo1/{optionId}",
                defaults: new { controller = "Home", action = "Demo1", optionId = "0" }
            );

            routes.MapRoute(
                name: "Demo2",
                url: "Demo2",
                defaults: new { controller = "Home", action = "Demo2" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
