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
            dbContext.Articles.Add(article);
        }

        public void EditArticle(Article oldArticle, Article newArticle)
        {
            throw new NotImplementedException();
        }

        public void GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Article[] GetArticles()
        {
            return dbContext.Articles.ToArray();
        }

        public void RemoveArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public void RemoveArticle(int id)
        {
            throw new NotImplementedException();
        }
    }
}
