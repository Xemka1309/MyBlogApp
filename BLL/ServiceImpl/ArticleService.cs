using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.Entity;
using MyBlogApp.DAL.Entity.Infrastructure;
using MyBlogApp.DAL;
using MyBlogApp.BLL.Exceptions;
using MyBlogApp.DAL.Exceptions;
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
            try
            {
                daoFactory.GetArticleRepo().AddArticle(article);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public Article GetArticle(int id)
        {
            try
            {
                return daoFactory.GetArticleRepo().GetArticle(id);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public PagedList<Article> GetArticles(ArticleQueryParameters parameters)
        {   
            if (parameters == null)
                throw new ServiceNullArgumentException("articlequeryparams was null");
            try
            {
                return daoFactory.GetArticleRepo().GetArticles(parameters);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public void RemoveArticle(int id)
        {
            try
            {
                daoFactory.GetArticleRepo().RemoveArticle(id);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public void RemoveArticle(Article article)
        {
            if (article == null)
                return;
            try
            {
                daoFactory.GetArticleRepo().RemoveArticle(article.Id);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }

        public void EditArticle(int id, Article newArticle)
        {
            try
            {
                daoFactory.GetArticleRepo().EditArticle(id, newArticle);
            }
            catch (DALException ex)
            {
                throw new ServiceException($"DAL exception : {ex.Message}");
            }
            
        }
    }
}
