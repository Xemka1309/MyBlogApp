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
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DALException($"Can't add category {ex.Message}");
            }
        }

        public void EditCategory(int id, Category newCategory)
        {
            if (newCategory == null)
                throw new NullArgumentDALException("New category wass null");
            var oldCategory = dbContext.Categories.Where(c => c.Id == id).First();
            if (oldCategory == null)
                throw new DALException($"Can't find category with id {id}");
            oldCategory.Name = newCategory.Name;
            oldCategory.Description = newCategory.Description;
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DALException($"Can't edit category {ex.Message}");
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            try
            {
                return dbContext.Categories;
            }
            catch
            {
                throw new DALException("Can't get categories");
            }
            
        }

        public Category GetCategory(int id)
        {
            try
            {
                return dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
            }
            catch
            {
                throw new DALException($"Can't get category with id:{id}");
            }
            
        }

        public void RemoveCategory(int id)
        {
            RemoveCategory(GetCategory(id));
        }

        public void RemoveCategory(Category category)
        {
            dbContext.Categories.Remove(category);
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DALException($"Can't remove category {ex.Message}");
            }
        }
    }
}
