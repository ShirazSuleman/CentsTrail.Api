using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using CentsTrail.Api.TransactionTypes.Models;

namespace CentsTrail.Api.DataAccess.TransactionTypes
{
  public class TransactionTypesRepository : BaseRepository, ITransactionTypesRepository
  {
    private const string GetTransactionTypeStoredProcedure = "dbo.GetTransactionType";

    public TransactionTypesRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<TransactionType> GetTransactionType(int transactionTypeId)
    {
      var parameters = new DynamicParameters();
      parameters.Add("@TransactionTypeID", transactionTypeId, dbType: DbType.Int32, direction: ParameterDirection.Input);

      var result = await Database.QueryAsync<TransactionType>(GetTransactionTypeStoredProcedure, parameters, commandType: CommandType.StoredProcedure);
      return result.FirstOrDefault();
    }

    public async Task<IEnumerable<TransactionType>> GetTransactionTypes()
    {
      var result = await Database.QueryAsync<TransactionType>(GetTransactionTypeStoredProcedure, commandType: CommandType.StoredProcedure);
      return result;
    }
  }
}