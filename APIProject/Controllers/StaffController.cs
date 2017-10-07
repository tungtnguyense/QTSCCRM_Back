using APIProject.Model.Models;
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
        public IHttpActionResult CreateStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_staffService.CheckTakenUsername(staff.Username))
            {
                return BadRequest("Username taken");
            }
            _staffService.CreateStaff(staff);
            return Ok();
        }

        [Route("EditStaff")]
        [HttpPut]
        public IHttpActionResult EditStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _staffService.EditStaff(staff);

            return Ok();
        }

        [Route("CheckTakenUsername")]
        [HttpGet]
        public IHttpActionResult CheckTakenUsername(string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_staffService.CheckTakenUsername(username))
            {
                return Ok("Taken");
            }
            return Ok("NotTaken");
        }

    }
}
