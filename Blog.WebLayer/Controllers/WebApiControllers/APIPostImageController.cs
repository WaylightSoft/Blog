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
using Blog.AppLogic.DTO.PostImage;

namespace Blog.WebLayer.Controllers.WebApiControllers
{
    public class APIPostImageController : ApiController
    {
        IPostImageRepo repo = Container.DIContainer.Resolve<IPostImageRepo>();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            PostImage img = repo.GetPostImage(Id);
            return Request.CreateResponse(HttpStatusCode.OK, img);
        }
        [HttpPost]
        public HttpResponseMessage Ins(PostImageInsDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Create(dto.PostId,dto.ImageId,dto.ImageNumber);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        [HttpGet]
        public HttpResponseMessage GetCol(int Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, repo.GetPostImages(Id));
        }
        [HttpPost]
        public HttpResponseMessage Edit(PostImageEditionDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Update(dto.Id,dto.ImageId, dto.ImageNumber);
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
