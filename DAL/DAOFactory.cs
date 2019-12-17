using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.EFImpl;
namespace MyBlogApp.DAL
{
    public class DAOFactory
    {
        private ApplicationDbContext dbContext;
        private ICategoryRepo categoryRepo;
        private IArticleRepo articleRepo;
        private ITagRepo tagRepo;
        public DAOFactory(ApplicationDbContext applicationDbContext, ICategoryRepo categoryRepo)
        {
            this.dbContext = applicationDbContext;
            this.categoryRepo = categoryRepo;
        }
        public ICategoryRepo GetCategoryRepo()
        {
            return categoryRepo;
        }
        public IArticleRepo GetArticleRepo()
        {
            return articleRepo;
        }
        public ITagRepo GetTagRepo()
        {
            return tagRepo;
        }
        
    }
}
