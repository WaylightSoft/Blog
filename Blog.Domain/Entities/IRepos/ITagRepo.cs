using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities.Repos
{
    public interface ITagRepo:IDisposable
    {
        void Create(string Name);
        void Update(int Id, string Name);
        void Delete(int id);
        Tag GetTag(int id);
        List<Tag> GetTags(List<int> ids = null);
    }
}
