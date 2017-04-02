using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(CentsTrail.Api.Startup))]

namespace CentsTrail.Api
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();

      ConfigureAuth(app);

      WebApiConfig.Register(config);

      app.UseCors(CorsOptions.AllowAll);

      app.UseWebApi(config);
    }
  }
}
