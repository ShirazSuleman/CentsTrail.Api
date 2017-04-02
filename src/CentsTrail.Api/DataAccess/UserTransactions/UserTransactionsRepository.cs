using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using CentsTrail.Api.Models.UserTransactions.AddUserTransaction;
using CentsTrail.Api.Models.UserTransactions;
using CentsTrail.Api.Models.UserTransactions.UpdateUserTransaction;
using CentsTrail.Api.Models.UserTransactions.GetUserTransactionSummary;
using CentsTrail.Api.Models.UserTransactions.SearchUserTransactions;

namespace CentsTrail.Api.DataAccess.UserTransactions
{
  public class UserTransactionsRepository : BaseRepository, IUserTransactionsRepository
  {
    private const string AddUserTransactionStoredProcedure = "dbo.AddUserTransaction";
    private const string UpdateUserTransactionStoredProcedure = "dbo.UpdateUserTransaction";
    private const string DeleteUserTransactionStoredProcedure = "dbo.DeleteUserTransaction";
    private const string GetUserTransactionStoredProcedure = "dbo.GetUserTransaction";
    private const string GetUserTransactionSummaryStoredProcedure = "dbo.GetUserTransactionSummary";

    public UserTransactionsRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<long> AddUserTransaction(string userId, AddUserTransactionRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, dbType: DbType.String, direction: ParameterDirection.Input);

      parameters.Add("@Description", request.Description, dbType: DbType.String, direction: ParameterDirection.Input);
      parameters.Add("@Amount", request.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
      parameters.Add("@UserCategoryID", request.UserCategoryId, dbType: DbType.Int64, direction: ParameterDirection.Input);
      parameters.Add("@TransactionDate", request.TransactionDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

      parameters.Add("@UserTransactionID", dbType: DbType.Int64, direction: ParameterDirection.Output);

      await Database.ExecuteAsync(AddUserTransactionStoredProcedure, parameters, commandType: CommandType.StoredProcedure);

      return parameters.Get<long>("@UserTransactionID");
    }

    public async Task<bool> DeleteUserTransaction(string userId, long userTransactionId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, dbType: DbType.String, direction: ParameterDirection.Input);
      parameters.Add("@UserTransactionID", userTransactionId, dbType: DbType.Int64, direction: ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(DeleteUserTransactionStoredProcedure, parameters, commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }

    public async Task<IEnumerable<UserTransaction>> SearchUserTransactions(string userId, SearchUserTransactionsRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, dbType: DbType.String, direction: ParameterDirection.Input);
      parameters.Add("@StartDate", request.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
      parameters.Add("@EndDate", request.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
      parameters.Add("@UserCategoryID", request.UserCategoryId, dbType: DbType.Int64, direction: ParameterDirection.Input);
      parameters.Add("@TransactionTypeID", request.TransactionTypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);

      return await Database.QueryAsync<UserTransaction>(GetUserTransactionStoredProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<UserTransactionSummary>> GetUserTransactionSummary(string userId, GetUserTransactionSummaryRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, dbType: DbType.String, direction: ParameterDirection.Input);
      parameters.Add("@StartDate", request.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
      parameters.Add("@EndDate", request.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
      parameters.Add("@PartitionByCategory", request.PartitionByCategory, dbType: DbType.Boolean, direction: ParameterDirection.Input);

      return await Database.QueryAsync<UserTransactionSummary>(GetUserTransactionSummaryStoredProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<UserTransaction> GetUserTransaction(string userId, long userTransactionId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, dbType: DbType.String, direction: ParameterDirection.Input);
      parameters.Add("@UserTransactionID", userTransactionId, dbType: DbType.Int64, direction: ParameterDirection.Input);

      return await Database.QueryFirstOrDefaultAsync<UserTransaction>(GetUserTransactionStoredProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateUserTransaction(string userId, long userTransactionId, UpdateUserTransactionRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserID", userId, dbType: DbType.String, direction: ParameterDirection.Input);

      parameters.Add("@UserTransactionID", userTransactionId, dbType: DbType.Int64, direction: ParameterDirection.Input);
      parameters.Add("@Description", request.Description, dbType: DbType.String, direction: ParameterDirection.Input);
      parameters.Add("@Amount", request.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
      parameters.Add("@UserCategoryID", request.UserCategoryId, dbType: DbType.Int64, direction: ParameterDirection.Input);
      parameters.Add("@TransactionDate", request.TransactionDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(UpdateUserTransactionStoredProcedure, parameters, commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }
  }
}