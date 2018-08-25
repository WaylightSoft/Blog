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
using Blog.AppLogic.DTO.User;
using Blog.Domain.Entities;

namespace Blog.WebLayer.Controllers.WebApiControllers
{
    public class APIUserController : ApiController
    {
        IUserRepo repo = Container.DIContainer.Resolve<IUserRepo>();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            User img = repo.GetUser(Id);
            return Request.CreateResponse(HttpStatusCode.OK, img);
        }
        [Route("api/APIUser/GetId/{nick}")]
        [HttpGet]
        public HttpResponseMessage GetId(string nick)
        {   
            return Request.CreateResponse(HttpStatusCode.OK, repo.GetUser(nick).Id);
        }
        [HttpPost]
        public HttpResponseMessage Ins(UserInsDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Create(dto.Nickname,dto.Bio,dto.RoleId,dto.UserCredentialsId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        [HttpGet]
        public HttpResponseMessage GetCol(int Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        public HttpResponseMessage Edit(UserEditionDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Update(dto.Id,dto.Nickname,dto.Bio,dto.RoleId);
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
