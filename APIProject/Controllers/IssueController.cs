using APIProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProject.Controllers
{
    [RoutePrefix("api/issue")]
    public class IssueController : ApiController
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService _issueService)
        {
            this._issueService = _issueService;
        }

        [Route("CreateIssue")]
        [HttpPost]
        public IHttpActionResult CreateIssue()
        {
            return Ok();
        }

        [Route("EditIssue")]
        [HttpPut]
        public IHttpActionResult EditIssue()
        {
            return Ok();
        }

        [Route("GetIssue")]
        [HttpGet]
        public IHttpActionResult GetIssue()
        {
            return Ok();
        }
    }
}
