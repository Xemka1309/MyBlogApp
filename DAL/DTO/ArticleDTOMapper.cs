using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlogApp.DAL.Entity;
namespace MyBlogApp.DAL.DTO
{
    public static class ArticleDTOMapper
    {
        public static ArticleDTO MapToArticleDTO(Article article)
        {
            ArticleDTO articleDTO = new ArticleDTO();

            articleDTO.Id = article.Id;
            articleDTO.PicsUrl = article.PicsUrl;
            articleDTO.Title = article.Title;
            articleDTO.Content = article.Content;
            articleDTO.Description = article.Description;
            //articleDTO.Tags = article.Tags;
            articleDTO.CategoryId = article.Category.Id;

            return articleDTO;

        }
    }
}
