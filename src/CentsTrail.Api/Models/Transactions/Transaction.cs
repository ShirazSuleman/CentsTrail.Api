using System;
using Newtonsoft.Json;

namespace CentsTrail.Api.Models.Transactions
{
  public class Transaction
  {
    public long Id { get; set; }

    public string Description { get; set; }

    [JsonIgnore]
    public string UserId { get; set; }

    public decimal Amount { get; set; }

    public long AccountId { get; set; }

    public long CategoryId { get; set; }

    public long PeriodId { get; set; }

    public string Account { get; set; }

    public string Category { get; set; }

    public string Period { get; set; }

    [JsonIgnore]
    public DateTime DateAdded { get; set; }

    public DateTime TransactionDate { get; set; }
  }
}