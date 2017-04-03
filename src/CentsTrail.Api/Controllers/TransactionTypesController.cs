using CentsTrail.Api.DataAccess.TransactionTypes;
using System.Threading.Tasks;
using System.Web.Http;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("TransactionTypes")]
  public class TransactionTypesController : ApiController
  {
    private ITransactionTypesRepository _repository;

    public TransactionTypesController(ITransactionTypesRepository repository)
    {
      _repository = repository;
    }

    // GET: TransactionTypes
    [HttpGet]
    [Route("")]
    public async Task<IHttpActionResult> GetTransactionTypesAsync()
    {
      var result = await _repository.GetTransactionTypes();
      return Ok(result);
    }

    // GET: TransactionTypes/5
    [HttpGet]
    [Route("{transactionTypeId:int}")]
    public async Task<IHttpActionResult> GetTransactionTypeAsync([FromUri]int transactionTypeId)
    {
      var result = await _repository.GetTransactionType(transactionTypeId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }
  }
}
