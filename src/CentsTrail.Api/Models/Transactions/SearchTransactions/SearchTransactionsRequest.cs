using System;

namespace CentsTrail.Api.Models.Transactions.SearchTransactions
{
  public class SearchTransactionsRequest
  {
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public long? CategoryId { get; set; }

    public long? AccountId { get; set; }

    public long? PeriodId { get; set; }

    public int? CategoryTypeId { get; set; }
  }
}