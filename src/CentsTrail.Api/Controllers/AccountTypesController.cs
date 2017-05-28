using System.Threading.Tasks;
using System.Web.Http;
using CentsTrail.Api.DataAccess.AccountTypes;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("AccountTypes")]
  public class AccountTypesController : ApiController
  {
    private readonly IAccountTypesRepository _repository;

    public AccountTypesController(IAccountTypesRepository repository)
    {
      _repository = repository;
    }

    // GET: AccountTypes
    [HttpGet]
    [Route("")]
    public async Task<IHttpActionResult> GetAccountTypesAsync()
    {
      var result = await _repository.GetAccountTypes();
      return Ok(result);
    }

    // GET: AccountTypes/5
    [HttpGet]
    [Route("{accountTypeId:int}")]
    public async Task<IHttpActionResult> GetAccountTypeAsync([FromUri] int accountTypeId)
    {
      var result = await _repository.GetAccountType(accountTypeId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }
  }
}