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
        public void Create(string Content, int Rating, int Views,int UserId,string Title)
        {
            context.Posts.Add(new Post()
            {
                Content = Content,
                Views = Views,
                Rating = Rating,
                UserId = UserId,
                Title = Title
            });
        }

        public void Delete(int id)
        {
            if(id!=0)
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

        public List<Post> GetPosts(int PageNo, int TagId = 0, int UserId = 0)
        {
            List<Post> list = null;
            if (TagId == 0 && UserId == 0)
                list = context.Posts.Where(x => x.Id < PageNo * 5 && x.Id >= (PageNo - 1) * 5).ToList();
            else if (UserId != 00 && TagId != 0)
                list = context.Posts.Where(x => x.Id < PageNo * 5 && x.Id >= (PageNo - 1) * 5 && UserId == x.UserId &&
                  ((List<PostTag>)x.PostTags).Exists(y => y.Id == TagId)).ToList();
            else if (UserId != 0 && TagId == 0)
                list = context.Posts.Where(x => x.Id < PageNo * 5 && x.Id >= (PageNo - 1) * 5 && UserId == x.UserId).ToList();
            else if (UserId == 0 && TagId != 0)
                list = context.Posts.Where(x => x.Id < PageNo * 5 && x.Id >= (PageNo - 1) * 5 && ((List<PostTag>)x.PostTags).Exists(y => y.Id == TagId)).ToList();
            return list;
        }

        public void Update(int Id, string Content,  int Rating, int Views,string Title)
        {
            Post post = context.Posts.Find(Id);
            if (!String.IsNullOrEmpty(Content))
                post.Content = Content;
            if (Views != 0)
                post.Views = Views;
            if (Rating != 0)
                post.Rating = Rating;
            if (!String.IsNullOrEmpty(Content))
                post.Title = Title;

            context.Posts.AddOrUpdate(post);
        }
    }
}
