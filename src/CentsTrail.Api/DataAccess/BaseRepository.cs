using System.Data;

namespace CentsTrail.Api.DataAccess
{
  public abstract class BaseRepository
  {
    protected IDbConnection Database;

    public BaseRepository(IDbConnection database)
    {
      Database = database;
    }
  }
}