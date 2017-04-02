using CentsTrail.Api.DataAccess.UserTransactions;
using CentsTrail.Api.Models.UserTransactions.AddUserTransaction;
using CentsTrail.Api.Models.UserTransactions.GetUserTransactionSummary;
using CentsTrail.Api.Models.UserTransactions.SearchUserTransactions;
using CentsTrail.Api.Models.UserTransactions.UpdateUserTransaction;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("api/UserTransactions")]

  public class UserTransactionsController : ApiController
  {
    private IUserTransactionsRepository _repository;

    public UserTransactionsController(IUserTransactionsRepository repository)
    {
      _repository = repository;
    }

    // POST: api/UserTransactions/search
    [HttpPost]
    [Route("search")]
    public async Task<IHttpActionResult> SearchUserTransactionsAsync(SearchUserTransactionsRequest request)
    {
      var result = await _repository.SearchUserTransactions(User.Identity.GetUserId(), request);
      return Ok(result);
    }

    // POST: api/UserTransactions/summary
    [HttpPost]
    [Route("summary")]
    public async Task<IHttpActionResult> GetUserTransactionSummaryAsync(GetUserTransactionSummaryRequest request)
    {
      var result = await _repository.GetUserTransactionSummary(User.Identity.GetUserId(), request);
      return Ok(result);
    }

    // GET: api/UserTransactions/5
    [HttpGet]
    [Route("{userTransactionId:long}")]
    public async Task<IHttpActionResult> GetUserTransactionAsync([FromUri]long userTransactionId)
    {
      var result = await _repository.GetUserTransaction(User.Identity.GetUserId(), userTransactionId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }

    // POST: api/UserTransactions
    [HttpPost]
    [Route("")]
    public async Task<IHttpActionResult> AddUserTransactionAsync(AddUserTransactionRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var userTransactionId = await _repository.AddUserTransaction(User.Identity.GetUserId(), request);

      return Ok(userTransactionId);
    }

    // PATCH: api/UserTransactions/5
    [HttpPatch]
    [Route("{userTransactionId:long}")]
    public async Task<IHttpActionResult> UpdateUserTransactionAsync([FromUri]long userTransactionId, UpdateUserTransactionRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var updateSuccessful = await _repository.UpdateUserTransaction(User.Identity.GetUserId(), userTransactionId, request);

      return Ok(updateSuccessful);
    }

    // DELETE: api/UserTransactions/5
    [HttpDelete]
    [Route("{userTransactionId:long}")]
    public async Task<IHttpActionResult> DeleteUserTransactionAsync([FromUri]long userTransactionId)
    {
      var deleteSuccessful = await _repository.DeleteUserTransaction(User.Identity.GetUserId(), userTransactionId);

      return Ok(deleteSuccessful);
    }
  }
}
