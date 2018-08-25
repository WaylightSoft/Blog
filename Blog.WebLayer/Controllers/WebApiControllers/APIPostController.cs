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
using Blog.AppLogic.DTO.Tag;

namespace Blog.WebLayer.Controllers
{
    public class APIPostController : ApiController
    {
        IPostRepo repo = Container.DIContainer.Resolve<IPostRepo>();
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            Post i= repo.GetPost(Id); 
            PostDTO dto = new PostDTO()
            {
                Rating = Convert.ToInt32(i.Rating),
                Title = i.Title,
                Views = Convert.ToInt32(i.Views),
                Id = i.Id,
                Content = i.Content
            }; 
            return Request.CreateResponse(HttpStatusCode.OK, dto);
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
        [Route("api/APIPost/GetCol/{pageNo}/{TagId}/{UserId}")]
        [HttpGet]
        public HttpResponseMessage GetCol(int pageNo, int TagId, int UserId)
        {
            List<PostDTO> list= new List<PostDTO>();
            foreach (var i in repo.GetPosts(pageNo, TagId, UserId))
            {
                PostDTO item= new PostDTO()
                {
                    Rating = Convert.ToInt32(i.Rating),
                    Title = i.Title,
                    Views = Convert.ToInt32(i.Views),
                    Id = i.Id,
                    Content = i.Content
                };
                foreach (var tag in i.PostTags)
                {
                    item.Tags.Add(new TagEditionDTO()
                    {
                        Id = tag.TagId,
                        Name = tag.Tag.Name
                    });
                    //item.TagsString += tag.Tag.Name + "*" + tag.TagId+"*";
                }
                //item.Tagarr = item.Tags.ToArray();
                list.Add(item); 
            }
            return Request.CreateResponse(HttpStatusCode.OK, list);
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
        //[HttpGet]
        //public HttpResponseMessage GetAnnotationForPosts(int pageNo, int TagId, int UserId)
        //{
        //    repo.GetPosts(pageNo, TagId, UserId).ToList()
        //    return Request.CreateResponse(HttpStatusCode.OK, );
        //}

    }
}
