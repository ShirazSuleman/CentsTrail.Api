using System.Web.Http;
using CentsTrail.Api;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

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
      app.UseWelcomePage();
    }
  }
}