using System.Configuration;

namespace CentsTrail.Api.Helpers
{
  public static class SqlUtilities
  {
    public static string DefaultConnectionString
      => ConfigurationManager.ConnectionStrings[Constants.DefaultConnectionString].ConnectionString;
  }
}