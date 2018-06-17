using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using Blog.Domain;
using System.Data.Entity.Migrations;
using Blog.AppLogic.DTO.Image;

namespace Blog.DataAccess.Entities.Repos
{
    class EFImageRepo : IImageRepo
    {
        private BlogDataContext context;
        public EFImageRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(ImageInsDTO dto)
        {
            context.Images.Add(new Image()
            {
                Path = dto.Path
            });
        }

        public void Delete(int id)
        {
            Image img = context.Images.Find(id);
            context.Images.Remove(img);
        }

        public void Update(ImageEditionDTO dto)
        {

            if (!string.IsNullOrEmpty(dto.Path))
            {
                Image img = context.Images.Find(dto.Id);
                img.Path = dto.Path;
                context.Images.AddOrUpdate(img);
            }
        }


        public Image GetImage(int id)
        {
            return context.Images.Find(id);
        }

        public List<Image> GetImages(List<int> ids=null)
        {
            return ids==null? context.Images.ToList() :
                context.Images.Where(x => ids.Exists(y=>y==x.Id)).ToList();
        }

        
        public void Dispose()
        {
            context.SaveChanges();
        }
    }
}
