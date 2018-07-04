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
    public class EFPostImageRepo : IPostImageRepo
    {
        private BlogDataContext context;

        public EFPostImageRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(int ImageId,int PostId,int ImageNumber)
        {
            this.context.PostImages.Add(new PostImage()
            {
                ImageId = ImageId,
                PostId = PostId,
                ImageNumber = ImageNumber
            });
        }

        public void Delete(int id)
        {
            this.context.PostImages.Remove(context.PostImages.Find(id));
        }

        public void Dispose()
        {
            this.context.SaveChanges();
        }

        public PostImage GetPostImage(int id)
        {
            return this.context.PostImages.Find(id);
        }

        public List<PostImage> GetPostImages(List<int> ids = null)
        {
            return ids == null ? context.PostImages.ToList() :
          context.PostImages.Where(x => ids.Exists(y => y == x.Id)).ToList();
        }

        public void Update(int Id, int ImageId, int ImageNumber=0)
        {
            PostImage postImage = context.PostImages.Find(Id);
            if(ImageId!=0)
                postImage.ImageId = ImageId;
            postImage.ImageNumber = ImageNumber != 0 ? ImageNumber:postImage.ImageNumber;

            context.PostImages.AddOrUpdate(postImage);
        }
    }
}
