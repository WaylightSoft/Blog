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
    public class EFUserRepo : IUserRepo
    {
        BlogDataContext context;
        public EFUserRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(string Nickname, string Bio, int RoleId,int UserCredentialsId)
        {
            context.Users.Add(new User()
            {
                Bio = Bio,
                Nickname = Nickname,
                RoleId = RoleId,
                UserCredentialsId = UserCredentialsId
            });
        }

        public void Delete(int id)
        {
            if(id>0)
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
        public User GetUser(string Nickname)
        {
            return context.Users.Where(x => x.Nickname == Nickname).First();
        }
        public List<User> GetUsers(List<int> ids = null)
        {
            return ids == null ? context.Users.ToList() :
              context.Users.Where(x => ids.Exists(y => y == x.Id)).ToList();
        }

        public void Update(int Id, string Nickname, string Bio, int RoleId)
        {
            User user =context.Users.Find(Id);
            user.Nickname = string.IsNullOrEmpty(Nickname) ? user.Nickname : Nickname;
            user.Bio = string.IsNullOrEmpty(Bio)?user.Bio:Bio;
            user.RoleId = RoleId==0?user.RoleId:RoleId;
            context.Users.AddOrUpdate(user);
        }
    }
}
