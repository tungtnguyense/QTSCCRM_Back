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
    [RoutePrefix("api/marketingplan")]
    public class MarketingPlanController : ApiController
    {
        private readonly IMarketingPlanService _marketingPlanService;

        public MarketingPlanController(IMarketingPlanService _marketingPlanService)
        {
            this._marketingPlanService = _marketingPlanService;
        }

        [Route("CreateMarketingPlan")]
        [HttpPost]
        public IHttpActionResult CreateMarketingPlan(CreateMarketingPlanViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MarketingPlan plan = viewModel.ToMarketingPlanEntity();
            List<MarketingPlanDate> planDates = viewModel.toMarketingPlanDateEntities();
            _marketingPlanService.CreateMarketingPlan(plan, planDates);
            return Ok();
        }

        [Route("EditMarketingPlan")]
        [HttpPut]
        public IHttpActionResult EditMarketingPlan()
        {
            return Ok();
        }

        [Route("ValidateMarketingPlan")]
        [HttpPut]
        public IHttpActionResult ValidateMarketingPlan(ValidateMarketingPlanViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            MarketingPlan updatedPlan = request.ToMarketingPlanEntity();

            return Ok();
        }

        [Route("ApproveMarketingPlan")]
        [HttpPut]
        public IHttpActionResult ApproveMarketingPlan()
        {
            return Ok();
        }

        [Route("AcceptMarketingPlan")]
        [HttpPut]
        public IHttpActionResult AcceptMarketingPlan()
        {
            return Ok();
        }

        //[Route("GetMarketingPlanList")]
        //[HttpGet]
        //public IEnumerable<MarketingPlanViewModel> GetMarketingPlanList()
        //{
        //    return _marketingPlanService.GetMarketingPlanList().Select(
        //        c => new MarketingPlanViewModel() {
        //            Id = c.Id,
        //            Title = c.Title,
        //            Description = c.Description,
        //            TotalBudget = c.TotalBudget,
        //            EventScheduleFile = c.EventScheduleFile,
        //            TaskAssignFile = c.TaskAssignFile,
        //            BudgetFile = c.BudgetFile,
        //            LicenseFile = c.LicenseFile,
        //            StageId = c.StageId,
        //            StageName = c.MarketingStage.Name
        //            //ValidatedById = c.ValidatedById,
        //            //ValidatedByName = c.Staff2.LastName + " " + c.Staff2.MiddleName + " " + c.Staff2.FirstName,
        //            //ValidatedDate = c.ValidatedDate,
        //            //ValidatedNote = c.ValidatedNote

        //        });
        //}

    }
}
