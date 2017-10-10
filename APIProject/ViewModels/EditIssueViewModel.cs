using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class EditIssueViewModel
    {
        public int IssueId { get; set; }
        public int StaffId { get; set; }
        public int SalesCategoryId { get; set; }
        public int CustomerId { get; set; }

        public int ContactId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string OpenNotes { get; set; }
        public string SolutionNotes { get; set; }
        public string AcceptNotes { get; set; }

        public bool IsFinished { get; set; }
    }
}