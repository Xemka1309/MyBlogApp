using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class TagController : ControllerBase
    {
        private ILogger<TagController> logger;
        private ITagService tagService;
        public TagController(ITagService tagService, ILogger<TagController> logger)
        {
            this.logger = logger;
            this.tagService = tagService;
        }

        [Route("api/[controller]/item/")]
        [HttpGet]
        public IActionResult GetTag([FromQuery]int id)
        {
            return Ok(JsonConvert.SerializeObject(tagService.GetTag(id)));
        }

        [HttpGet]
        [Route ("tagsOFarticle")]
        public IActionResult GetTagsOfArtilce([FromQuery]int articleId) 
        {
            return Ok(JsonConvert.SerializeObject(tagService.GetTagsOfArticle(articleId)));
        }

        [HttpGet]
        public IActionResult GetTags()
        {
            return Ok(JsonConvert.SerializeObject(tagService.GetTags()));
        }
        [HttpPost]
        public IActionResult AddTag([FromBody] Tag tag)
        {
            if (tagService == null)
                return BadRequest("Null tag to add");
            tagService.AddTag(tag);
            return Ok($"Tag with value:{tag.Value} was added");
        }

        [HttpPut]
        public IActionResult EditTag([FromQuery] int id, [FromBody] Tag newTag)
        {
            if (newTag == null)
                return BadRequest("Null tag");
            try
            {
                tagService.EditTag(id, newTag);
            }
            catch
            {
                return BadRequest("Can't edit tag");
            }

            return Ok($"Tag with id:{id} was edited");
        }

        [HttpDelete]
        public IActionResult DeleteTag([FromQuery] int id)
        {
            try
            {
                tagService.RemoveTag(id);
                return Ok($"Tag with id:{id} was deleted");
            }
            catch
            {
                return BadRequest($"Can't delete tag with id:{id}");
            }
        }
    }
}