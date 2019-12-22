using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyBlogApp.DAL.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        public String Value { get; set; }

   
        public List<ArticleTag> TagArticles { get; set; }
        //public int ArticleId { get; set; }
        //public Article Article { get; set; }
    }
}
