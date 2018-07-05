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
    public class EFTagRepo : ITagRepo
    {
        BlogDataContext context;
        public EFTagRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(string Name)
        {
            this.context.Tags.Add(new Tag()
            {
                Name = Name
            });
        }

        public void Delete(int id)
        {
            if(id>0)
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

        public void Update(int Id,string Name)
        {
           
            if (!string.IsNullOrEmpty(Name))
            {
                context.Tags.AddOrUpdate(new Tag()
                {
                    Id = Id,
                    Name = Name
                });
            }
        }
    }
}
