using Newtonsoft.Json;

namespace CentsTrail.Api.Models.Transactions.GetTransactionSummary
{
  public class TransactionSummary
  {
    [JsonIgnore]
    public string UserId { get; set; }

    public decimal AmountTotal { get; set; }

    public int CategoryTypeId { get; set; }

    public long? CategoryId { get; set; }
  }
}