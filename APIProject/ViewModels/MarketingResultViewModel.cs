using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class MarketingResultViewModel
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactId { get; set; }

        public string CustomerName { get; set; }
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
    }
}