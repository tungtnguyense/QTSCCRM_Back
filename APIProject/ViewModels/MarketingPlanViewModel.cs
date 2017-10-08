using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class MarketingPlanViewModel
    {
        public int PlanID { get; set; }
        public CreatedByStaff? CreateStaff { get; set; }
        public UpdatedByStaff? UpdateStaff { get; set; }
        public ValidatedByStaff? ValidateStaff { get; set; }
        public ApprovedByStaff? ApproveStaff { get; set; }
        public string StageName { get; set; }
        public string ValidateNotes { get; set; }
        public string ApproveNotes { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<DateTime> PlanDates { get; set; }
        public AttachedFiles AttachedFiles { get; set; }

        public MarketingPlanViewModel(MarketingPlan item)
        {
            PlanID = item.Id;
            CreateStaff = new CreatedByStaff()
            {
                ID = item.CreatedByStaff.Id,
                Name = item.CreatedByStaff.LastName + " " + item.CreatedByStaff.MiddleName + " " + item.CreatedByStaff.FirstName
            };
            if (item.UpdatedById != null)
            {
                UpdateStaff = new UpdatedByStaff()
                {
                    ID = item.UpdatedByStaff.Id,
                    Name = item.UpdatedByStaff.LastName + " " + item.UpdatedByStaff.MiddleName + " " + item.UpdatedByStaff.FirstName
                };
            }
            if (item.ValidatedById != null)
            {
                ValidateStaff = new ValidatedByStaff()
                {
                    ID = item.ValidatedByStaff.Id,
                    Name = item.ValidatedByStaff.LastName + " " + item.ValidatedByStaff.MiddleName + " " + item.ValidatedByStaff.FirstName
                };
            }
            if (item.ApprovedById != null)
            {
                ApproveStaff = new ApprovedByStaff()
                {
                    ID = item.ApprovedByStaff.Id,
                    Name = item.ApprovedByStaff.LastName + " " + item.ApprovedByStaff.MiddleName + " " + item.ApprovedByStaff.FirstName
                };
            }
            StageName = item.MarketingStage.Name;
            ValidateNotes = item.ValidateNotes;
            ApproveNotes = item.ApproveNotes;
            Title = item.Title;
            Description = item.Description;
            if(item.MarketingPlanDates.Count != 0)
            {
                PlanDates = new List<DateTime>();
                PlanDates.AddRange(item.MarketingPlanDates.Select(x => x.PlanDate));
            }
            AttachedFiles = new AttachedFiles()
            {
                EventScheduleFile = item.EventSheduleFile,
                TaskAssignFile = item.TaskAssign,
                BudgetFile = item.BudgetFile
            };
        }

    }

    public struct CreatedByStaff
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public struct UpdatedByStaff
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public struct ValidatedByStaff
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public struct ApprovedByStaff
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public struct AttachedFiles
    {
        public string EventScheduleFile { get; set; }
        public string TaskAssignFile { get; set; }
        public string BudgetFile { get; set; }

    }


}