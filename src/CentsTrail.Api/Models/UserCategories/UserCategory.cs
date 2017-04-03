using System;
using Newtonsoft.Json;

namespace CentsTrail.Api.Models.UserCategories
{
  public class UserCategory
  {
    public long UserCategoryId { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public string UserId { get; set; }

    public decimal? Limit { get; set; }

    public int TransactionTypeId { get; set; }

    [JsonIgnore]
    public DateTime DateAdded { get; set; }
  }
}