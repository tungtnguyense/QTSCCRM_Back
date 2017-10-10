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
    [RoutePrefix("api/issue")]
    public class IssueController : ApiController
    {
        private readonly IIssueService _issueService;
        private readonly IStaffService _staffService;
        private readonly ICustomerService _customerService;
        private readonly IContactService _contactService;
        private readonly ISalesCategoryService _salesCategoryService;

        public IssueController(IIssueService _issueService, IStaffService _staffService, ICustomerService _customerService,
            IContactService _contactService, ISalesCategoryService _salesCategoryService)
        {
            this._issueService = _issueService;
            this._staffService = _staffService;
            this._customerService = _customerService;
            this._contactService = _contactService;
            this._salesCategoryService = _salesCategoryService;
        }

        [Route("CreateIssue")]
        [HttpPost]
        public IHttpActionResult CreateIssue(CreateIssueViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (!_staffService.CheckStaffExist(request.StaffId))
                {
                    return BadRequest();
                }
                if (!_customerService.IsCustomerExist(request.CustomerId))
                {
                    return BadRequest();
                }
                if (!_customerService.IsCustomerLead(request.CustomerId))
                {
                    return BadRequest();
                }
                if (!_contactService.IsContactExist(request.ContactId))
                {
                    return BadRequest();
                }
                if(!_customerService.CustomerHasContact(request.CustomerId, request.ContactId))
                {
                    return BadRequest();
                }
                if (!_salesCategoryService.IsCategoryExist(request.SalesCategoryId))
                {
                    return BadRequest();
                }
                if(request.OpenNotes != null)
                {
                    if (!request.IsFinished)
                    {
                        return BadRequest();
                    }
                }
            }

            _issueService.CreateIssue(request.ToIssueEntity(), request.IsFinished);

            return Ok();
        }

        [Route("EditIssue")]
        [HttpPut]
        public IHttpActionResult EditIssue(EditIssueViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (!_staffService.CheckStaffExist(request.StaffId))
                {
                    return BadRequest();
                }
                if (!_customerService.IsCustomerExist(request.CustomerId))
                {
                    return BadRequest();
                }
                if (!_customerService.IsCustomerLead(request.CustomerId))
                {
                    return BadRequest();
                }
                if (!_contactService.IsContactExist(request.ContactId))
                {
                    return BadRequest();
                }
                if (!_customerService.CustomerHasContact(request.CustomerId, request.ContactId))
                {
                    return BadRequest();
                }
                if (!_salesCategoryService.IsCategoryExist(request.SalesCategoryId))
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        [Route("EditDraftingIssue")]
        [HttpPut]
        public IHttpActionResult EditDraftingIssue(EditDraftingIssueViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                if (!_staffService.CheckStaffExist(request.StaffId))
                {
                    return BadRequest();
                }
                if (!_customerService.IsCustomerExist(request.CustomerId))
                {
                    return BadRequest();
                }
                if (!_customerService.IsCustomerLead(request.CustomerId))
                {
                    return BadRequest();
                }
                if (!_contactService.IsContactExist(request.ContactId))
                {
                    return BadRequest();
                }
                if (!_customerService.CustomerHasContact(request.CustomerId, request.ContactId))
                {
                    return BadRequest();
                }
                if (!_salesCategoryService.IsCategoryExist(request.SalesCategoryId))
                {
                    return BadRequest();
                }
                if (_issueService.IsIssueExist(request.Id))
                {
                    return BadRequest();
                }
                if (request.OpenNotes != null)
                {
                    if (!request.IsFinished)
                    {
                        return BadRequest();
                    }

                    //validate stage
                }
            }

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
