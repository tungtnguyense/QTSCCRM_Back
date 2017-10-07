using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class ValidateMarketingPlanViewModel
    {
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int PlanId { get; set; }
        [Required]
        public bool IsValidated { get; set; }
        public string ValidateNotes { get; set; }

        public MarketingPlan ToMarketingPlanEntity()
        {
            return new MarketingPlan()
            {
                Id = this.PlanId,
                ValidatedById = this.StaffId,
                IsValidated = this.IsValidated,
                ValidateNotes = this.ValidateNotes
            };
        }
    }
}