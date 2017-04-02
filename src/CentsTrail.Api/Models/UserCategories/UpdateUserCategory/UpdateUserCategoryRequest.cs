using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.UserCategories.UpdateUserCategory
{
  public class UpdateUserCategoryRequest
  {
    [Display(Name = "Category name")]
    public string Name { get; set; }

    public decimal? Limit { get; set; }

    [Display(Name = "Transaction Type Identifier")]
    public int? TransactionTypeId { get; set; }
  }
}