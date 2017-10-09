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

        public MarketingResultController(IMarketingResultService _marketingResultService)
        {
            this._marketingResultService = _marketingResultService;
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
                requestList.Add(requestItem.ToMarketingResultEntity());
            }


            return Ok();
        }
    }
}
