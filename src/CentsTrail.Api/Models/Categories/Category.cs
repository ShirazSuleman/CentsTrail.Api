using System;
using Newtonsoft.Json;

namespace CentsTrail.Api.Models.Categories
{
  public class Category
  {
    public long Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public string UserId { get; set; }

    public decimal? Limit { get; set; }

    public int CategoryTypeId { get; set; }

    [JsonIgnore]
    public DateTime DateAdded { get; set; }
  }
}