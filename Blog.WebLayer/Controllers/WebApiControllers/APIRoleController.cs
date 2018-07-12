using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;
using Blog.Domain;
using Blog.Domain.Entities.Repos;
using Blog.Infrastructure;
using Blog.AppLogic.DTO.Role;
using Blog.Domain.Entities;

namespace Blog.WebLayer.Controllers.WebApiControllers
{
    public class APIRoleController : ApiController
    {
        IRoleRepo repo = Container.DIContainer.Resolve<IRoleRepo>();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            Role img = repo.GetRole(Id);
            return Request.CreateResponse(HttpStatusCode.OK, img);
        }
        [HttpPost]
        public HttpResponseMessage Ins(RoleInsDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Create(dto.Name);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        [HttpGet]
        public HttpResponseMessage GetCol(int Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, repo.GetRole(Id));
        }
        [HttpPost]
        public HttpResponseMessage Edit(RoleEditionDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Update(dto.Id, dto.Name);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        [HttpPost]
        public HttpResponseMessage Delete(int Id)
        {
            using (repo)
                repo.Delete(Id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
