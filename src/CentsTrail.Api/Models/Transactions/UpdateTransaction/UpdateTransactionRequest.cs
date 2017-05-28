using System;
using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.Transactions.UpdateTransaction
{
  public class UpdateTransactionRequest
  {
    public string Description { get; set; }

    public decimal? Amount { get; set; }

    [Display(Name = "Account Identifier")]
    public int? AccountId { get; set; }

    [Display(Name = "Category Identifier")]
    public int? CategoryId { get; set; }

    [Display(Name = "Period Identifier")]
    public int? PeriodId { get; set; }

    [Display(Name = "Transaction Date")]
    public DateTime? TransactionDate { get; set; }
  }
}