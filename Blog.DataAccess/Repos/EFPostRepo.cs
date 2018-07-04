using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using System.Data.Entity.Migrations;

namespace Blog.DataAccess.Entities.Repos
{
    public class EFPostRepo : IPostRepo
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
                Content = Content,
                Views = Views,
                Rating = Rating,
                UserId = UserId
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

        public void Update(int Id, string Content, int Views,float Rating )
        {
            Post post = context.Posts.Find(Id);
            if(String.IsNullOrEmpty(Content))
                post.Content = Content;
            if(Views!=0)
                post.Views = Views; 
            if (Rating != 0)
                post.Rating = Rating;
                
            context.Posts.AddOrUpdate(post);
        }
    }
}
