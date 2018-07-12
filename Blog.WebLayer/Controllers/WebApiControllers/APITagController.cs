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
using Blog.AppLogic.DTO.Tag;
using Blog.Domain.Entities;

namespace Blog.WebLayer.Controllers.WebApiControllers
{
    public class APITagController : ApiController
    {
        ITagRepo repo = Container.DIContainer.Resolve<ITagRepo>();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            Tag img = repo.GetTag(Id);
            return Request.CreateResponse(HttpStatusCode.OK, img);
        }
        [HttpPost]
        public HttpResponseMessage Ins(TagInsDTO dto)
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
            return Request.CreateResponse(HttpStatusCode.OK, repo.GetTag(Id));
        }
        [HttpPost]
        public HttpResponseMessage Edit(TagEditionDTO dto)
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
