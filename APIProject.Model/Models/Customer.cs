namespace APIProject.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Contacts = new HashSet<Contact>();
            MarketingResults = new HashSet<MarketingResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public bool IsLead { get; set; }
        public string CustomerType { get; set; }
            
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketingResult> MarketingResults { get; set; }
    }
}
