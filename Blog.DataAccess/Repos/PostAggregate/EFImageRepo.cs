using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using Blog.Domain;
using System.Data.Entity.Migrations;


namespace Blog.DataAccess.Entities.Repos
{
    public class EFImageRepo : IImageRepo
    {
        private BlogDataContext context;

        public EFImageRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public EFImageRepo()
        {
            this.context = new BlogDataContext();
        }
        public void Create(string Path)
        {
            context.Images.Add(new Image()
            {
                Path = Path
            });
        }

        public void Delete(int id)
        {
            if (id> 0)
            {
                Image img = context.Images.Find(id);
                context.Images.Remove(img);
            }
        }

        public void Update(int Id,string Path)
        {

            if (!string.IsNullOrEmpty(Path))
            {
                Image img = context.Images.Find(Id);
                img.Path = Path;
                context.Images.AddOrUpdate(img);
            }
        }


        public Image GetImage(int id)
        {
            return context.Images.Find(id);
        }

        public List<Image> GetImages(int PostId)
        {
            return context.Images.Where(x => x.PostImages.First().PostId==PostId).ToList();
        }

        
        public void Dispose()
        {
            context.SaveChanges();
        }
    }
}
