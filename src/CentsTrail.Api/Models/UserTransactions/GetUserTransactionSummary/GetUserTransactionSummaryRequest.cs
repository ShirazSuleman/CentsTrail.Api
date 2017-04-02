using System;

namespace CentsTrail.Api.Models.UserTransactions.GetUserTransactionSummary
{
  public class GetUserTransactionSummaryRequest
  {
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? PartitionByCategory { get; set; }
  }
}