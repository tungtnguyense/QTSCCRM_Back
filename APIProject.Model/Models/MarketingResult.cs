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

        public virtual Contact Contact { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual MarketingPlan MarketingPlan { get; set; }
    }
}
