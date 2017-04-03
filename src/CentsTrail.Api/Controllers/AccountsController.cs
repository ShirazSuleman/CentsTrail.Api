using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CentsTrail.Api.Models;
using CentsTrail.Api.Models.Accounts.ChangePassword;
using CentsTrail.Api.Models.Accounts.Register;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CentsTrail.Api.Controllers
{
  [ApiExplorerSettings(IgnoreApi = true)]
  [RoutePrefix("Accounts")]
  public class AccountsController : ApiController
  {
    private ApplicationUserManager _userManager;

    public AccountsController()
    {
    }

    public AccountsController(ApplicationUserManager userManager,
      ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
    {
      UserManager = userManager;
      AccessTokenFormat = accessTokenFormat;
    }

    public ApplicationUserManager UserManager
    {
      get { return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
      private set { _userManager = value; }
    }

    public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

    // POST Accounts/ChangePassword
    [Route("ChangePassword")]
    [HttpPost]
    public async Task<IHttpActionResult> ChangePassword(ChangePasswordRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), request.OldPassword,
        request.NewPassword);

      if (!result.Succeeded)
        return GetErrorResult(result);

      return Ok();
    }

    // POST Accounts/Register
    [AllowAnonymous]
    [Route("Register")]
    [HttpPost]
    public async Task<IHttpActionResult> Register(RegisterRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var user = new ApplicationUser {UserName = request.Email, Email = request.Email};

      var result = await UserManager.CreateAsync(user, request.Password);

      if (!result.Succeeded)
        return GetErrorResult(result);

      return Ok();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && _userManager != null)
      {
        _userManager.Dispose();
        _userManager = null;
      }

      base.Dispose(disposing);
    }

    #region Helpers

    private IHttpActionResult GetErrorResult(IdentityResult result)
    {
      if (result == null)
        return InternalServerError();

      if (!result.Succeeded)
      {
        if (result.Errors != null)
          foreach (var error in result.Errors)
            ModelState.AddModelError("", error);

        if (ModelState.IsValid)
          return BadRequest();

        return BadRequest(ModelState);
      }

      return null;
    }

    #endregion
  }
}