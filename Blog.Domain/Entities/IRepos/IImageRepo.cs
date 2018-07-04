using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Blog.Domain.Entities.Repos
{
    public  interface IImageRepo: IDisposable
    {
        void Create(string Path);
        void Update(int Id, string Path);
        void Delete(int id);
        Image GetImage(int id);
        List<Image> GetImages(List<int> ids = null);

    }
}
