using System.Threading.Tasks;
using System.Web.Http;
using CentsTrail.Api.DataAccess.Accounts;
using CentsTrail.Api.Models.Accounts.AddAccount;
using CentsTrail.Api.Models.Accounts.UpdateAccount;
using Microsoft.AspNet.Identity;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("Accounts")]
  public class AccountsController : ApiController
  {
    private readonly IAccountsRepository _repository;

    public AccountsController(IAccountsRepository repository)
    {
      _repository = repository;
    }

    // GET: Accounts
    [HttpGet]
    [Route("")]
    public async Task<IHttpActionResult> GetAccountsAsync()
    {
      var result = await _repository.GetAccounts(User.Identity.GetUserId());
      return Ok(result);
    }

    // GET: Accounts/5
    [HttpGet]
    [Route("{accountId:long}")]
    public async Task<IHttpActionResult> GetAccountAsync([FromUri] long accountId)
    {
      var result = await _repository.GetAccount(User.Identity.GetUserId(), accountId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }

    // POST: Accounts
    [HttpPost]
    [Route("")]
    public async Task<IHttpActionResult> AddAccountAsync(AddAccountRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var accountId = await _repository.AddAccount(User.Identity.GetUserId(), request);

      return Ok(accountId);
    }

    // PATCH: Accounts/5
    [HttpPatch]
    [Route("{accountId:long}")]
    public async Task<IHttpActionResult> UpdateAccountAsync([FromUri] long accountId, UpdateAccountRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var updateSuccessful = await _repository.UpdateAccount(User.Identity.GetUserId(), accountId, request);

      return Ok(updateSuccessful);
    }

    // DELETE: Accounts/5
    [HttpDelete]
    [Route("{accountId:long}")]
    public async Task<IHttpActionResult> DeleteAccountAsync([FromUri] long accountId)
    {
      var deleteSuccessful = await _repository.DeleteAccount(User.Identity.GetUserId(), accountId);

      return Ok(deleteSuccessful);
    }
  }
}
