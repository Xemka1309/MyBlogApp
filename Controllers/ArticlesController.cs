﻿using System;
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
using Newtonsoft.Json;

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
        [Route("{filterStr}")]
        public IActionResult GetFiltered(String filterStr, String abc)
        {
            if (filterStr == null || filterStr.Length < 1)
                return BadRequest("Invalid param filterString");
            return Ok(articleService.GetArticlesFiltered(filterStr));
        }

        [HttpGet]
        public IActionResult GetArticles([FromQuery] ArticleQueryParameters articleParameters)
        {
            var articles = articleService.GetArticles(articleParameters);
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

            logger.LogInformation($"Returned {articles.TotalCount} owners from database.");

            return Ok(JsonConvert.SerializeObject(articles));
        }
    }
}