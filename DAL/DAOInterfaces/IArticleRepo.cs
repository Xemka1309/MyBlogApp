using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
namespace MyBlogApp.DAL.DAOInterfaces
{
    public interface IArticleRepo
    {
        PagedList<Article> GetArticles(ArticleQueryParameters parameters);
        void AddArticle(Article article);
        void RemoveArticle(Article article);
        void GetArticle(int id);
        void RemoveArticle(int id);
        void EditArticle(Article oldArticle, Article newArticle);
        IEnumerable<Article> GetArticlesFiltered(String filterStr);
    }
}
