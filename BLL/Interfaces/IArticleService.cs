using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogApp.DAL.Entity;
namespace MyBlogApp.BLL.Interfaces
{
    public interface IArticleService
    {
        public IEnumerable<Article> GetArticles();
        public Article GetArticle(int id);
        public void RemoveArticle(int id);
        public void RemoveArticle(Article article);
        public void AddArticle(Article article);
        
    }
}
