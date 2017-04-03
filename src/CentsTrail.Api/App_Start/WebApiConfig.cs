using CentsTrail.Api.Filters;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System;

namespace CentsTrail.Api
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      // Configure Web API to use only bearer token authentication.
      config.SuppressDefaultHostAuthentication();
      config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

      FilterConfig.Register(config);
      UnityConfig.Register(config);

      config.EnableSwagger(c =>
                            {
                              c.SingleApiVersion("v1", "CentsTrail.Api")
                               .Description("An API for the CentsTrail web application.");
                              c.OperationFilter<AddAuthorizationHeader>();
                              c.IncludeXmlComments(GetXmlCommentsPath());
                              c.DescribeAllEnumsAsStrings();
                            })
            .EnableSwaggerUi();

      var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }

    private static string GetXmlCommentsPath()
    {
      return $@"{AppDomain.CurrentDomain.BaseDirectory}\App_Data\CentsTrail.Api.XML";
    }
  }
}