using System;
using Newtonsoft.Json;

namespace CentsTrail.Api.Models.UserTransactions
{
  public class UserTransaction
  {
    public long UserTransactionId { get; set; }

    public string Description { get; set; }

    [JsonIgnore]
    public string UserId { get; set; }

    public decimal Amount { get; set; }

    public long UserCategoryId { get; set; }

    [JsonIgnore]
    public DateTime DateAdded { get; set; }

    public DateTime TransactionDate { get; set; }
  }
}