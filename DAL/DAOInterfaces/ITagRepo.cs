using MyBlogApp.DAL.Entity;
using System.Collections.Generic;

namespace MyBlogApp.DAL.DAOInterfaces
{
    public interface ITagRepo
    {
        IEnumerable<Tag> GetTags();
        Tag GetTag(int id);
        void AddTag(Tag tag);
        void RemoveTag(int id);
        void EditTag(int id, Tag newTag);
        IEnumerable<Tag> GetTagsOfArticle(int articleId);

    }
}
