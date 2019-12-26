using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.Entity;
using Newtonsoft.Json;
using MyBlogApp.BLL.Exceptions;

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
            try
            {
                return Ok(JsonConvert.SerializeObject(categoryService.GetCategories()));
            }
            catch (ServiceException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject("Server error"));
            }
            
        }

        
        [Authorize]
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category) 
        {
            if (category == null)
            {
                return BadRequest(JsonConvert.SerializeObject("Invalid body (invalid category object)"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                categoryService.AddCategory(category);
                return Ok(JsonConvert.SerializeObject("Category was added"));
            }
            catch (ServiceException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject("Server error"));
            }
            
        }

        [Authorize]
        [HttpPut]
        public IActionResult EditCategory([FromQuery] int id, [FromBody] Category category)
        {
            if (category == null)
                return BadRequest(JsonConvert.SerializeObject("Category was null"));

            if (categoryService.GetCategory(id) == null)
                return BadRequest(JsonConvert.SerializeObject("Category does not exists"));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                categoryService.EditCategory(id, category);
                return Ok(JsonConvert.SerializeObject($"Tag with id:{id} was edited"));
            }
            catch (ServiceException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject("Server error"));
            }

        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteCategory([FromQuery] int id)
        {
            try
            {
                categoryService.RemoveCategory(id);
                return Ok(JsonConvert.SerializeObject("Delete ok"));
            }
            catch (ServiceException ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject("Server error"));
            }

        }
    }
}