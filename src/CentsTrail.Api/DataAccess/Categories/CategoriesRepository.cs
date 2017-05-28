using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Categories;
using CentsTrail.Api.Models.Categories.AddCategory;
using CentsTrail.Api.Models.Categories.UpdateCategory;
using Dapper;

namespace CentsTrail.Api.DataAccess.Categories
{
  public class CategoriesRepository : BaseRepository, ICategoriesRepository
  {
    private const string AddCategoryStoredProcedure = "dbo.AddCategory";
    private const string UpdateCategoryStoredProcedure = "dbo.UpdateCategory";
    private const string DeleteCategoryStoredProcedure = "dbo.DeleteCategory";
    private const string GetCategoryStoredProcedure = "dbo.GetCategory";

    public CategoriesRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<long> AddCategory(string userId, AddCategoryRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Name", request.Name, DbType.String, ParameterDirection.Input);
      parameters.Add("@Limit", request.Limit, DbType.Decimal, ParameterDirection.Input);
      parameters.Add("@CategoryTypeId", request.CategoryTypeId, DbType.Int32, ParameterDirection.Input);

      parameters.Add("@Id", dbType: DbType.Int64, direction: ParameterDirection.Output);

      await Database.ExecuteAsync(AddCategoryStoredProcedure, parameters, commandType: CommandType.StoredProcedure);

      return parameters.Get<long>("@Id");
    }

    public async Task<bool> DeleteCategory(string userId, long categoryId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@Id", categoryId, DbType.Int64, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(DeleteCategoryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }

    public async Task<IEnumerable<Category>> GetCategories(string userId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      return await Database.QueryAsync<Category>(GetCategoryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<Category> GetCategory(string userId, long categoryId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@Id", categoryId, DbType.Int64, ParameterDirection.Input);

      return await Database.QueryFirstOrDefaultAsync<Category>(GetCategoryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateCategory(string userId, long categoryId, UpdateCategoryRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Id", categoryId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@Name", request.Name, DbType.String, ParameterDirection.Input);
      parameters.Add("@Limit", request.Limit, DbType.Decimal, ParameterDirection.Input);
      parameters.Add("@CategoryTypeId", request.CategoryTypeId, DbType.Int32, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(UpdateCategoryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }
  }
}