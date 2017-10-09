namespace APIProject.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarketingPlanDate")]
    public partial class MarketingPlanDate
    {
        public int Id { get; set; }
        public DateTime PlanDate { get; set; }

        public int? MarketingPlanId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual MarketingPlan MarketingPlan { get; set; }
    }
}