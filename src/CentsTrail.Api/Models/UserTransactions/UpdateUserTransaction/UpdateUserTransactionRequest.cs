using System;
using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.UserTransactions.UpdateUserTransaction
{
  public class UpdateUserTransactionRequest
  {
    public string Description { get; set; }

    public decimal? Amount { get; set; }

    [Display(Name = "User Category Identifier")]
    public int? UserCategoryId { get; set; }

    [Display(Name = "Transaction Date")]
    public DateTime? TransactionDate { get; set; }
  }
}