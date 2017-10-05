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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? PlanId { get; set; }

        public int? CreatedById { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public int CustomerId { get; set; }

        public int? ContactId { get; set; }

        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public bool? AttendMore { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        public bool? IsFromMail { get; set; }

        public bool? IsFromMedia { get; set; }

        public bool? IsFromFriend { get; set; }

        public bool? IsFromWebsite { get; set; }

        public bool? IsFromAssosiation { get; set; }

        public bool? IsFromOther { get; set; }

        public int? FacilitiesRating { get; set; }

        public int? OrganizingRating { get; set; }

        public int? ServiceRating { get; set; }

        public int? PresenterRating { get; set; }

        public int? OthersRating { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual MarketingPlan MarketingPlan { get; set; }
    }
}
