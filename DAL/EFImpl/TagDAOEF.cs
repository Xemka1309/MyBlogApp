using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogApp.DAL.Exceptions;
namespace MyBlogApp.DAL.EFImpl
{
    public class TagDAOEF : ITagRepo
    {
        private ApplicationDbContext dbContext;
        public TagDAOEF(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddTag(Tag tag)
        {
            if (tag == null)
                throw new NullArgumentDALException("Tag was null");
            dbContext.Tags.Add(tag);
            dbContext.SaveChanges();
        }

        public void EditTag(int id, Tag newTag)
        {
            var oldTag = GetTag(id);
            oldTag.Value = newTag.Value;
            dbContext.SaveChanges();
        }

        public Tag GetTag(int id)
        {
            return dbContext.Tags.Where(t => t.Id == id).FirstOrDefault();
        }

        public IEnumerable<Tag> GetTags()
        {
            return dbContext.Tags;
        }

        public void RemoveTag(Tag tag)
        {
            dbContext.Tags.Remove(tag);
        }

        public void RemoveTag(int id)
        {
            RemoveTag(GetTag(id));
        }
    }
}
