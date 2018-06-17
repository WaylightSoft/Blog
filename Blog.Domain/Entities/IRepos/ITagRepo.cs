using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.AppLogic.DTO.Tag; 

namespace Blog.Domain.Entities.Repos
{
    public interface ITagRepo:IDisposable
    {
        void Create(TagInsDTO dto);
        void Update(TagEditionDTO dto);
        void Delete(int id);
        Tag GetTag(int id);
        List<Tag> GetTags(List<int> ids = null);
    }
}
