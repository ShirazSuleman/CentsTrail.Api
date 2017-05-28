using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Transactions;
using CentsTrail.Api.Models.Transactions.AddTransaction;
using CentsTrail.Api.Models.Transactions.GetTransactionSummary;
using CentsTrail.Api.Models.Transactions.SearchTransactions;
using CentsTrail.Api.Models.Transactions.UpdateTransaction;
using Dapper;

namespace CentsTrail.Api.DataAccess.Transactions
{
  public class TransactionsRepository : BaseRepository, ITransactionsRepository
  {
    private const string AddTransactionStoredProcedure = "dbo.AddTransaction";
    private const string UpdateTransactionStoredProcedure = "dbo.UpdateTransaction";
    private const string DeleteTransactionStoredProcedure = "dbo.DeleteTransaction";
    private const string GetTransactionStoredProcedure = "dbo.GetTransaction";
    private const string GetTransactionSummaryStoredProcedure = "dbo.GetTransactionSummary";

    public TransactionsRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<long> AddTransaction(string userId, AddTransactionRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Description", request.Description, DbType.String, ParameterDirection.Input);
      parameters.Add("@Amount", request.Amount, DbType.Decimal, ParameterDirection.Input);
      parameters.Add("@AccountId", request.AccountId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@CategoryId", request.CategoryId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@PeriodId", request.PeriodId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@TransactionDate", request.TransactionDate, DbType.DateTime, ParameterDirection.Input);

      parameters.Add("@Id", dbType: DbType.Int64, direction: ParameterDirection.Output);

      await Database.ExecuteAsync(AddTransactionStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return parameters.Get<long>("@Id");
    }

    public async Task<bool> DeleteTransaction(string userId, long transactionId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@Id", transactionId, DbType.Int64, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(DeleteTransactionStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }

    public async Task<IEnumerable<Transaction>> SearchTransactions(string userId,
      SearchTransactionsRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@StartDate", request.StartDate, DbType.DateTime, ParameterDirection.Input);
      parameters.Add("@EndDate", request.EndDate, DbType.DateTime, ParameterDirection.Input);
      parameters.Add("@AccountId", request.AccountId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@CategoryId", request.CategoryId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@CategoryTypeId", request.CategoryTypeId, DbType.Int32, ParameterDirection.Input);
      parameters.Add("@PeriodId", request.PeriodId, DbType.Int64, ParameterDirection.Input);

      return await Database.QueryAsync<Transaction>(GetTransactionStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<TransactionSummary>> GetTransactionSummary(string userId,
      GetTransactionSummaryRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@StartDate", request.StartDate, DbType.DateTime, ParameterDirection.Input);
      parameters.Add("@EndDate", request.EndDate, DbType.DateTime, ParameterDirection.Input);
      parameters.Add("@AccountId", request.AccountId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@PeriodId", request.PeriodId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@PartitionByCategory", request.PartitionByCategory, DbType.Boolean, ParameterDirection.Input);

      return await Database.QueryAsync<TransactionSummary>(GetTransactionSummaryStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<Transaction> GetTransaction(string userId, long transactionId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@Id", transactionId, DbType.Int64, ParameterDirection.Input);

      return await Database.QueryFirstOrDefaultAsync<Transaction>(GetTransactionStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateTransaction(string userId, long transactionId,
      UpdateTransactionRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Id", transactionId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@Description", request.Description, DbType.String, ParameterDirection.Input);
      parameters.Add("@Amount", request.Amount, DbType.Decimal, ParameterDirection.Input);
      parameters.Add("@AccountId", request.AccountId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@CategoryId", request.CategoryId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@PeriodId", request.PeriodId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@TransactionDate", request.TransactionDate, DbType.DateTime, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(UpdateTransactionStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }
  }
}