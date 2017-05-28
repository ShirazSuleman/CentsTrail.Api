using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.Categories.UpdateCategory
{
  public class UpdateCategoryRequest
  {
    [Display(Name = "Category name")]
    public string Name { get; set; }

    public decimal? Limit { get; set; }

    [Display(Name = "Category Type Identifier")]
    public int? CategoryTypeId { get; set; }
  }
}