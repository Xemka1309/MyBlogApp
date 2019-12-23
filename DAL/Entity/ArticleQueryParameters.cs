using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.DAL.Entity
{
    public class ArticleQueryParameters: QueryStringParameters
    {
        public String Tags { get; set; } = "";
        public String TitleContains = "";
        public int CategoryId { get; set; } = -1;
        public uint MinDate { get; set; }
        public uint MaxDate { get; set; } = (uint)DateTime.Now.Year * 365 + (uint)DateTime.Now.Day;
        
    }
}
