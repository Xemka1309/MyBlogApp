using MyBlogApp.DAL.Entity;

namespace MyBlogApp.DAL.DAOInterfaces
{
    public interface ICategoryRepo
    {
        Category[] GetCategories();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void RemoveCategory(int id);
        void EditCategory(Category oldCategory, Category newCategory);
        
    }
}
