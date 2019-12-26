using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MyBlogApp.DAL.Entity
{
    public class Tag
    {
        public int Id { get; set; }

        [MaxLength(40, ErrorMessage = "Tag value length must be less than 40 ")]
        [Required(ErrorMessage = "Tag must have value")]
        public String Value { get; set; }
        public List<ArticleTag> TagArticles { get; set; }
    }
}
