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
    public class EFRoleRepo : IRoleRepo
    {
        BlogDataContext context;
        public EFRoleRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(string Name)
        {
            context.Roles.Add(new Role()
            {
                Name = Name
            });
        }

        public void Delete(int id)
        {
            if(id>0)
            context.Roles.Remove(context.Roles.Find(id));
        }

        public void Dispose()
        {
            context.SaveChanges();
        }

        public Role GetRole(int id)
        {
            return context.Roles.Find(id);
        }

        public List<Role> GetRoles(List<int> ids = null)
        {
            return ids == null ? context.Roles.ToList() :
              context.Roles.Where(x => ids.Exists(y => y == x.Id)).ToList();
        }

        public void Update(int Id,string Name)
        {
            if (!string.IsNullOrEmpty(Name))
                context.Roles.AddOrUpdate(new Role()
                {
                    Id = Id,
                    Name = Name
                });
        }
    }
}
