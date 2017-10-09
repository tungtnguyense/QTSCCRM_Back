using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class CreateCustomerViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime EstablishedDate { get; set; }
        [Required]
        public string TaxCode { get; set; }
        public string Address { get; set; }
    }
}