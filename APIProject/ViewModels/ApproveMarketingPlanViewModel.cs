using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class ApproveMarketingPlanViewModel
    {
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int PlanId { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        public string ApproveNotes { get; set; }

        public MarketingPlan ToMarketingPlanEntitiy()
        {
            return new MarketingPlan()
            {
                Id = this.PlanId,
                ApprovedById = this.StaffId,
                ApproveNotes = this.ApproveNotes
            };
        }
    }
}