using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.Entity;
using MyBlogApp.DAL.Exceptions;
using System.Collections.Generic;
using MyBlogApp.BLL.Exceptions;

namespace MyBlogApp.BLL.ServiceImpl
{
    public class TagService : ITagService
    {
        private ITagRepo tagRepo;
        public TagService(ITagRepo tagRepo)
        {
            this.tagRepo = tagRepo;
        }
        public void AddTag(Tag tag)
        {
            if (tag == null)
                throw new ServiceNullArgumentException("Tag was null");
            try
            {
                this.tagRepo.AddTag(tag);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public void EditTag(int id, Tag newTag)
        {
            if (newTag == null)
                throw new ServiceNullArgumentException("Tag was null (in edit method)");
            try
            {
                tagRepo.EditTag(id, newTag);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public Tag GetTag(int id)
        {
            try
            {
                return tagRepo.GetTag(id);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public IEnumerable<Tag> GetTags()
        {
            try
            {
                return this.tagRepo.GetTags();
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
           
        }

        public IEnumerable<Tag> GetTagsOfArticle(int articleId)
        {
            try
            {
                return tagRepo.GetTagsOfArticle(articleId);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public void RemoveTag(int id)
        {
            try
            {
                tagRepo.RemoveTag(id);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

    }
}
