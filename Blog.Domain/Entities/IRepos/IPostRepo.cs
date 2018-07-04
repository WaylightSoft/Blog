using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities.Repos
{
    public interface IPostRepo : IDisposable
    {
        void Create(string Content,float Rating,int Views,int UserId);
        void Update(int Id, string Content, float Rating, int Views);
        void Delete(int id);
        Post GetPost(int id);
        List<Post> GetPosts(List<int> ids = null);
    }
}
