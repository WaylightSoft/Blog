using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.AppLogic.DTO.UserCredentials;

namespace Blog.Domain.Entities.Repos
{
    public interface IUserCredentialRepo:IDisposable
    {
        void Create(UserCredentialsInsDTO dto );
        void Update(UserCredentialsEditionDTO dto);
        void Delete(int id);
        UserCredential GetUserCredential(int id);
        List<UserCredential> GetUserCredentials(List<int> ids = null);
    }
}
