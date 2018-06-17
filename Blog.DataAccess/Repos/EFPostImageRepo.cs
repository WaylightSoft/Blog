using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using Blog.AppLogic.DTO.PostImage;
using System.Data.Entity.Migrations;

namespace Blog.DataAccess.Entities.Repos
{
    class EFPostImageRepo : IPostImageRepo
    {
        private BlogDataContext context;

        public EFPostImageRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(PostImageInsDTO dto)
        {
            this.context.PostImages.Add(new PostImage()
            {
                ImageId = dto.ImageId,
                PostId = dto.PostId,
                ImageNumber = dto.ImageNumber
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

        public void Update(PostImageEditionDTO dto)
        {
            PostImage postImage = context.PostImages.Find(dto.Id);
            if(dto.ImageId!=0)
                postImage.ImageId = dto.ImageId;
            postImage.ImageNumber = dto.ImageNumber != 0 ? dto.ImageNumber:postImage.ImageNumber;

            context.PostImages.AddOrUpdate(postImage);
        }
    }
}
