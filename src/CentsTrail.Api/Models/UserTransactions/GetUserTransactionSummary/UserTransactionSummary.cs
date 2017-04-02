using Newtonsoft.Json;

namespace CentsTrail.Api.Models.UserTransactions.GetUserTransactionSummary
{
  public class UserTransactionSummary
  {
    [JsonIgnore]
    public string UserId { get; set; }

    public decimal AmountTotal { get; set; }

    public int TransactionTypeId { get; set; }

    public long? UserCategoryId { get; set; }
  }
}