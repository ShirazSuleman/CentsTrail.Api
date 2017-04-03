using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

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
        "DefaultApi",
        "api/{controller}/{id}",
        new {id = RouteParameter.Optional}
      );

      FilterConfig.Register(config);
      UnityConfig.Register(config);

      var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
  }
}