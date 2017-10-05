namespace APIProject.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarketingPlan")]
    public partial class MarketingPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MarketingPlan()
        {
            MarketingPlanDates = new HashSet<MarketingPlanDate>();
            MarketingResults = new HashSet<MarketingResult>();
        }

        public int Id { get; set; }

        public int? CreatedById { get; set; }

        public int? UpdatedById { get; set; }

        public int? ValidatedById { get; set; }

        public int? ApprovedById { get; set; }

        public int? StageId { get; set; }

        public virtual MarketingStage MarketingStage { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Staff Staff1 { get; set; }

        public virtual Staff Staff2 { get; set; }

        public virtual Staff Staff3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketingPlanDate> MarketingPlanDates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketingResult> MarketingResults { get; set; }
    }
}
