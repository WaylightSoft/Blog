using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using Blog.AppLogic.DTO.Role;
using System.Data.Entity.Migrations;

namespace Blog.DataAccess.Entities.Repos
{
    class EFRoleRepo : IRoleRepo
    {
        BlogDataContext context;
        public EFRoleRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(RoleInsDTO dto)
        {
            context.Roles.Add(new Role()
            {
                Name = dto.Name
            });
        }

        public void Delete(int id)
        {
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

        public void Update(RoleEditionDTO dto)
        {
            if (!string.IsNullOrEmpty(dto.Name))
            {

                context.Roles.AddOrUpdate(new Role()
                {
                    Id = dto.Id,
                    Name = dto.Name
                });
            }
        }
    }
}
