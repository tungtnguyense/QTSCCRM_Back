using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class EditCustomerViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CustomerType { get; set; }
    }
}