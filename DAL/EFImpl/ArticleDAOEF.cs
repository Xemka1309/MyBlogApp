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
        // Todo: rewrite to use DTO 
        public void AddArticle(Article article)
        {
            if (article == null)
                throw new NullArgumentDALException("article argument was null");
            if (article.Tags == null)
                article.Tags = new List<Tag>();
            if (article.PublishTime == null)
                article.PublishTime = DateTime.Now;
            
            dbContext.Articles.Add(article);
            dbContext.Attach<Category>(article.Category);
            dbContext.SaveChanges();
        }

        public void EditArticle(Article oldArticle, Article newArticle)
        {
            throw new NotImplementedException();
            dbContext.SaveChanges();
        }

        public void GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetArticles()
        {
            var result = dbContext.Articles
                .Include(article => article.Category)
                .Include(article => article.Tags);
            return result;
        }

        public void RemoveArticle(Article article)
        {
            throw new NotImplementedException();
            dbContext.SaveChanges();
        }

        public void RemoveArticle(int id)
        {
            throw new NotImplementedException();
            dbContext.SaveChanges();
        }
    }
}
