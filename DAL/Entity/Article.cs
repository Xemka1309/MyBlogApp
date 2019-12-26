using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MyBlogApp.DAL.Entity
{
    public class Article
    {
        public int Id { get; set; }
        public DateTime PublishTime { get; set; }

        [MaxLength(100, ErrorMessage = "Title of the article must be less than 100 symbs")]
        [Required (ErrorMessage = "Article must contain title")]
        public String Title { get; set; }
        public String Description { get; set; }
        public String PicsUrl { get; set; }

        [MaxLength(1000, ErrorMessage = "Article content length must be less than 1000 symbs")]
        [Required (ErrorMessage = "Article must contain content")]
        public String Content { get; set; }
        public List<ArticleTag> ArticleTags { get; set; }

        [Required(ErrorMessage = "Article must be part of some category")]
        public Category Category { get; set; }
    }
}
