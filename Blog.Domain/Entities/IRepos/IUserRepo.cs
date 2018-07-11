using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities;

namespace Blog.Domain.Entities.Repos
{
    public interface IUserRepo : IDisposable
    {
        void Create(string Nickname, string Bio, int RoleId, int UserCredentialsId);
        void Update(int Id,string Nickname, string Bio, int RoleId);
        void Delete(int id);
        User GetUser(int id);
        List<User> GetUsers(List<int> ids = null);
    }
}
