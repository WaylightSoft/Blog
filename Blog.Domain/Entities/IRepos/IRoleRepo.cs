using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.AppLogic.DTO.Role;

namespace Blog.Domain.Entities.Repos
{
    public interface IRoleRepo:IDisposable
    {
        void Create(RoleInsDTO dto);
        void Update(RoleEditionDTO dto);
        void Delete(int id);
        Role GetRole(int id);
        List<Role> GetRoles(List<int> ids = null);
    }
}
