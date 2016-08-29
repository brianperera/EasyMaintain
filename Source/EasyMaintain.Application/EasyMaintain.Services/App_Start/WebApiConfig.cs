using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EasyMaintain.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "SparePart",
            routeTemplate: "api/spareparts/{id}",
            defaults: new { controller = "spareparts", id = RouteParameter.Optional }


                );

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            

        }
    }
}
