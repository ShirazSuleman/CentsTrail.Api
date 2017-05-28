using System;
using Newtonsoft.Json;

namespace CentsTrail.Api.Models.Periods
{
  public class Period
  {
    public long Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public string UserId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [JsonIgnore]
    public DateTime DateAdded { get; set; }
  }
}