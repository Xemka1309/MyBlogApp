using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using MyBlogApp.DAL;
using MyBlogApp.BLL.Exceptions;
namespace MyBlogApp.BLL.ServiceImpl
{
    public class ArticleService : IArticleService
    {
        private DAOFactory daoFactory;
        public ArticleService(DAOFactory daoFactory) 
        {
            this.daoFactory = daoFactory;
        }

        public void AddArticle(Article article)
        {
            if (article == null)
                throw new ServiceNullArgumentException("article argument was null");
            daoFactory.GetArticleRepo().AddArticle(article);
        }

        public Article GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public Article[] GetArticles()
        {
            return daoFactory.GetArticleRepo().GetArticles();
        }

        public void RemoveArticle(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
