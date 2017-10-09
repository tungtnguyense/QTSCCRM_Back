using APIProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIProject.Model.Models;
using APIProject.ViewModels;

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
        public IHttpActionResult CreateCustomer(CreateCustomerViewModel createCustomerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _customerService.CreateCustomer(new Customer
            {
                Name = createCustomerViewModel.Name,
                EstablishedDate = createCustomerViewModel.EstablishedDate,
                TaxCode = createCustomerViewModel.TaxCode,
                Address = createCustomerViewModel.Address
            });
            return Ok();
        }

        [Route("EditLead")]
        [HttpPut]
        public IHttpActionResult EditLead(EditLeadViewModel leadViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _customerService.EditLead(new Customer
            {
                Id = leadViewModel.Id,
                Name = leadViewModel.Name,
                EstablishedDate = leadViewModel.EstablishedDate,
                TaxCode = leadViewModel.TaxCode,
                Address = leadViewModel.Address
            });
            return Ok();
        }

        [Route("EditCustomer")]
        [HttpPut]
        public IHttpActionResult EditCustomer(EditCustomerViewModel editCustomerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _customerService.EditCustomer(new Customer
            {
                Id = editCustomerViewModel.Id,
                CustomerType = editCustomerViewModel.CustomerType
            });
            return Ok();
        }
    }
}