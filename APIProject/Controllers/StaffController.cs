using APIProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProject.Controllers
{
    [RoutePrefix("api/staff")]
    public class StaffController : ApiController
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService _staffService)
        {
            this._staffService = _staffService;
        }

        [Route("CreateStaff")]
        [HttpPost]
        public IHttpActionResult CreateStaff()
        {
            return Ok();
        }

        [Route("EditStaff")]
        [HttpPut]
        public IHttpActionResult EditStaff()
        {
            return Ok();
        }

        [Route("EditStaffRole")]
        [HttpPut]
        public IHttpActionResult EditStaffRole()
        {
            return Ok();
        }

    }
}
