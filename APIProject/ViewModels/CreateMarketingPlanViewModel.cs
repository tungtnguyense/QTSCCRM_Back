using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class CreateMarketingPlanViewModel
    {
        [Required]
        public int StaffID { get; set; }
        [Required]
        public string Title { get; set; }
        public int Budget { get; set; }
        public string Description { get; set; }
        public ICollection<DateTime> EventDates { get; set; }
        public bool IsFinished { get; set; }
        public string BudgetFileName { get; set; }
        public string BudgetFileContent { get; set; }
        public MarketingPlan ToMarketingPlanEntity()
        {
            MarketingPlan _plan = new MarketingPlan()
            {
                CreatedById = this.StaffID,
                Title = this.Title,
                Budget = this.Budget,
                Description = this.Description
            };
            return _plan;
        }

        public List<MarketingPlanDate> toMarketingPlanDateEntities()
        {
            if(EventDates == null)
            {
                return null;
            }
            List<MarketingPlanDate> _collection = new List<MarketingPlanDate>();
            foreach(DateTime item in EventDates)
            {
                _collection.Add(new MarketingPlanDate() { PlanDate = item });
            }
            return _collection;
        }

    }
}