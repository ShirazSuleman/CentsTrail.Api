using System;

namespace CentsTrail.Api.TransactionTypes.Models
{
  public class TransactionType
  {
    public int TransactionTypeId { get; set; }
    public string Name { get; set; }
    public bool IsLimitSupported { get; set; }
    public DateTime DateAdded { get; set; }
  }
}