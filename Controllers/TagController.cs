using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlogApp.BLL.Interfaces;
using MyBlogApp.DAL.Entity;

namespace MyBlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class TagController : ControllerBase
    {
        private ILogger<TagController> logger;
        private ITagService tagService;
        public TagController(ITagService tagService, ILogger<TagController> logger)
        {
            this.logger = logger;
            this.tagService = tagService;
        }

        [HttpGet]
        public IActionResult GetTags()
        {
            return Ok(tagService.GetTags());
        }
        [HttpPost]
        public IActionResult AddTag([FromBody] Tag tag)
        {
            if (tagService == null)
                return BadRequest("Null tag to add");
            tagService.AddTag(tag);
            return Ok($"Tag with value:{tag.Value} was added");
        }
    }
}