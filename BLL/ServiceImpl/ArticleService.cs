using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogApp.DAL;
namespace MyBlogApp.BLL.ServiceImpl
{
    public class ArticleService : IArticleService
    {
        private DAOFactory daoFactory;
        public ArticleService(DAOFactory daoFactory) 
        {
            this.daoFactory = daoFactory;
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
