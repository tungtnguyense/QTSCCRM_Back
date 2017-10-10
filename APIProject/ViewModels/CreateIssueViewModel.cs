using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class CreateIssueViewModel
    {
        [Required]
        public int StaffId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int SalesCategoryId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public bool IsFinished { get; set; }
        public string OpenNotes { get; set; }


        public Issue ToIssueEntity()
        {
            return new Issue()
            {
                CreatedById = this.StaffId,
                Title = this.Title,
                Description = this.Description,
                CustomerId = this.CustomerId,
                ContactId = this.ContactId,
                SalesCategoryId = this.SalesCategoryId,
                OpenNotes = this.OpenNotes
            };
        }
    }
}