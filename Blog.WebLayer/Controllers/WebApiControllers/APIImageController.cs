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
using Blog.AppLogic.DTO.Image;
namespace Blog.WebLayer.Controllers.WebApiControllers
{
    public class APIImageController : ApiController
    {
        IImageRepo repo = Container.DIContainer.Resolve<IImageRepo>();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            Image img = repo.GetImage(Id);
            return Request.CreateResponse(HttpStatusCode.OK, img);
        }
        [HttpPost]
        public HttpResponseMessage Ins(ImageInsDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Create(dto.Path);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        [HttpGet]
        public HttpResponseMessage GetCol(int PostId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, repo.GetImages(PostId);
        }
        [HttpPost]
        public HttpResponseMessage Edit(ImageEditionDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Update(dto.Id, dto.Path);
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