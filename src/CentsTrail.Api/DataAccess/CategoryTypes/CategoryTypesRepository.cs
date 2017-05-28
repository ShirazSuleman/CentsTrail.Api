using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CentsTrail.Api.Models.CategoryTypes;
using Dapper;

namespace CentsTrail.Api.DataAccess.CategoryTypes
{
  public class CategoryTypesRepository : BaseRepository, ICategoryTypesRepository
  {
    private const string GetCategoryTypeStoredProcedure = "dbo.GetCategoryType";

    public CategoryTypesRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<CategoryType> GetCategoryType(int categoryTypeId)
    {
      var parameters = new DynamicParameters();
      parameters.Add("@Id", categoryTypeId, DbType.Int32, ParameterDirection.Input);

      var result = await Database.QueryAsync<CategoryType>(GetCategoryTypeStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
      return result.FirstOrDefault();
    }

    public async Task<IEnumerable<CategoryType>> GetCategoryTypes()
    {
      var result = await Database.QueryAsync<CategoryType>(GetCategoryTypeStoredProcedure,
        commandType: CommandType.StoredProcedure);
      return result;
    }
  }
}