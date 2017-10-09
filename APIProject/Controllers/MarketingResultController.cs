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
    [RoutePrefix("api/marketingresult")]
    public class MarketingResultController : ApiController
    {
        private readonly IMarketingResultService _marketingResultService;
        private readonly ICustomerService _customerService;
        private readonly IContactService _contactService;

        public MarketingResultController(IMarketingResultService _marketingResultService, ICustomerService _customerService,
            IContactService _contactService)
        {
            this._marketingResultService = _marketingResultService;
            this._customerService = _customerService;
            this._contactService = _contactService;
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
                
                requestList.Add(requestItem.ToMarketingResultEntity());
            }

            _marketingResultService.CreateMarketingResults(requestList);


            return Ok();
        }
    }
}
