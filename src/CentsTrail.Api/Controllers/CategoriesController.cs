using System.Threading.Tasks;
using System.Web.Http;
using CentsTrail.Api.DataAccess.Categories;
using CentsTrail.Api.Models.Categories.AddCategory;
using CentsTrail.Api.Models.Categories.UpdateCategory;
using Microsoft.AspNet.Identity;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("Categories")]
  public class CategoriesController : ApiController
  {
    private readonly ICategoriesRepository _repository;

    public CategoriesController(ICategoriesRepository repository)
    {
      _repository = repository;
    }

    // GET: Categories
    [HttpGet]
    [Route("")]
    public async Task<IHttpActionResult> GetCategoriesAsync()
    {
      var result = await _repository.GetCategories(User.Identity.GetUserId());
      return Ok(result);
    }

    // GET: Categories/5
    [HttpGet]
    [Route("{categoryId:long}")]
    public async Task<IHttpActionResult> GetCategoryAsync([FromUri] long categoryId)
    {
      var result = await _repository.GetCategory(User.Identity.GetUserId(), categoryId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }

    // POST: Categories
    [HttpPost]
    [Route("")]
    public async Task<IHttpActionResult> AddCategoryAsync(AddCategoryRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var categoryId = await _repository.AddCategory(User.Identity.GetUserId(), request);

      return Ok(categoryId);
    }

    // PATCH: Categories/5
    [HttpPatch]
    [Route("{categoryId:long}")]
    public async Task<IHttpActionResult> UpdateCategoryAsync([FromUri] long categoryId, UpdateCategoryRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var updateSuccessful = await _repository.UpdateCategory(User.Identity.GetUserId(), categoryId, request);

      return Ok(updateSuccessful);
    }

    // DELETE: Categories/5
    [HttpDelete]
    [Route("{categoryId:long}")]
    public async Task<IHttpActionResult> DeleteCategoryAsync([FromUri] long categoryId)
    {
      var deleteSuccessful = await _repository.DeleteCategory(User.Identity.GetUserId(), categoryId);

      return Ok(deleteSuccessful);
    }
  }
}