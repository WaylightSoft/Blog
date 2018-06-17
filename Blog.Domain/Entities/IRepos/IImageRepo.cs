using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.AppLogic.DTO.Image;
namespace Blog.Domain.Entities.Repos
{
    public  interface IImageRepo: IDisposable
    {
        void Create(ImageInsDTO dto);
        void Update(ImageEditionDTO dto);
        void Delete(int id);
        Image GetImage(int id);
        List<Image> GetImages(List<int> ids = null);

    }
}
