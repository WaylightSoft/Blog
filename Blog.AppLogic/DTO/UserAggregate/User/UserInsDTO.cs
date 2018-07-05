using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AppLogic.DTO.User
{
    public class UserInsDTO
    {
        public string Nickname { get; set; }

        public string Bio { get; set; }

        public int RoleId { get; set; }

        public int UserCredentialsId { get; set; }
    }
}
