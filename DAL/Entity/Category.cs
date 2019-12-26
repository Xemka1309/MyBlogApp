using System;
using System.ComponentModel.DataAnnotations;
namespace MyBlogApp.DAL.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(40, ErrorMessage = "Category name length must be less than 40 ")]
        [Required(ErrorMessage = "Category must have name")]
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
