using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.AppLogic.DTO.PostImage;

namespace Blog.Domain.Entities.Repos
{
    public interface IPostImageRepo:IDisposable
    {
        void Create(PostImageInsDTO dto);
        void Update(PostImageEditionDTO dto);
        void Delete(int id);
        PostImage GetPostImage(int id);
        List<PostImage> GetPostImages(List<int> ids = null);
    }
}
