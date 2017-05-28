using System.Threading.Tasks;
using System.Web.Http;
using CentsTrail.Api.DataAccess.CategoryTypes;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("CategoryTypes")]
  public class CategoryTypesController : ApiController
  {
    private readonly ICategoryTypesRepository _repository;

    public CategoryTypesController(ICategoryTypesRepository repository)
    {
      _repository = repository;
    }

    // GET: CategoryTypes
    [HttpGet]
    [Route("")]
    public async Task<IHttpActionResult> GetCategoryTypesAsync()
    {
      var result = await _repository.GetCategoryTypes();
      return Ok(result);
    }

    // GET: CategoryTypes/5
    [HttpGet]
    [Route("{categoryTypeId:int}")]
    public async Task<IHttpActionResult> GetCategoryTypeAsync([FromUri] int categoryTypeId)
    {
      var result = await _repository.GetCategoryType(categoryTypeId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }
  }
}