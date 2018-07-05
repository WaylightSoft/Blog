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
    public class EFUserCredentialRepo : IUserCredentialRepo
    {
        BlogDataContext context;

        public EFUserCredentialRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(string Login,string Password)
        {

            context.UserCredentials.Add(new UserCredential()
            {
                Login = Login,
                Password = Password
            });
        }

        public void Delete(int id)
        {
            if(id>0)
            this.context.UserCredentials.Remove(context.UserCredentials.Find(id));
        }

        public void Dispose()
        {
            context.SaveChanges();
        }

        public UserCredential GetUserCredential(int id)
        {
            return context.UserCredentials.Find(id);
        }

        public List<UserCredential> GetUserCredentials(List<int> ids = null)
        {
            return ids == null ? context.UserCredentials.ToList() :
             context.UserCredentials.Where(x => ids.Exists(y => y == x.Id)).ToList();
        }

        public void Update(int Id,string Password)
        {

            if (!string.IsNullOrEmpty(Password))
            {
                UserCredential userCredential = context.UserCredentials.Find(Id);
                userCredential.Password = Password;
                context.UserCredentials.AddOrUpdate(userCredential);
            }

            
        }
    }
}
