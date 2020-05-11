
using System.ComponentModel.DataAnnotations;

namespace MyBlogApp.DAL.Entity
{
    public class ArticleComment
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Comment must contain text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Comment must contain author")]
        public string Author { get; set; }
    }
}
