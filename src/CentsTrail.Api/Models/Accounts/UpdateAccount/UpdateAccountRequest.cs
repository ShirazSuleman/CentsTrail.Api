using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.Accounts.UpdateAccount
{
  public class UpdateAccountRequest
  {
    [Display(Name = "Account name")]
    public string Name { get; set; }

    [Display(Name = "Currency Identifier")]
    public int? CurrencyId { get; set; }

    [Display(Name = "Account Type Identifier")]
    public int? AccountTypeId { get; set; }
  }
}