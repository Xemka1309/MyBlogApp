using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlogApp.BLL.Exceptions;
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

        [Route("tagitem")]
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
                return BadRequest(JsonConvert.SerializeObject("Null tag to add"));
            tagService.AddTag(tag);
            Response.Headers.Add("Message", $"tag with value:{tag.Value} was added");
            return Ok(JsonConvert.SerializeObject(tag));
        }

        [HttpPut]
        public IActionResult EditTag([FromQuery] int id, [FromBody] Tag newTag)
        {
            if (tagService.GetTag(id) == null)
                return BadRequest(JsonConvert.SerializeObject("Invalid tag id to edit"));
            if (newTag == null)
                return BadRequest(JsonConvert.SerializeObject("Null tag"));
            try
            {
                tagService.EditTag(id, newTag);
            }
            catch (ServiceException ex)
            {
                return BadRequest(JsonConvert.SerializeObject($"Can't edit tag: {ex.Message}" ));
            }

            return Ok(JsonConvert.SerializeObject(newTag));
        }

        [HttpDelete]
        public IActionResult DeleteTag([FromQuery] int id)
        {
            if (tagService.GetTag(id) == null)
                return BadRequest(JsonConvert.SerializeObject("Invalid tag id to delete"));
            try
            {
                tagService.RemoveTag(id);
                return Ok(JsonConvert.SerializeObject($"Tag with id:{id} was deleted"));
            }
            catch
            {
                return BadRequest(JsonConvert.SerializeObject($"Can't delete tag with id:{id}"));
            }
        }
    }
}