using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities.Repos
{
    public interface IPostRepo : IDisposable
    {
        void Create(string Content,int Rating,int Views,int UserId,string Title);
        void Update(int Id, string Content, int Rating, int Views,string Title);
        void Delete(int id);
        Post GetPost(int id);
        List<Post> GetPosts(int PageNo,int TagId=0,int UserId=0);
    }
}
