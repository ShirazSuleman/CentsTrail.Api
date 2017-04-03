using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Currencies;

namespace CentsTrail.Api.DataAccess.Currencies
{
  public interface ICurrenciesRepository
  {
    Task<IEnumerable<Currency>> GetCurrencies();

    Task<Currency> GetCurrency(int currencyId);
  }
}