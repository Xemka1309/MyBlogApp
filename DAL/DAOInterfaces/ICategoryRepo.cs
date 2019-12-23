using MyBlogApp.DAL.Entity;
using System.Collections.Generic;

namespace MyBlogApp.DAL.DAOInterfaces
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void RemoveCategory(int id);
        void EditCategory(int id, Category newCategory);
        
    }
}
