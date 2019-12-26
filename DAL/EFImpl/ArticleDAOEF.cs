using Microsoft.EntityFrameworkCore;
using MyBlogApp.DAL.DAOInterfaces;
using MyBlogApp.DAL.Entity;
using MyBlogApp.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using MyBlogApp.DAL.Entity.Infrastructure;

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
                throw new NullArgumentDALException("Article argument was null");

            if (article.ArticleTags == null)
                article.ArticleTags = new List<ArticleTag>();

            article.PublishTime = DateTime.Now;
            dbContext.Articles.Add(article);
            dbContext.Attach<Category>(article.Category);
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DALException($"Error while updating db {ex.Message}");
            }

        }
        public void EditArticle(int oldArticleId, Article newArticle)
        {
            if (newArticle == null)
                throw new NullArgumentDALException("New article was null");
            var article = dbContext.Articles.Where(a => a.Id == oldArticleId).Include(a => a.ArticleTags).First();
            if (article == null)
                throw new DALException($"Can't find article with id:{oldArticleId}");

            article.Category = newArticle.Category;
            article.Content = newArticle.Content;
            article.Description = newArticle.Description;
            article.Title = newArticle.Title;
            article.PicsUrl = newArticle.PicsUrl;
            
            newArticle.Id = oldArticleId;
            if (article.ArticleTags == newArticle.ArticleTags)
            {
                foreach (var item in article.ArticleTags)
                {
                    dbContext.Attach<ArticleTag>(item);
                }
            }
            else
            {
                article.ArticleTags = null;
                try
                {
                    dbContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw new DALException($"Error while updating article {ex.Message}");
                }
                article.ArticleTags = newArticle.ArticleTags;
            }
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DALException($"Error while updating article {ex.Message}");
            }
        }

        public Article GetArticle(int id)
        {
            try
            {
                return dbContext.Articles.Where(a => a.Id == id).First();
            }
            catch
            {
                throw new DALException("Can't get article");
            }
            
        }
        public PagedList<Article> GetArticles(ArticleQueryParameters parameters)
        {
            static double ConvertToUnixTimestamp(DateTime date)
            {
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff = date.ToUniversalTime() - origin;
                return Math.Floor(diff.TotalMilliseconds);
            }
            IEnumerable<Article> articles = null;
            try
            {
                articles = dbContext.Articles.Include(a => a.Category).Include(a => a.ArticleTags);
            }
            catch
            {
                throw new DALException("Can't get articles");
            }

            if (parameters.CategoryId != -1)
                articles = articles.Where(a => a.Category.Id == parameters.CategoryId);
   
            if (parameters.TitleContains?.Length != 0)
                articles = articles.Where(a => a.Title.Contains(parameters.TitleContains));

            if (parameters.MaxDate != 1)
            {
                articles = articles.Where(a => ConvertToUnixTimestamp(a.PublishTime) >= parameters.MinDate && ConvertToUnixTimestamp(a.PublishTime) <= parameters.MaxDate);
            }
            

            if (parameters.Tags != null && parameters.Tags?.Length != 0)
            {
                var articlesWithTags = new List<Article>();
                var tags = parameters.Tags.Split(' ');
                var tagsIds = new List<int>();
                int value;
                bool parsed;
                foreach (var tag in tags)
                {
                    parsed = int.TryParse(tag, out value);
                    if (parsed)
                    {
                        tagsIds.Add(value);
                    }
                }

                bool containAllTags;
                foreach (var article in articles)
                {
                    containAllTags = true;
                    foreach (var tagId in tagsIds)
                    {
                        if (!article.ArticleTags.Any(a => a.TagId == tagId))
                        {
                            containAllTags = false;
                        }
                    }
                    if (containAllTags)
                    {
                        articlesWithTags.Add(article);
                    }
                }

                articles = articlesWithTags;
            }

            return PagedList<Article>.ToPagedList(articles,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public void RemoveArticle(Article article)
        {
            dbContext.Articles.Remove(article);
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
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
