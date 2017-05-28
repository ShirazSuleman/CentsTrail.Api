using System;
using System.ComponentModel.DataAnnotations;

namespace CentsTrail.Api.Models.Periods.UpdatePeriod
{
  public class UpdatePeriodRequest
  {
    [Display(Name = "Account name")]
    public string Name { get; set; }

    [Display(Name = "Start Date")]
    public DateTime? StartDate { get; set; }

    [Display(Name = "End Date")]
    public DateTime? EndDate { get; set; }
  }
}