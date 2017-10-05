using APIProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProject.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService _customerService)
        {
            this._customerService = _customerService;
        }

        [Route("CreateCustomer")]
        [HttpPost]
        public IHttpActionResult CreateCustomer()
        {
            return Ok();
        }

        [Route("EditLead")]
        [HttpPut]
        public IHttpActionResult EditLead()
        {
            return Ok();
        }

        [Route("EditCustomer")]
        [HttpPut]
        public IHttpActionResult EditCustomer()
        {
            return Ok();
        }
    }
}
