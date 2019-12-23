﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.Entity;
using Newtonsoft.Json;

namespace MyBlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService;
        private readonly ILogger<CategoryController> logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            this.categoryService = categoryService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(JsonConvert.SerializeObject(categoryService.GetCategories()));
        }

        
        [Authorize]
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category) 
        {
            logger.LogDebug("Accept POST category");
            if (category == null)
            {
                logger.LogInformation("Bad request accepted");
                return BadRequest("Invalid body (invalid category object)");
            }
                

            categoryService.AddCategory(category);
            logger.LogInformation($"Category with name: {category.Name} was added");
            return Ok("Category was added");
        }

        [HttpPut]
        public IActionResult EditCategory([FromQuery] int id, [FromBody] Category category)
        {
            if (category == null)
                return BadRequest("Category was null");
            try
            {
                categoryService.EditCategory(id, category);
                return Ok($"Tag with id:{id} was edited");
            }
            catch
            {
                return BadRequest("Can't perform editing");
            }
            
        }

        [HttpDelete]
        public IActionResult DeleteCategory([FromQuery] int id)
        {
            try
            {
                categoryService.RemoveCategory(id);
                return Ok("Delete ok");
            }
            catch
            {
                return BadRequest("Can't perform delete");
            }
            
        }
    }
}