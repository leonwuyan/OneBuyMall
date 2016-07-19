using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OneBuyMall.WebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "Home/{action}/{id}.shtml",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "default1",
                url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "addaction",
                url: "{controller}/{action}/add.shtml",
                defaults: new { controller = "Home", action = "Index", id = 0 }
            );
            routes.MapRoute(
                name: "default2",
                url: "{controller}/{action}/{id}.shtml",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}