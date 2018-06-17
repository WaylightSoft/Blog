using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using Blog.AppLogic.DTO.Tag;
using System.Data.Entity.Migrations;

namespace Blog.DataAccess.Entities.Repos
{
    class EFTagRepo : ITagRepo
    {
        BlogDataContext context;
        public EFTagRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(TagInsDTO dto)
        {
            this.context.Tags.Add(new Tag()
            {
                Name = dto.Name
            });
        }

        public void Delete(int id)
        {
            this.context.Tags.Remove(context.Tags.Find(id));
        }

        public void Dispose()
        {
            context.SaveChanges();   
        }

        public Tag GetTag(int id)
        {
            return context.Tags.Find(id);
        }

        public List<Tag> GetTags(List<int> ids = null)
        {
            return ids == null ? context.Tags.ToList() :
             context.Tags.Where(x => ids.Exists(y => y == x.Id)).ToList();
        }

        public void Update(TagEditionDTO dto)
        {
           
            if (!string.IsNullOrEmpty(dto.Name))
            {
                context.Tags.AddOrUpdate(new Tag()
                {
                    Id = dto.Id,
                    Name = dto.Name
                });
            }
        }
    }
}
