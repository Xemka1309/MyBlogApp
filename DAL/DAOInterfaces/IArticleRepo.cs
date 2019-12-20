using MyBlogApp.DAL.Entity;
using System.Collections.Generic;

namespace MyBlogApp.DAL.DAOInterfaces
{
    public interface IArticleRepo
    {
        IEnumerable<Article> GetArticles();
        void AddArticle(Article article);
        void RemoveArticle(Article article);
        void GetArticle(int id);
        void RemoveArticle(int id);
        void EditArticle(Article oldArticle, Article newArticle);
    }
}
