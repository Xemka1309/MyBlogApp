using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.BLL.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Tag> GetTags();
        Tag GetTag(int id);
        void AddTag(Tag tag);
        void RemoveTag(int id);
        void EditTag(int id, Tag newTag);
    }
}
