using System;
using System.Collections.Generic;
using System.Linq;
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

        public void EditCategory(int id, Category newCategory)
        {
            var oldCategory = dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
            oldCategory.Name = newCategory.Name;
            oldCategory.Description = newCategory.Description;
            dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            if (dbContext.Categories != null)
                return dbContext.Categories.ToArrayAsync().Result;
            else
                return new Category[0];
        }

        public Category GetCategory(int id)
        {
            return dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public void RemoveCategory(int id)
        {
            RemoveCategory(GetCategory(id));
        }

        public void RemoveCategory(Category category)
        {
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }
    }
}
