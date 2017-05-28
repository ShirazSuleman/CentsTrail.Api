using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Periods;
using CentsTrail.Api.Models.Periods.AddPeriod;
using CentsTrail.Api.Models.Periods.UpdatePeriod;

namespace CentsTrail.Api.DataAccess.Periods
{
  public interface IPeriodsRepository
  {
    Task<long> AddPeriod(string userId, AddPeriodRequest request);

    Task<bool> DeletePeriod(string userId, long periodId);

    Task<IEnumerable<Period>> GetPeriods(string userId);

    Task<Period> GetPeriod(string userId, long periodId);

    Task<bool> UpdatePeriod(string userId, long periodId, UpdatePeriodRequest request);
  }
}
