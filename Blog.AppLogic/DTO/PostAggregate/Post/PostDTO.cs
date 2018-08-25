using Blog.AppLogic.DTO.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AppLogic.DTO.Post
{
    public class PostDTO
    {
        public int Id { get; set; }
        public int Rating {get;set;}
        public string Title { get; set; }
        public int Views { get; set; }
        public string Content { get; set; }
        public List<TagEditionDTO> Tags { get; set; }
        //public string TagsString { get; set; }
        //public TagEditionDTO[] Tagarr { get; set; }
        public PostDTO()
        {
            Tags = new List<TagEditionDTO>();
        }
        //public static implicit operator PostEditionDTO(PostDTO dto)
        //{
        //    return new PostEditionDTO() { };
        //}
        //public static implicit operator PostDTO(PostEditionDTO dto)
        //{
        //    return new PostDTO();
        //}
    }

}
