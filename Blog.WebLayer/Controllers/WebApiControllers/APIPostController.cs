using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog.AppLogic.DTO.Post;
using Blog.Domain.Entities;
using Blog.Infrastructure;
using Blog.Domain.Entities.Repos;
using Unity;


namespace Blog.WebLayer.Controllers
{
    public class APIPostController : ApiController
    {
        IPostRepo repo = Container.DIContainer.Resolve<IPostRepo>();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            Post post = repo.GetPost(Id);
            return Request.CreateResponse(HttpStatusCode.OK, post);
        }
        [HttpPost]
        public HttpResponseMessage Ins(PostInsDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Create(dto.Content, dto.Rating, dto.Views, dto.UserId,dto.Title);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        [HttpGet]
        public HttpResponseMessage GetCol(int pageNo, int TagId, int UserId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, repo.GetPosts(pageNo, TagId, UserId).ToList());
        }
        [HttpPost]
        public HttpResponseMessage Edit(PostEditionDTO dto)
        {
            if (dto != null)
            {
                using (repo)
                    repo.Update(dto.Id, dto.Content, dto.Rating, dto.Views,dto.Title);
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
