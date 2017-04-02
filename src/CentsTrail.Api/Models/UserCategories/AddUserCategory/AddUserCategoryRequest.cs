using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.UserCategories.AddUserCategory
{
  public class AddUserCategoryRequest
  {
    [Required(ErrorMessage = "A Category name is required")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
    [Display(Name = "Category name")]
    public string Name { get; set; }

    public decimal? Limit { get; set; }

    [Required(ErrorMessage = "A Transaction type is required")]
    [Display(Name = "Transaction Type Identifier")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public int TransactionTypeId { get; set; }
  }
}