using System.Threading.Tasks;
using System.Web.Http;
using CentsTrail.Api.DataAccess.Periods;
using CentsTrail.Api.Models.Periods.AddPeriod;
using CentsTrail.Api.Models.Periods.UpdatePeriod;
using Microsoft.AspNet.Identity;

namespace CentsTrail.Api.Controllers
{
  [RoutePrefix("Periods")]
  public class PeriodsController : ApiController
  {
    private readonly IPeriodsRepository _repository;

    public PeriodsController(IPeriodsRepository repository)
    {
      _repository = repository;
    }

    // GET: Periods
    [HttpGet]
    [Route("")]
    public async Task<IHttpActionResult> GetPeriodsAsync()
    {
      var result = await _repository.GetPeriods(User.Identity.GetUserId());
      return Ok(result);
    }

    // GET: Periods/5
    [HttpGet]
    [Route("{periodId:long}")]
    public async Task<IHttpActionResult> GetPeriodAsync([FromUri] long periodId)
    {
      var result = await _repository.GetPeriod(User.Identity.GetUserId(), periodId);

      if (result == null)
        return BadRequest();

      return Ok(result);
    }

    // POST: Periods
    [HttpPost]
    [Route("")]
    public async Task<IHttpActionResult> AddPeriodAsync(AddPeriodRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var periodId = await _repository.AddPeriod(User.Identity.GetUserId(), request);

      return Ok(periodId);
    }

    // PATCH: Periods/5
    [HttpPatch]
    [Route("{periodId:long}")]
    public async Task<IHttpActionResult> UpdatePeriodAsync([FromUri] long periodId, UpdatePeriodRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var updateSuccessful = await _repository.UpdatePeriod(User.Identity.GetUserId(), periodId, request);

      return Ok(updateSuccessful);
    }

    // DELETE: Periods/5
    [HttpDelete]
    [Route("{periodId:long}")]
    public async Task<IHttpActionResult> DeletePeriodAsync([FromUri] long periodId)
    {
      var deleteSuccessful = await _repository.DeletePeriod(User.Identity.GetUserId(), periodId);

      return Ok(deleteSuccessful);
    }
  }
}
