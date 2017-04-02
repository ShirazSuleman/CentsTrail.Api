using CentsTrail.Api.Models.Currencies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentsTrail.Api.DataAccess.Currencies
{
  public interface ICurrenciesRepository
  {
    Task<IEnumerable<Currency>> GetCurrencies();

    Task<Currency> GetCurrency(int currencyId);
  }
}