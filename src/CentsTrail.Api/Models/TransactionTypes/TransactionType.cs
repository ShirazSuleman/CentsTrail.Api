using System;
using Newtonsoft.Json;

namespace CentsTrail.Api.Models.TransactionTypes
{
  public class TransactionType
  {
    public int TransactionTypeId { get; set; }

    public string Name { get; set; }

    public bool IsLimitSupported { get; set; }

    [JsonIgnore]
    public DateTime DateAdded { get; set; }
  }
}