using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.Entity;
using System.Collections.Generic;
using MyBlogApp.BLL.Exceptions;
using MyBlogApp.DAL.Exceptions;
namespace MyBlogApp.BLL.ServiceImpl
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepo categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        public void AddCategory(Category category)
        {
            if (category == null)
                throw new ServiceNullArgumentException("Category was null");
            try
            {
                categoryRepo.AddCategory(category);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public void EditCategory(int id, Category newCategory)
        {
            if (newCategory == null)
                throw new ServiceNullArgumentException("category was null");
            try
            {
                categoryRepo.EditCategory(id, newCategory);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            

        }

        public IEnumerable<Category> GetCategories()
        {
            try
            {
                return categoryRepo.GetCategories();
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public Category GetCategory(int id)
        {
            try
            {
                return categoryRepo.GetCategory(id);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public void RemoveCategory(int id)
        {
            try
            {
                categoryRepo.RemoveCategory(id);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }
    }
}
