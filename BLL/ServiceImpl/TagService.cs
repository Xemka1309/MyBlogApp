using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            this.tagRepo.AddTag(tag);
        }

        public void EditTag(int id, Tag newTag)
        {
            if (newTag == null)
                throw new ServiceNullArgumentException("Tag was null (in edit method)");
            tagRepo.EditTag(id,newTag);
        }

        public Tag GetTag(int id)
        {
            return tagRepo.GetTag(id);
        }

        public IEnumerable<Tag> GetTags()
        {
            return this.tagRepo.GetTags();
           
        }

        public void RemoveTag(int id)
        {
            tagRepo.RemoveTag(id);
        }

    }
}
