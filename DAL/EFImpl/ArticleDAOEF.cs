using Microsoft.EntityFrameworkCore;
using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.Entity;
using MyBlogApp.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.DAL.EFImpl
{
    public class ArticleDAOEF : IArticleRepo
    {
        private ApplicationDbContext dbContext;
        public ArticleDAOEF(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddArticle(Article article)
        {
            if (article == null)
                throw new NullArgumentDALException("article argument was null");
            if (article.ArticleTags == null)
                article.ArticleTags = new List<ArticleTag>();
            if (article.PublishTime == null)
                article.PublishTime = DateTime.Now;

            article.PublishTime = DateTime.Now;
            dbContext.Articles.Add(article);
            dbContext.Attach<Category>(article.Category);
            dbContext.SaveChanges();
        }

        public void EditArticle(int oldArticleId, Article newArticle)
        {
            var article = dbContext.Articles.Where(a => a.Id == oldArticleId).FirstOrDefault();
            article.Category = newArticle.Category;
            article.Content = newArticle.Content;
            article.Description = newArticle.Description;
            article.ArticleTags = newArticle.ArticleTags;
            article.Title = newArticle.Title;
            article.PicsUrl = newArticle.PicsUrl;
            
            newArticle.Id = oldArticleId;
            dbContext.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            return dbContext.Articles.Where(a => a.Id == id).FirstOrDefault();
        }
        public IEnumerable<Article> GetArticlesFiltered(String filterStr)
        {

            return null;
        }


        public PagedList<Article> GetArticles(ArticleQueryParameters parameters)
        {
            IEnumerable<Article> articles = dbContext.Articles.Include(a => a.Category).Include(a => a.ArticleTags);
            if (parameters.CategoryId != -1)
                articles = articles.Where(a => a.Category.Id == parameters.CategoryId);
            if (parameters.TitleContains?.Length != 0)
                articles = articles.Where(a => a.Title.Contains(parameters.TitleContains));
            return PagedList<Article>.ToPagedList(articles,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public void RemoveArticle(Article article)
        {
            try
            {
                dbContext.Articles.Remove(article);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DALException("Can't delete article" + ex.Message);
            }
            
        }

        public void RemoveArticle(int id)
        {
            RemoveArticle(GetArticle(id));
        }
    }
}
