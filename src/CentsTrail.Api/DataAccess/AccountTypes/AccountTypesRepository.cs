using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CentsTrail.Api.Models.AccountTypes;
using Dapper;

namespace CentsTrail.Api.DataAccess.AccountTypes
{
  public class AccountTypesRepository : BaseRepository, IAccountTypesRepository
  {
    private const string GetAccountTypeStoredProcedure = "dbo.GetAccountType";

    public AccountTypesRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<IEnumerable<AccountType>> GetAccountTypes()
    {
      var result = await Database.QueryAsync<AccountType>(GetAccountTypeStoredProcedure,
        commandType: CommandType.StoredProcedure);
      return result;
    }

    public async Task<AccountType> GetAccountType(int accountTypeId)
    {
      var parameters = new DynamicParameters();
      parameters.Add("@Id", accountTypeId, DbType.Int32, ParameterDirection.Input);

      var result = await Database.QueryAsync<AccountType>(GetAccountTypeStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
      return result.FirstOrDefault();
    }
  }
}