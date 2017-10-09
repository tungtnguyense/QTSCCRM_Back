﻿using APIProject.Model.Models;
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
    [RoutePrefix("api/marketingresult")]
    public class MarketingResultController : ApiController
    {
        private readonly IMarketingResultService _marketingResultService;
        private readonly ICustomerService _customerService;
        private readonly IContactService _contactService;
        private readonly IMarketingPlanService _marketingPlanService;

        public MarketingResultController(IMarketingResultService _marketingResultService, ICustomerService _customerService,
            IContactService _contactService, IMarketingPlanService _marketingPlanService)
        {
            this._marketingResultService = _marketingResultService;
            this._customerService = _customerService;
            this._contactService = _contactService;
            this._marketingPlanService = _marketingPlanService;
        }

        [Route("CreateMarketingResult")]
        [HttpPost]
        public IHttpActionResult CreateMarketingResult(List<CreateMarketingResultViewModel> request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            List<MarketingResult> requestList = new List<MarketingResult>();
            foreach(CreateMarketingResultViewModel requestItem in request)
            {
                //Check Exist
                if(requestItem.CustomerID.HasValue)
                {
                    if (!_customerService.IsCustomerExist(requestItem.CustomerID.Value))
                    {
                        return NotFound();
                    }
                }
                if(requestItem.ContactID.HasValue)
                {
                    if (!_contactService.IsContactExist(requestItem.ContactID.Value))
                    {
                        return NotFound();
                    }
                }
                if (!_marketingPlanService.IsPlanExist(requestItem.PlanID))
                {
                    return NotFound();
                }
                
                requestList.Add(requestItem.ToMarketingResultEntity());
            }

            _marketingResultService.CreateMarketingResults(requestList);


            return Ok();
        }

        [Route("GetMarketingResultList")]
        [HttpGet]
        public IHttpActionResult GetMarketingResultList(string planId, string actId)
        {
            //TO-Do
            return Ok(planId + " " + actId);
        }
    }
}
