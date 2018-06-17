using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using System.Data.Entity.Migrations;
using Blog.AppLogic.DTO.User;

namespace Blog.DataAccess.Entities.Repos
{
    class EFUserRepo : IUserRepo
    {
        BlogDataContext context;
        public EFUserRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(UserInsDTO dto)
        {
            context.Users.Add(new User()
            {
                Bio = dto.Bio,
                Nickname = dto.Nickname,
                RoleId = dto.RoleId,
                UserCredentialsId = dto.UserCredentialsId
            });
        }

        public void Delete(int id)
        {
            context.Users.Remove(context.Users.Find(id));
        }

        public void Dispose()
        {
            context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public List<User> GetUsers(List<int> ids = null)
        {
            return ids == null ? context.Users.ToList() :
              context.Users.Where(x => ids.Exists(y => y == x.Id)).ToList();
        }

        public void Update(UserEditionDTO dto)
        {
            User user =context.Users.Find(dto.Id);
            user.Nickname = string.IsNullOrEmpty(dto.Nickname) ? user.Nickname : dto.Nickname;
            user.Bio = string.IsNullOrEmpty(dto.Bio)?user.Bio:dto.Bio;
            user.RoleId = dto.RoleId==0?user.RoleId:dto.RoleId;
            context.Users.AddOrUpdate(user);
        }
    }
}
