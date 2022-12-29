using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace projectIS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new XmlMediaTypeFormatter());
            //config.Formatters.Add(new JsonMediaTypeFormatter());
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PostApplication",
                routeTemplate: "api/somiod"
            );
            config.Routes.MapHttpRoute(
                name: "PutApplication",
                routeTemplate: "api/somiod/{appName}",
                defaults: new { appName = RouteParameter.Optional }
            );

        }
    }
}
