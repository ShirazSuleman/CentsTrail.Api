using System.Threading.Tasks;
using System.Web.Http;
using CentsTrail.Api.DataAccess.Currencies;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("Currencies")]
  public class CurrenciesController : ApiController
  {
    private readonly ICurrenciesRepository _repository;

    public CurrenciesController(ICurrenciesRepository repository)
    {
      _repository = repository;
    }

    // GET: Currencies
    [HttpGet]
    [Route("")]
    public async Task<IHttpActionResult> GetCurrenciesAsync()
    {
      var result = await _repository.GetCurrencies();
      return Ok(result);
    }

    // GET: Currencies/5
    [HttpGet]
    [Route("{currencyId:int}")]
    public async Task<IHttpActionResult> GetCurrencyAsync([FromUri] int currencyId)
    {
      var result = await _repository.GetCurrency(currencyId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }
  }
}