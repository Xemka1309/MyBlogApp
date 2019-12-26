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
        private ITagService tagService;
        private ICategoryService categoryService;
        
        public ServiceFactory(IArticleService articleService, ITagService tagService, ICategoryService categoryService)
        {
            this.tagService = tagService;
            this.categoryService = categoryService;
            this.articleService = articleService;
        }
        public IArticleService GetArticleService() 
        {
            return articleService;
        }
    }
}
