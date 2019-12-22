using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.DAL.Entity
{
    public class ArticleTag
    {

        [JsonIgnore]
        public Article Article { get; set; }
        public int ArticleId { get; set; }

        [JsonIgnore]
        public Tag Tag { get; set; }
  
        public int TagId { get; set; }

    }
}
