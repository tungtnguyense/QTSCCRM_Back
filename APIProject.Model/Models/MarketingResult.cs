namespace APIProject.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarketingResult")]
    public partial class MarketingResult
    {
        public int Id { get; set; }

        public int? MarketingPlanId { get; set; }

        public int? CustomerId { get; set; }

        public int? ContactId { get; set; }

        public string CustomerName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactMiddleName { get; set; }
        public string ContactLastName { get; set; }
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


        public virtual Contact Contact { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual MarketingPlan MarketingPlan { get; set; }
    }
}
