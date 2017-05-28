using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.CategoryTypes;

namespace CentsTrail.Api.DataAccess.CategoryTypes
{
  public interface ICategoryTypesRepository
  {
    Task<IEnumerable<CategoryType>> GetCategoryTypes();

    Task<CategoryType> GetCategoryType(int categoryTypeId);
  }
}