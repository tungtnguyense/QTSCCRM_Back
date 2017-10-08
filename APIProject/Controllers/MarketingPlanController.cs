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
        private readonly IStaffService _staffService;

        public MarketingPlanController(IMarketingPlanService _marketingPlanService, IStaffService _staffService)
        {
            this._marketingPlanService = _marketingPlanService;
            this._staffService = _staffService;
        }

        [Route("CreateMarketingPlan")]
        [HttpPost]
        public IHttpActionResult CreateMarketingPlan(CreateMarketingPlanViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_staffService.CheckStaffExist(viewModel.StaffID) == false)
            {
                return NotFound();
            }
            MarketingPlan plan = viewModel.ToMarketingPlanEntity();
            List<MarketingPlanDate> planDates = viewModel.toMarketingPlanDateEntities();
            int insertedPlanId = _marketingPlanService.CreateMarketingPlan(plan, planDates, viewModel.IsFinished);
            
            return Ok();
        }

        [Route("EditMarketingPlan")]
        [HttpPut]
        public IHttpActionResult EditMarketingPlan(EditMarketingPlanViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_marketingPlanService.CheckPlanExist(viewModel.PlanID) == false)
            {
                return NotFound();
            }
            if (_staffService.CheckStaffExist(viewModel.StaffID) == false)
            {
                return NotFound();
            }
            if (!_marketingPlanService.CheckPlanStageIsDrafting(viewModel.PlanID))
            {
                return BadRequest();

            }

            MarketingPlan editingPlan = viewModel.ToMarketingPlanEntity();
            List<MarketingPlanDate> planDates = viewModel.ToMarketingPlanDateEntities();
            int editedPlanId = _marketingPlanService.EditMarketingPlan(editingPlan, planDates, viewModel.IsFinished);

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
            if(_marketingPlanService.CheckPlanExist(request.PlanId) == false)
            {
                return NotFound();
            }
            
            if(_staffService.CheckStaffExist(request.StaffId) == false)
            {
                return NotFound();
            }
            if (_marketingPlanService.CheckPlanStageIsValidating(request.PlanId) == false)
            {
                return BadRequest();
            }
            MarketingPlan updatedPlan = request.ToMarketingPlanEntity();
            _marketingPlanService.ValidatePlan(updatedPlan);
            return Ok();
        }

        [Route("ApproveMarketingPlan")]
        [HttpPut]
        public IHttpActionResult ApproveMarketingPlan(ApproveMarketingPlanViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_marketingPlanService.CheckPlanExist(request.PlanId) == false)
            {
                return NotFound();
            }
            if (_staffService.CheckStaffExist(request.StaffId) == false)
            {
                return NotFound();
            }
            if (_marketingPlanService.CheckPlanStageIsApproving(request.PlanId) == false)
            {
                return BadRequest();
            }
            MarketingPlan updatedPlan = request.ToMarketingPlanEntitiy();
            _marketingPlanService.ApprovePlan(updatedPlan);
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
