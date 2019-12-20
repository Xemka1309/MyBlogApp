using System;
using Microsoft.EntityFrameworkCore;
using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.Entity;
using MyBlogApp.DAL.Exceptions;
namespace MyBlogApp.DAL.EFImpl
{
    public class CategoryDAOEF : ICategoryRepo
    {
        private ApplicationDbContext dbContext;
        public CategoryDAOEF(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddCategory(Category category)
        {
            if (category == null)
                throw new NullArgumentDALException("Category was null");

            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }

        public void EditCategory(Category oldCategory, Category newCategory)
        {
            throw new NotImplementedException();
            dbContext.SaveChanges();
        }

        public Category[] GetCategories()
        {
            if (dbContext.Categories != null)
                return dbContext.Categories.ToArrayAsync().Result;
            else
                return new Category[0];
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCategory(int id)
        {
            throw new NotImplementedException();
            dbContext.SaveChanges();
        }

        public void RemoveCategory(Category category)
        {
            throw new NotImplementedException();
            dbContext.SaveChanges();
        }
    }
}
