using MyBlogApp.DAL.Entity;
using MyBlogApp.DAL.Entity.Infrastructure;
using System.Collections.Generic;

namespace MyBlogApp.DAL.DAOInterfaces
{
    public interface IArticleRepo
    {
        PagedList<Article> GetArticles(ArticleQueryParameters parameters);
        void AddArticle(Article article);
        Article GetArticle(int id);
        void RemoveArticle(int id);
        void EditArticle(int oldArticleId, Article newArticle);
        void AddComment(int articleId, ArticleComment comemnt);
        List<ArticleComment> GetComments(int articleId);
    }
}
