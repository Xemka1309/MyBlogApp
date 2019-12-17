using MyBlogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.BLL
{
    public class ServiceFactory
    {
        private IArticleService articleService;
        
        public ServiceFactory(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        public IArticleService GetArticleService() 
        {
            return articleService;
        }
    }
}
