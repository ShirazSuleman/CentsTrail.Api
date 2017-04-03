using System.Web.Http;
using CentsTrail.Api.Attributes;

namespace CentsTrail.Api
{
  public class FilterConfig
  {
    public static void Register(HttpConfiguration config)
    {
      config.Filters.Add(new AuthorizeAttribute());
      config.Filters.Add(new RequireHttpsAttribute());
    }
  }
}