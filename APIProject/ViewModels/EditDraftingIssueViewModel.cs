using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class EditDraftingIssueViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int SalesCategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string Description { get; set; }
        [Required]
        public int ContactId { get; set; }
        public string OpenNotes { get; set; }
        public bool IsFinished { get; set; }

        public Issue ToIssueEntity()
        {
            return new Issue()
            {
                Id = this.Id,
                CreatedById = this.StaffId,
                SalesCategoryId = this.SalesCategoryId,
                Title = this.Title,
                CustomerId = this.CustomerId,
                Description = this.Description,
                OpenNotes = this.OpenNotes
            };
        }
    }
}