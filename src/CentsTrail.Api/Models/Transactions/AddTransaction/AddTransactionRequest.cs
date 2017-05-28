using System;
using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.Transactions.AddTransaction
{
  public class AddTransactionRequest
  {
    public string Description { get; set; }

    [Required(ErrorMessage = "An amount is required")]
    [Range(0, double.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "An Account is required")]
    [Display(Name = "Account Identifier")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public int AccountId { get; set; }

    [Required(ErrorMessage = "A Category is required")]
    [Display(Name = "Category Identifier")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "A Period is required")]
    [Display(Name = "Period Identifier")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public int PeriodId { get; set; }

    [Required(ErrorMessage = "A Transaction date is required")]
    [Display(Name = "Transaction Date")]
    public DateTime TransactionDate { get; set; }
  }
}