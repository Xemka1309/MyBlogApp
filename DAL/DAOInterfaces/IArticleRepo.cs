using MyBlogApp.DAL.Entity;
using MyBlogApp.DAL.Entity.Infrastructure;
namespace MyBlogApp.DAL.DAOInterfaces
{
    public interface IArticleRepo
    {
        PagedList<Article> GetArticles(ArticleQueryParameters parameters);
        void AddArticle(Article article);
        Article GetArticle(int id);
        void RemoveArticle(int id);
        void EditArticle(int oldArticleId, Article newArticle);
    }
}
