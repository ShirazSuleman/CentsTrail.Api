using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Currencies;
using Dapper;

namespace CentsTrail.Api.DataAccess.Currencies
{
  public class CurrenciesRepository : BaseRepository, ICurrenciesRepository
  {
    private const string GetCurrencyStoredProcedure = "dbo.GetCurrency";

    public CurrenciesRepository(IDbConnection database) : base(database)
    {
    }

    public async Task<IEnumerable<Currency>> GetCurrencies()
    {
      var result = await Database.QueryAsync<Currency>(GetCurrencyStoredProcedure,
        commandType: CommandType.StoredProcedure);
      return result;
    }

    public async Task<Currency> GetCurrency(int currencyId)
    {
      var parameters = new DynamicParameters();
      parameters.Add("@CurrencyID", currencyId, DbType.Int32, ParameterDirection.Input);

      var result = await Database.QueryAsync<Currency>(GetCurrencyStoredProcedure, parameters,
        commandType: CommandType.StoredProcedure);
      return result.FirstOrDefault();
    }
  }
}