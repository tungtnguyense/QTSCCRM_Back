using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Model.Models
{
    [Table("Issue")]
    public partial class Issue
    {
        public int Id { get; set; }

        public int? SalesCategoryId { get; set; }

        public int? CreatedById { get; set; }

        public int? OpenById { get; set; }

        public int? SolveById { get; set; }

        public int? AcceptedById { get; set; }

        public int? CustomerId { get; set; }

        public int? ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Staff AcceptedByStaff { get; set; }

        public virtual Staff CreatedByStaff { get; set; }

        public virtual Staff OpenByStaff { get; set; }

        public virtual SalesCategory SalesCategory { get; set; }

        public virtual Staff SolveByStaff { get; set; }
    }
}
