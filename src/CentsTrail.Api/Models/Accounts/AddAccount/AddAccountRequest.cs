using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.Accounts.AddAccount
{
  public class AddAccountRequest
  {
    [Required(ErrorMessage = "An Account name is required")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
    [Display(Name = "Account name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A Currency is required")]
    [Display(Name = "Currency Identifier")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public int CurrencyId { get; set; }

    [Required(ErrorMessage = "An Account type is required")]
    [Display(Name = "Account Type Identifier")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a value greather than {1}")]
    public int AccountTypeId { get; set; }
  }
}