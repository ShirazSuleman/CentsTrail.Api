using System;

namespace CentsTrail.Api.Models.Transactions.GetTransactionSummary
{
  public class GetTransactionSummaryRequest
  {
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public long? AccountId { get; set; }

    public long? PeriodId { get; set; }

    public bool? PartitionByCategory { get; set; }
  }
}