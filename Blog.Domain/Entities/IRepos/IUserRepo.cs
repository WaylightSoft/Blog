using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.AppLogic.DTO.User;

namespace Blog.Domain.Entities.Repos
{
    public interface IUserRepo:IDisposable
    {
        void Create(UserInsDTO dto);
        void Update(UserEditionDTO dto);
        void Delete(int id);
        User GetUser(int id);
        List<User> GetUsers(List<int> ids = null);
    }
}
