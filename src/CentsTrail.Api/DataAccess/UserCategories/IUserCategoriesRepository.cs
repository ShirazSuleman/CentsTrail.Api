using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.UserCategories;
using CentsTrail.Api.Models.UserCategories.AddUserCategory;
using CentsTrail.Api.Models.UserCategories.UpdateUserCategory;

namespace CentsTrail.Api.DataAccess.UserCategories
{
  public interface IUserCategoriesRepository
  {
    Task<long> AddUserCategory(string userId, AddUserCategoryRequest request);

    Task<bool> DeleteUserCategory(string userId, long userCategoryId);

    Task<IEnumerable<UserCategory>> GetUserCategories(string userId);

    Task<UserCategory> GetUserCategory(string userId, long userCategoryId);

    Task<bool> UpdateUserCategory(string userId, long userCategoryId, UpdateUserCategoryRequest request);
  }
}