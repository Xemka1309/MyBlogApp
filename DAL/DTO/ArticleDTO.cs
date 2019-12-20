using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogApp.DAL.Entity;
namespace MyBlogApp.DAL.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String PicsUrl { get; set; }
        public String Content { get; set; }
        public List<Tag> Tags { get; set; }
        public int CategoryId { get; set; }
    }
}
