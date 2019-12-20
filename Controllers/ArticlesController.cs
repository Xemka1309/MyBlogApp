using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using MyBlogApp.DAL;
using MyBlogApp.DAL.Entity;
using MyBlogApp.BLL.Interfaces;
using Microsoft.Extensions.Logging;

namespace MyBlogApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private ILogger<ArticlesController> logger;
        private IArticleService articleService; 
        public ArticlesController(IArticleService articleService, ILogger<ArticlesController> logger)
        {
            this.logger = logger;
            this.articleService = articleService;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Post([FromBody]Article article)
        {
            logger.LogInformation("Accept POST Article");
            if (article == null)
            {
                logger.LogError("Null article accepted from POST");
                return BadRequest("invalid article object");
            }
            articleService.AddArticle(article);
            logger.LogInformation("Article was added from POST method");
            return Ok(article);
        }
            

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            var result =  articleService.GetArticles();
            return result;
        }
    }
}