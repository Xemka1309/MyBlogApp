using System;

namespace MyBlogApp.DAL.Entity
{
    public class Article
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Content { get; set; }
        public Tag[] Tags { get; set; }
    }
}
