using Microsoft.Owin.Security.Infrastructure;
using System;

namespace CentsTrail.Api.Providers
{
  public class ApplicationRefreshTokenProvider : AuthenticationTokenProvider
  {
    public override void Create(AuthenticationTokenCreateContext context)
    {
      context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(24));
      context.SetToken(context.SerializeTicket());
    }

    public override void Receive(AuthenticationTokenReceiveContext context)
    {
      context.DeserializeTicket(context.Token);
    }
  }
}