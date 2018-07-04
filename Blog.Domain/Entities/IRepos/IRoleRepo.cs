using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities.Repos
{
    public interface IRoleRepo:IDisposable
    {
        void Create(string Name);
        void Update(int Id,string Name);
        void Delete(int id);
        Role GetRole(int id);
        List<Role> GetRoles(List<int> ids = null);
    }
}
