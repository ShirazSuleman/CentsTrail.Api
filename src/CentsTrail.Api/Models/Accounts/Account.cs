using System;
using Newtonsoft.Json;

namespace CentsTrail.Api.Models.Accounts
{
  public class Account
  {
    public long Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public string UserId { get; set; }

    public int AccountTypeId { get; set; }

    [JsonIgnore]
    public DateTime DateAdded { get; set; }
  }
}