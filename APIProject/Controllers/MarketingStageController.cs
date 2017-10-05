using APIProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProject.Controllers
{
    [RoutePrefix("api/marketingstage")]
    public class MarketingStageController : ApiController
    {
        private readonly IMarketingStageService _marketingStageService;
        public MarketingStageController(IMarketingStageService _marketingStageService)
        {
            this._marketingStageService = _marketingStageService;
        }

        [Route("CreateMarketingStage")]
        [HttpPost]
        public IHttpActionResult CreateMarketingStage()
        {
            return Ok();
        }
        
        [Route("EditMarketingStage")]
        [HttpPut]
        public IHttpActionResult EditMarketingStage()
        {
            return Ok();
        }
    }
}
