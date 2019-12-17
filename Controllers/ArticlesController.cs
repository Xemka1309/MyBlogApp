using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using MyBlogApp.Data;
using MyBlogApp.DAL;
using MyBlogApp.DAL.Entity;

namespace MyBlogApp.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private ApplicationDbContext dbContext;
        public ArticlesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public String Post([FromBody]Article article)
        {
            dbContext.Articles.Add(article);
            return "Add article with title" + article.Title + " OK";
        }
            

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            List<Article> articles = new List<Article>();
            articles.Add(new Article() {
                Title = "Article Title number one",
                Content = "Content from article number one",
                Id = 1,
                Description = "Description from 1"
            });
            articles.Add(new Article()
            {
                Title = "Article Title number two",
                Content = "Content from article number two",
                Id = 2,
                Description = "Description from 2"
            });
            return articles.ToArray();
        }
    }
}