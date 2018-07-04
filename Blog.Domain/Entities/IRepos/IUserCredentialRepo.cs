using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities.Repos
{
    public interface IUserCredentialRepo : IDisposable
    {
        void Create(string Login, string Password);
        void Update(int Id, string Password);
        void Delete(int id);
        UserCredential GetUserCredential(int id);
        List<UserCredential> GetUserCredentials(List<int> ids = null);
    }
}
