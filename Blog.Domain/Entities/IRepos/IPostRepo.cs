using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.AppLogic.DTO.Post;

namespace Blog.Domain.Entities.Repos
{
    public interface IPostRepo:IDisposable
    {
        void Create(PostInsDTO dto);
        void Update(PostEditionDTO dto);
        void Delete(int id);
        Post GetPost(int id);
        List<Post> GetPosts(List<int> ids = null);
    }
}
