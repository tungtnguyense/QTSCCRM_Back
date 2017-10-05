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
            Customers = new HashSet<Customer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? IsValidated { get; set; }

        [StringLength(255)]
        public string ValidatedNote { get; set; }

        public int? ValidatedById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValidatedDate { get; set; }

        public bool? IsAccepted { get; set; }

        [StringLength(255)]
        public string AcceptedNote { get; set; }

        public int? AcceptedById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AcceptedDate { get; set; }

        public bool? IsApproved { get; set; }

        [StringLength(255)]
        public string ApproveNote { get; set; }

        public int? ApprovedById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ApprovedDate { get; set; }

        public int? CreatedById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public int? UpdatedById { get; set; }

        public int? UpdatedDate { get; set; }

        public int? StageId { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string TotalBudget { get; set; }

        [StringLength(255)]
        public string EventScheduleFile { get; set; }

        [StringLength(255)]
        public string TaskAssignFile { get; set; }

        [StringLength(255)]
        public string BudgetFile { get; set; }

        [StringLength(255)]
        public string LicenseFile { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CompletedDate { get; set; }

        public virtual MarketingStage MarketingStage { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Staff Staff1 { get; set; }

        public virtual Staff Staff2 { get; set; }

        public virtual Staff Staff3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketingPlanDate> MarketingPlanDates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketingResult> MarketingResults { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
