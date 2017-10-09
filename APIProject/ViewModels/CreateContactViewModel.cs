using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class CreateContactViewModel
    {
        [Required]
        public int CustomerID { get; set; }
        public string AvatarImg { get; set; }
        public string ContactName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsMain { get; set; }

        public Contact ToContactEntity()
        {
            return new Contact()
            {
                CustomerId = this.CustomerID,
                AvatarImg = this.AvatarImg,
                Name = this.ContactName,
                Position = this.Position,
                Phone = this.Phone,
                Email = this.Email,
                IsMain = this.IsMain
            };
        }

    }
}