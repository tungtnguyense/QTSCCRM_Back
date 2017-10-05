using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class MarketingPlanViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set;}
        public string TotalBudget { get; set; }
        public string EventScheduleFile { get; set; }
        public string TaskAssignFile { get; set; }
        public string BudgetFile { get; set; }
        public string LicenseFile { get; set; }
        public int? StageId { get; set; }
        public string StageName { get; set; }
        public int? ValidatedById { get; set; }
        public string ValidatedByName { get; set; }
        public DateTime? ValidatedDate { get; set; }
        public string ValidatedNote { get; set; }
        //thiếu vcl ra
        
    }
}