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

        public PagedList<Article> GetArticles(ArticleQueryParameters parameters)
        {   if (parameters == null)
                throw new ServiceNullArgumentException("articlequeryparams was null");
            return daoFactory.GetArticleRepo().GetArticles(parameters);
        }

        public void RemoveArticle(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveArticle(Article article)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Article> GetArticlesFiltered(String filterStr)
        {
            if (filterStr == null)
                throw new ServiceNullArgumentException("filterstring was null");
            return daoFactory.GetArticleRepo().GetArticlesFiltered(filterStr);
        }
    }
}
