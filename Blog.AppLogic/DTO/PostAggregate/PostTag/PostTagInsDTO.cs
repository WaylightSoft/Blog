using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AppLogic.DTO.PostTag
{
    public class PostTagInsDTO
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int TagId { get; set; }
    }
}
