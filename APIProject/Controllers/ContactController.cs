using APIProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProject.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService _contactService)
        {
            this._contactService = _contactService;
        }

        [Route("CreateContact")]
        [HttpPost]
        public IHttpActionResult CreateContact()
        {
            return Ok();
        }

        [Route("EditContract")]
        [HttpPut]
        public IHttpActionResult EditContract()
        {
            return Ok();
        }
    }
}
