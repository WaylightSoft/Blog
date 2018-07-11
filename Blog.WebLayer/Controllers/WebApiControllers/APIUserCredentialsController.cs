using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;
using Blog.Domain.Entities;
using Blog.Domain.Entities.Repos;
using Blog.Infrastructure;
using Blog.AppLogic.DTO.UserCredentials;

namespace Blog.WebLayer.Controllers.WebApiControllers
{
    public class APIUserCredentialsController : ApiController
    {
        IUserCredentialRepo repo = Container.DIContainer.Resolve<IUserCredentialRepo>();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            UserCredential img = repo.GetUserCredential(Id);
            return Request.CreateResponse(HttpStatusCode.OK, img);
        }
        [HttpPost]
        public HttpResponseMessage Ins(UserCredentialsInsDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Create(dto.Login, dto.Password);
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
        public HttpResponseMessage Edit(UserCredentialsEditionDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Update(dto.Id,dto.Password);
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
