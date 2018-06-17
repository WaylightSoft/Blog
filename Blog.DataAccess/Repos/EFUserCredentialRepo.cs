using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using System.Data.Entity.Migrations;
using Blog.AppLogic.DTO.UserCredentials;

namespace Blog.DataAccess.Entities.Repos
{
    class EFUserCredentialRepo : IUserCredentialRepo
    {
        BlogDataContext context;

        public EFUserCredentialRepo(BlogDataContext context)
        {
            this.context = context;
        }
        public void Create(UserCredentialsInsDTO dto)
        {

            context.UserCredentials.Add(new UserCredential()
            {
                Login = dto.Login,
                Password = dto.Password
            });
        }

        public void Delete(int id)
        {
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

        public void Update(UserCredentialsEditionDTO dto)
        {

            if (!string.IsNullOrEmpty(dto.Password))
            {
                UserCredential userCredential = context.UserCredentials.Find(dto.Id);
                userCredential.Password = dto.Password;
                context.UserCredentials.AddOrUpdate(userCredential);
            }

            
        }
    }
}
