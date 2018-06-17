using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using Blog.AppLogic.DTO.Post;
using System.Data.Entity.Migrations;

namespace Blog.DataAccess.Entities.Repos
{
    class EFPostRepo : IPostRepo
    {
        private BlogDataContext context;
        public EFPostRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(PostInsDTO dto)
        {
            context.Posts.Add(new Post()
            {
                Content = dto.Content,
                Views = dto.Views,
                Rating = dto.Rating,
                UserId = dto.UserId
            });
        }

        public void Delete(int id)
        {
            context.Posts.Remove(context.Posts.Find(id));
        }

        public void Dispose()
        {
            context.SaveChanges();
        }

        public Post GetPost(int id)
        {
            return context.Posts.Find(id);
        }

        public List<Post> GetPosts(List<int> ids=null)
        {
            return ids == null ? context.Posts.ToList() :
               context.Posts.Where(x => ids.Exists(y => y == x.Id)).ToList();
        }

        public void Update(PostEditionDTO dto)
        {
            Post post = context.Posts.Find(dto.Id);
            if(String.IsNullOrEmpty(dto.Content))
                post.Content = dto.Content;
            if(dto.Views!=0)
                post.Views = dto.Views; 
            if (dto.Rating != 0)
                post.Rating = dto.Rating;
                
            context.Posts.AddOrUpdate(post);
        }
    }
}
