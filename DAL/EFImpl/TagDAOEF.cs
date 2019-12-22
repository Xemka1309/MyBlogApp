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

        public void EditTag(Tag oldTag, Tag newTag)
        {
            throw new NotImplementedException();
        }

        public Tag GetTag(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetTags()
        {
            return dbContext.Tags;
        }

        public void RemoveTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void RemoveTag(int id)
        {
            throw new NotImplementedException();
        }
    }
}
