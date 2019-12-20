using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.BLL.Interfaces
{
    public interface ITagService
    {
        Tag[] GetTags();
        Tag GetTag(int id);
        void AddTag(Tag tag);
        void RemoveTag(Tag tag);
        void RemoveTag(int id);
        void EditTag(Tag oldTag, Tag newTag);
    }
}
