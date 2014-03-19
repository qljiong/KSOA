using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webdiyer.MvcPagerDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("PageSize", "{controller}/{action}/{pagesize}/{pageindex}",
                new
                {
                    pageindex = UrlParameter.Optional
                },
                        new { action = "PageSize" }
                    );
            routes.MapRoute("Paging", "{controller}/{action}/page_{pageindex}", new { controller = "Demo", action = "CustomRouting", pageindex = 1 }, new { action = "CustomRouting" });
            routes.MapRoute("OptionalPaging", "{controller}/{action}/pageindex-{pageindex}", new { controller = "Demo", action = "CustomRouting", pageindex = UrlParameter.Optional }, new { action = "CustomRouting" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute("ContentPaging", "{controller}/{action}/{id}/{pageIndex}",
                            new
                            {
                                controller = "Demo",
                                action = "ContentPaging",
                                pageIndex = UrlParameter.Optional
                            });
        }
    }
}