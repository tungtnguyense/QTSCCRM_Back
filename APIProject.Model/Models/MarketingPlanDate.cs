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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? PlanId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PlanDate { get; set; }

        public virtual MarketingPlan MarketingPlan { get; set; }
    }
}
