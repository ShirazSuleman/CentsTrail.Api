using System;
using CentsTrail.Api.Models;
using CentsTrail.Api.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace CentsTrail.Api
{
  public partial class Startup
  {
    public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

    public static string PublicClientId { get; private set; }

    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    public void ConfigureAuth(IAppBuilder app)
    {
      // Configure the db context and user manager to use a single instance per request
      app.CreatePerOwinContext(AuthorizationContext.Create);
      app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

      // Configure the application for OAuth based flow
      PublicClientId = "self";
      OAuthOptions = new OAuthAuthorizationServerOptions
      {
        TokenEndpointPath = new PathString("/Token"),
        Provider = new ApplicationOAuthProvider(PublicClientId),
        AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
        RefreshTokenProvider = new ApplicationRefreshTokenProvider(),
        AllowInsecureHttp = false
      };

      // Enable the application to use bearer tokens to authenticate users
      app.UseOAuthBearerTokens(OAuthOptions);
    }
  }
}