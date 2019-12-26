using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyBlogApp.DAL.Entity;
using MyBlogApp.BLL.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MyBlogApp.DAL.Entity.Infrastructure;
using MyBlogApp.BLL.Exceptions;

namespace MyBlogApp.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult Post([FromBody]Article article)
        {
            logger.LogInformation("Accept POST Article");
            if (article == null)
            {
                return BadRequest(JsonConvert.SerializeObject("invalid article object"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                articleService.AddArticle(article);
            }
            catch (ServiceException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject("Server error"));
            }
            
            logger.LogInformation(JsonConvert.SerializeObject("Article was added from POST method"));
            return Ok(article);
        }

        [Authorize]
        [HttpPut]
        public IActionResult EditArticle([FromQuery] int id, [FromBody] Article article)
        {
            if (article == null)
                return BadRequest(JsonConvert.SerializeObject("article is null"));

            if (articleService.GetArticle(id) == null)
                return BadRequest(JsonConvert.SerializeObject("article does not exists"));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                articleService.EditArticle(id, article);
            }
            catch (ServiceException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject("Server error"));
            }
            return Ok(article);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteArticle([FromQuery] int id)
        {
            if (articleService.GetArticle(id) == null)
                return BadRequest(JsonConvert.SerializeObject("article does not exists"));

            try
            {
                articleService.RemoveArticle(id);
            }
            catch (ServiceException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject("Server error"));
            }
            return Ok(id);
        }

        [HttpGet]
        public IActionResult GetArticles([FromQuery] ArticleQueryParameters articleParameters)
        {
            if (articleParameters == null)
                return BadRequest(JsonConvert.SerializeObject("Null params"));

            if (!articleParameters.ValidYearRange)
            { 
                return BadRequest(JsonConvert.SerializeObject("Max date cannot be less than min date"));
            }

            if (articleParameters.Tags != null)
                articleParameters.Tags = articleParameters.Tags.TrimEnd();

            PagedList<Article> articles = null;
            try
            {
                articles = articleService.GetArticles(articleParameters);
            }
            catch (ServiceException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject("Server error"));
            }

            if (articles == null)
                return Ok(new List<Article>());

            var metadata = new
            {
                articles.TotalCount,
                articles.PageSize,
                articles.CurrentPage,
                articles.TotalPages,
                articles.HasNext,
                articles.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            logger.LogInformation($"Returned {articles.TotalCount} articles from database.");

            return Ok(JsonConvert.SerializeObject(articles));
        }
    }
}