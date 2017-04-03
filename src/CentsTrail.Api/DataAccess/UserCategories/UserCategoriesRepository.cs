using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CentsTrail.Api.Models.UserCategories;
using CentsTrail.Api.Models.UserCategories.AddUserCategory;
using CentsTrail.Api.Models.UserCategories.UpdateUserCategory;
using Dapper;

namespace CentsTrail.Api.DataAccess.UserCategories
{
  public class UserCategoriesRepository : BaseRepository, IUserCategoriesRepository
  {
    private const string AddUserCategoryStoredProcedure = "dbo.AddUserCategory";
    private const string UpdateUserCategoryStoredProcedure = "dbo.UpdateUserCategory";
    private const string DeleteUserCategoryStoredProcedure = "dbo.DeleteUserCategory";
    private const string GetUserCategoryStoredProcedure = "dbo.GetUserCategory";

    public UserCategoriesRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<long> AddUserCategory(string userId, AddUserCategoryRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Name", request.Name, DbType.String, ParameterDirection.Input);
      parameters.Add("@Limit", request.Limit, DbType.Decimal, ParameterDirection.Input);
      parameters.Add("@TransactionTypeID", request.TransactionTypeId, DbType.Int32, ParameterDirection.Input);

      parameters.Add("@UserCategoryID", dbType: DbType.Int64, direction: ParameterDirection.Output);

      await Database.ExecuteAsync(AddUserCategoryStoredProcedure, parameters, commandType: CommandType.StoredProcedure);

      return parameters.Get<long>("@UserCategoryID");
    }

    public async Task<bool> DeleteUserCategory(string userId, long userCategoryId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@UserCategoryID", userCategoryId, DbType.Int64, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(DeleteUserCategoryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }

    public async Task<IEnumerable<UserCategory>> GetUserCategories(string userId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, DbType.String, ParameterDirection.Input);

      return await Database.QueryAsync<UserCategory>(GetUserCategoryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<UserCategory> GetUserCategory(string userId, long userCategoryId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@UserCategoryID", userCategoryId, DbType.Int64, ParameterDirection.Input);

      return await Database.QueryFirstOrDefaultAsync<UserCategory>(GetUserCategoryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateUserCategory(string userId, long userCategoryId, UpdateUserCategoryRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@UserCategoryID", userCategoryId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@Name", request.Name, DbType.String, ParameterDirection.Input);
      parameters.Add("@Limit", request.Limit, DbType.Decimal, ParameterDirection.Input);
      parameters.Add("@TransactionTypeID", request.TransactionTypeId, DbType.Int32, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(UpdateUserCategoryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }
  }
}