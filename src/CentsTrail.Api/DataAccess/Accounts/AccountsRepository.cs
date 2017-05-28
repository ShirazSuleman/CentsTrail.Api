using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Accounts;
using CentsTrail.Api.Models.Accounts.AddAccount;
using CentsTrail.Api.Models.Accounts.UpdateAccount;
using Dapper;

namespace CentsTrail.Api.DataAccess.Accounts
{
  public class AccountsRepository : BaseRepository, IAccountsRepository
  {
    private const string AddAccountStoredProcedure = "dbo.AddAccount";
    private const string UpdateAccountStoredProcedure = "dbo.UpdateAccount";
    private const string DeleteAccountStoredProcedure = "dbo.DeleteAccount";
    private const string GetAccountStoredProcedure = "dbo.GetAccount";

    public AccountsRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<long> AddAccount(string userId, AddAccountRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Name", request.Name, DbType.String, ParameterDirection.Input);
      parameters.Add("@AccountTypeId", request.AccountTypeId, DbType.Int32, ParameterDirection.Input);

      parameters.Add("@Id", dbType: DbType.Int64, direction: ParameterDirection.Output);

      await Database.ExecuteAsync(AddAccountStoredProcedure, parameters, commandType: CommandType.StoredProcedure);

      return parameters.Get<long>("@Id");
    }

    public async Task<bool> DeleteAccount(string userId, long accountId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@Id", accountId, DbType.Int64, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(DeleteAccountStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }

    public async Task<IEnumerable<Account>> GetAccounts(string userId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      return await Database.QueryAsync<Account>(GetAccountStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<Account> GetAccount(string userId, long accountId)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);
      parameters.Add("@Id", accountId, DbType.Int64, ParameterDirection.Input);

      return await Database.QueryFirstOrDefaultAsync<Account>(GetAccountStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateAccount(string userId, long accountId, UpdateAccountRequest request)
    {
      var parameters = new DynamicParameters();

      parameters.Add("@UserId", userId, DbType.String, ParameterDirection.Input);

      parameters.Add("@Id", accountId, DbType.Int64, ParameterDirection.Input);
      parameters.Add("@Name", request.Name, DbType.String, ParameterDirection.Input);
      parameters.Add("@AccountTypeId", request.AccountTypeId, DbType.Int32, ParameterDirection.Input);

      var rowsAffected = await Database.ExecuteAsync(UpdateAccountStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);

      return rowsAffected == 1;
    }
  }
}