using MyBlogApp.DAL.Entity;

namespace MyBlogApp.DAL.DAOInterfaces
{
    public interface ITagRepo
    {
        Tag[] GetTags();
        Tag GetTag(int id);
        void AddTag(Tag tag);
        void RemoveTag(Tag tag);
        void RemoveTag(int id);
        void EditTag(Tag oldTag, Tag newTag);
    }
}
