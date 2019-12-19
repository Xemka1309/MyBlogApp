using System;

namespace MyBlogApp.DAL.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        public String Value { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
