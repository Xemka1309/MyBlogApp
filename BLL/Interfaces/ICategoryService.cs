using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void RemoveCategory(int id);
        void EditCategory(int id, Category newCategory);
    }
}
