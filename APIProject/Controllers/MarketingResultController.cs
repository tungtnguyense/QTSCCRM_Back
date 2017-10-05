using APIProject.Service;
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
        public IHttpActionResult CreateMarketingResult()
        {
            return Ok();
        }
    }
}
