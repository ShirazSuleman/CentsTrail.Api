using System.Threading.Tasks;
using System.Web.Http;
using CentsTrail.Api.DataAccess.Transactions;
using CentsTrail.Api.Models.Transactions.AddTransaction;
using CentsTrail.Api.Models.Transactions.GetTransactionSummary;
using CentsTrail.Api.Models.Transactions.SearchTransactions;
using CentsTrail.Api.Models.Transactions.UpdateTransaction;
using Microsoft.AspNet.Identity;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("Transactions")]
  public class TransactionsController : ApiController
  {
    private readonly ITransactionsRepository _repository;

    public TransactionsController(ITransactionsRepository repository)
    {
      _repository = repository;
    }

    // POST: Transactions/search
    [HttpPost]
    [Route("search")]
    public async Task<IHttpActionResult> SearchTransactionsAsync(SearchTransactionsRequest request)
    {
      var result = await _repository.SearchTransactions(User.Identity.GetUserId(), request);
      return Ok(result);
    }

    // POST: Transactions/summary
    [HttpPost]
    [Route("summary")]
    public async Task<IHttpActionResult> GetTransactionSummaryAsync(GetTransactionSummaryRequest request)
    {
      var result = await _repository.GetTransactionSummary(User.Identity.GetUserId(), request);
      return Ok(result);
    }

    // GET: Transactions/5
    [HttpGet]
    [Route("{transactionId:long}")]
    public async Task<IHttpActionResult> GetTransactionAsync([FromUri] long transactionId)
    {
      var result = await _repository.GetTransaction(User.Identity.GetUserId(), transactionId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }

    // POST: Transactions
    [HttpPost]
    [Route("")]
    public async Task<IHttpActionResult> AddTransactionAsync(AddTransactionRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var transactionId = await _repository.AddTransaction(User.Identity.GetUserId(), request);

      return Ok(transactionId);
    }

    // PATCH: Transactions/5
    [HttpPatch]
    [Route("{transactionId:long}")]
    public async Task<IHttpActionResult> UpdateTransactionAsync([FromUri] long transactionId,
      UpdateTransactionRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var updateSuccessful = await _repository.UpdateTransaction(User.Identity.GetUserId(), transactionId,
        request);

      return Ok(updateSuccessful);
    }

    // DELETE: Transactions/5
    [HttpDelete]
    [Route("{transactionId:long}")]
    public async Task<IHttpActionResult> DeleteTransactionAsync([FromUri] long transactionId)
    {
      var deleteSuccessful = await _repository.DeleteTransaction(User.Identity.GetUserId(), transactionId);

      return Ok(deleteSuccessful);
    }
  }
}