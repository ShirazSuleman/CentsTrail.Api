using System;

namespace CentsTrail.Api.Models.UserTransactions.SearchUserTransactions
{
  public class SearchUserTransactionsRequest
  {
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public  long? UserCategoryId { get; set; }

    public int? TransactionTypeId { get; set; }
  }
}