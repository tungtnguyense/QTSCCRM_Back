using APIProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProject.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService _roleService)
        {
            this._roleService = _roleService;
        }

        [Route("CreateRole")]
        [HttpPost]
        public IHttpActionResult CreateRole()
        {
            return Ok();
        }

        [Route("EditRole")]
        [HttpPut]
        public IHttpActionResult EditRole()
        {
            return Ok();
        }
    }
}
