using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KSOAWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region 后台路由规则
            routes.MapRoute(
                    name: "AdminRouteReWrite",
                    url: "Admin/{action}.html",
                    defaults: new { controller = "Admin", action = "Login" }
                );
            routes.MapRoute(
                name: "AdminRoute",
                url: "Admin/{action}/{id}",
                defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            ); 
            #endregion

            //默认路由规则要放在最下面,否则会屏蔽自定义规则
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}