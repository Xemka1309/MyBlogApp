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

            categoryRepo.AddCategory(category);
        }

        public void EditCategory(int id, Category newCategory)
        {
            if (newCategory == null)
                throw new ServiceNullArgumentException("category was null");
            
            categoryRepo.EditCategory(id, newCategory);

        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepo.GetCategories();
        }

        public Category GetCategory(int id)
        {
            return categoryRepo.GetCategory(id);
        }

        public void RemoveCategory(int id)
        {
            categoryRepo.RemoveCategory(id);
        }
    }
}
