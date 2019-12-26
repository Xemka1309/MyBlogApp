using MyBlogApp.DAL.Entity;
using MyBlogApp.DAL.Entity.Infrastructure;

namespace MyBlogApp.BLL.Interfaces
{
    public interface IArticleService
    {
        public PagedList<Article> GetArticles(ArticleQueryParameters parameters);
        public Article GetArticle(int id);
        public void RemoveArticle(int id);
        public void AddArticle(Article article);
        public void EditArticle(int id, Article newArticle);
        
    }
}
