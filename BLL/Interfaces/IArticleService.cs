using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogApp.DAL.Entity;
namespace MyBlogApp.BLL.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticlesFiltered(String filterStr);
        public PagedList<Article> GetArticles(ArticleQueryParameters parameters);
        public Article GetArticle(int id);
        public void RemoveArticle(int id);
        public void AddArticle(Article article);
        public void EditArticle(int id, Article newArticle);
        
    }
}
