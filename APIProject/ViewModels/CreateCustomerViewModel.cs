using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class CreateCustomerViewModel
    {
        public string Name { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public string TaxCode { get; set; }
    }
}