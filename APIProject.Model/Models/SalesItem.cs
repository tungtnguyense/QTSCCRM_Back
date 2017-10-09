using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Model.Models
{
    [Table("SalesItem")]
    public partial class SalesItem
    {
        public int Id { get; set; }

        public int? SalesCategoryId { get; set; }

        public virtual SalesCategory SalesCategory { get; set; }
    }
}
