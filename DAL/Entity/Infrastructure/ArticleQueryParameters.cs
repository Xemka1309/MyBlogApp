using System;

namespace MyBlogApp.DAL.Entity.Infrastructure
{
    public class ArticleQueryParameters: QueryStringParameters
    {
        public String Tags { get; set; } = "";
        public String TitleContains = "";
        public int CategoryId { get; set; } = -1;
        public uint MinDate { get; set; } = 0;
        public uint MaxDate { get; set; } = 1;
        public bool ValidYearRange => MaxDate > MinDate;

    }
}
