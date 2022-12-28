using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace projectIS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "postApplication",
                routeTemplate: "api/somiod/Application/{appName}",
                defaults: new { appName = RouteParameter.Optional }
            );
        }
    }
}
