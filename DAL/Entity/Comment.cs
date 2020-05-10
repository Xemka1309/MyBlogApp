
using System.ComponentModel.DataAnnotations;

namespace MyBlogApp.DAL.Entity
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment must contain text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Comment must contain author")]
        public string Author { get; set; }
    }
}
