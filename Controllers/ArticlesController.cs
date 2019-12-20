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
using MyBlogApp.BLL.Interfaces;

namespace MyBlogApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleService articleService; 
        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Post([FromBody]Article article)
        {
            if (article == null)
                return BadRequest("invalid article object");
            articleService.AddArticle(article);
            return Ok(article);
        }
            

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return articleService.GetArticles();
        }
    }
}