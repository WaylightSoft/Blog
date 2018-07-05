using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities.Repos
{
    public interface IPostImageRepo:IDisposable
    {
        void Create(int PostId, int ImageId,int  ImageNumber=0);
        void Update(int Id, int ImageId, int ImageNumber);
        void Delete(int id);
        PostImage GetPostImage(int id);
        List<PostImage> GetPostImages(int PostId);
    }
}
