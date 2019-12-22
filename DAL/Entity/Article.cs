using System;
using System.Collections.Generic;

namespace MyBlogApp.DAL.Entity
{
    public class Article
    {
        public int Id { get; set; }
        public DateTime PublishTime { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String PicsUrl { get; set; }
        public String Content { get; set; }
        public List<ArticleTag> ArticleTags { get; set; }
        public Category Category { get; set; }
    }
}
