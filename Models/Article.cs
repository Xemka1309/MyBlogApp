using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Content { get; set; }
    }
}
