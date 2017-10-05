using APIProject.Model.Models;
using APIProject.Service;
using APIProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProject.Controllers
{
    public class MarketingPlanController : ApiController
    {
        private readonly IMarketingPlanService _marketingPlanService;
        public MarketingPlanController(IMarketingPlanService _marketingPlanService)
        {
            this._marketingPlanService = _marketingPlanService;
        }
        [Route("api/CreateMarketingPlan")]
        [HttpPost]
        public IHttpActionResult CreateMarketingPlan(CreateMarketingPlanViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Do something with the product (not shown).

                return BadRequest();
            }

            _marketingPlanService.CreatePlanV2(viewModel.Plan,viewModel.MarketingPlanDates);

            return Ok();
        }

        [Route("api/GetMarketingPlanList")]
        [HttpGet]
        public IEnumerable<MarketingPlanViewModel> GetMarketingPlanList()
        {
            return _marketingPlanService.GetMarketingPlanList().Select(
                c => new MarketingPlanViewModel() {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    TotalBudget = c.TotalBudget,
                    EventScheduleFile = c.EventScheduleFile,
                    TaskAssignFile = c.TaskAssignFile,
                    BudgetFile = c.BudgetFile,
                    LicenseFile = c.LicenseFile,
                    StageId = c.StageId,
                    StageName = c.MarketingStage.Name,
                    ValidatedById = c.ValidatedById,
                    ValidatedByName = c.Staff2.LastName + " " + c.Staff2.MiddleName + " " + c.Staff2.FirstName,
                    ValidatedDate = c.ValidatedDate,
                    ValidatedNote = c.ValidatedNote

        });
        }
    }
}
