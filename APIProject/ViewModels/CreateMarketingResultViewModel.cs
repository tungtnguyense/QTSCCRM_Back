using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class CreateMarketingResultViewModel
    {
        [Required]
        public int PlanID { get; set; }
        public int? CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public int? ContactID { get; set; }
        [Required]
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public int FacilityRate { get; set; }
        public int ArrangingRate { get; set; }
        public int ServicingRate { get; set; }
        public int IndicatorRate { get; set; }
        public int OthersRate { get; set; }
        public bool Media { get; set; }
        public bool InvitationLetter { get; set; }
        public bool QTSCWebsite { get; set; }
        public bool Friend { get; set; }
        public bool FromOthers { get; set; }
        public bool WantAnother { get; set; }

        public MarketingResult ToMarketingResultEntity()
        {
            return new MarketingResult()
            {
                MarketingPlanId = this.PlanID,
                CustomerId = this.CustomerID,
                CustomerName = this.CustomerName,
                ContactId = this.ContactID,
                ContactName = this.ContactName,
                Email = this.Email,
                Phone = this.Phone,
                Address = this.Address,
                Notes = this.Notes,
                FacilityRate = this.FacilityRate,
                ArrangingRate = this.ArrangingRate,
                ServicingRate = this.ServicingRate,
                IndicatorRate = this.IndicatorRate,
                OthersRate = this.OthersRate,
                Media = this.Media,
                InvitationLetter = this.InvitationLetter,
                QTSCWebsite = this.QTSCWebsite,
                Friend = this.Friend,
                FromOthers = this.FromOthers,
                WantAnother = this.WantAnother

            };
        }
    }
}