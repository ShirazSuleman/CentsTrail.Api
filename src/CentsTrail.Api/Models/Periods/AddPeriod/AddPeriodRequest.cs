using System;
using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.Periods.AddPeriod
{
  public class AddPeriodRequest
  {
    [Required(ErrorMessage = "An Account name is required")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
    [Display(Name = "Account name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A Start Date is required")]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date")]
    public DateTime? EndDate { get; set; }
  }
}