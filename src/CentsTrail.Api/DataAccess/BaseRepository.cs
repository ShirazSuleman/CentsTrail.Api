using System.Data;

namespace CentsTrail.Api.DataAccess
{
  public abstract class BaseRepository
  {
    protected IDbConnection Database;

    protected BaseRepository(IDbConnection database)
    {
      Database = database;
    }
  }
}