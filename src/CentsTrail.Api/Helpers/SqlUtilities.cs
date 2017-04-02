using System.Configuration;

namespace CentsTrail.Api.Helpers
{
  public static class SqlUtilities
  {
    public static string DefaultConnectionString
    {
      get
      {
        return ConfigurationManager.ConnectionStrings[Constants.DEFAULT_CONNECTION_STRING].ConnectionString;
      }
    }
  }
}