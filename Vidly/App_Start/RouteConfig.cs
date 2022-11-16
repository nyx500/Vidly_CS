using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            // Allows attribute routing instead of classic custom-route construction
            routes.MapMvcAttributeRoutes();


            /// OLD VERSION OF A CUSTOM ROUTE: NO LONGER USED BECAUSE BAD PRACTICE / FRAGILE CODEs
            //routes.MapRoute(
            //    // name of the new custom route
            //    name: "MoviesByReleaseDate",
            //    // url with the custom parameters the controller will take
            //    url:"movies/released/{year}/{month}",
            //    // anonymous object created in defaults to direct to the correct controller in Controllers folder
            //    defaults:new {controller = "Movies", action = "ByReleaseDate"},
            //    constraints: new {year = @"\d{4}", month=@"\d{2}"}    
            //    );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
