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
                name: "AdminHome",
                url: "Admin/",
                defaults: new { controller = "Admin", action = "Index" }
            );
            routes.MapRoute(
                name: "Admin",
                url: "Admin/{action}.shtml",
                defaults: new { controller = "Admin", action = "Index" }
            );
            routes.MapRoute(
                name: "AdminAdd",
                url: "Admin/{action}/add.shtml",
                defaults: new { controller = "Admin", action = "Index", id = 0 }
            );
            routes.MapRoute(
                name: "AdminID",
                url: "Admin/{action}/{id}.shtml",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HomePage1",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name:"HomePage",
                url:"{action}.shtml",
                defaults: new { controller = "Home", action = "Login"}
            );
            routes.MapRoute(
                name: "Helper",
                url: "Helper/{gid}-{id}.shtml",
                defaults: new { controller = "Helper", action = "Index", gid= UrlParameter.Optional, id=UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Cart",
                url: "Cart/index.shtml",
                defaults: new { controller = "Cart", action = "Index" }
            );
            routes.MapRoute(
                name: "CartAction",
                url: "Cart/{action}",
                defaults: new { controller = "Cart", action = "Index" }
            );
        }
    }
}