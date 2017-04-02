using System;
using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.UserTransactions.AddUserTransaction
{
  public class AddUserTransactionRequest
  {
    public string Description { get; set; }

    [Required(ErrorMessage = "An amount is required")]
    [Range(0, double.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "A User category is required")]
    [Display(Name = "User Category Identifier")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public int UserCategoryId { get; set; }

    [Required(ErrorMessage = "A Transaction date is required")]
    [Display(Name = "Transaction Date")]
    public DateTime TransactionDate { get; set;}
  }
}