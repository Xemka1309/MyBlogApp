using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogApp.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Tag> GetTagsOfArticle(int articleId)
        {
            var result = new List<Tag>();
            if (dbContext.Articles.Where(a => a.Id == articleId).Count() != 1)
                return result;
            var articleTags = dbContext.Articles.Include(a => a.ArticleTags).Where(a => a.Id == articleId).First()?.ArticleTags;
            if (articleTags == null)
                return result;
            foreach (var artTag in articleTags)
            {
                result.AddRange(dbContext.Tags.Where(t => t.Id == artTag.TagId));
            }
            return result;
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
