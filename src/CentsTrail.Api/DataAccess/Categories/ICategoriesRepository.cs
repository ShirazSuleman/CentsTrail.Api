using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Categories;
using CentsTrail.Api.Models.Categories.AddCategory;
using CentsTrail.Api.Models.Categories.UpdateCategory;

namespace CentsTrail.Api.DataAccess.Categories
{
  public interface ICategoriesRepository
  {
    Task<long> AddCategory(string userId, AddCategoryRequest request);

    Task<bool> DeleteCategory(string userId, long categoryId);

    Task<IEnumerable<Category>> GetCategories(string userId);

    Task<Category> GetCategory(string userId, long categoryId);

    Task<bool> UpdateCategory(string userId, long categoryId, UpdateCategoryRequest request);
  }
}