using CentsTrail.Api.DataAccess.UserCategories;
using CentsTrail.Api.Models.UserCategories.AddUserCategory;
using CentsTrail.Api.Models.UserCategories.UpdateUserCategory;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("UserCategories")]
  public class UserCategoriesController : ApiController
  {
    private IUserCategoriesRepository _repository;

    public UserCategoriesController(IUserCategoriesRepository repository)
    {
      _repository = repository;
    }

    // GET: UserCategories
    [HttpGet]
    [Route("")]
    public async Task<IHttpActionResult> GetUserCategoriesAsync()
    {
      var result = await _repository.GetUserCategories(User.Identity.GetUserId());
      return Ok(result);
    }

    // GET: UserCategories/5
    [HttpGet]
    [Route("{userCategoryId:long}")]
    public async Task<IHttpActionResult> GetUserCategoryAsync([FromUri]long userCategoryId)
    {
      var result = await _repository.GetUserCategory(User.Identity.GetUserId(), userCategoryId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }

    // POST: UserCategories
    [HttpPost]
    [Route("")]
    public async Task<IHttpActionResult> AddUserCategoryAsync(AddUserCategoryRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var userCategoryId = await _repository.AddUserCategory(User.Identity.GetUserId(), request);

      return Ok(userCategoryId);
    }

    // PATCH: UserCategories/5
    [HttpPatch]
    [Route("{userCategoryId:long}")]
    public async Task<IHttpActionResult> UpdateUserCategoryAsync([FromUri]long userCategoryId, UpdateUserCategoryRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var updateSuccessful = await _repository.UpdateUserCategory(User.Identity.GetUserId(), userCategoryId, request);

      return Ok(updateSuccessful);
    }

    // DELETE: UserCategories/5
    [HttpDelete]
    [Route("{userCategoryId:long}")]
    public async Task<IHttpActionResult> DeleteUserCategoryAsync([FromUri]long userCategoryId)
    {
      var deleteSuccessful = await _repository.DeleteUserCategory(User.Identity.GetUserId(), userCategoryId);

      return Ok(deleteSuccessful);
    }
  }
}
