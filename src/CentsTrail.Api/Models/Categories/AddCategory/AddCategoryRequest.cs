using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.Categories.AddCategory
{
  public class AddCategoryRequest
  {
    [Required(ErrorMessage = "A Category name is required")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
    [Display(Name = "Category name")]
    public string Name { get; set; }

    public decimal? Limit { get; set; }

    [Required(ErrorMessage = "A Category type is required")]
    [Display(Name = "Category Type Identifier")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public int CategoryTypeId { get; set; }
  }
}