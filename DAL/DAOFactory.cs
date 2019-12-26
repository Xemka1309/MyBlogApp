using MyBlogApp.DAL.DAOInterfaces;

namespace MyBlogApp.DAL
{
    public class DAOFactory
    {
        private ICategoryRepo categoryRepo;
        private IArticleRepo articleRepo;
        private ITagRepo tagRepo;
        public DAOFactory(ICategoryRepo categoryRepo, IArticleRepo articleRepo, ITagRepo tagRepo)
        {
            this.tagRepo = tagRepo;
            this.categoryRepo = categoryRepo;
            this.articleRepo = articleRepo;
        }
        public ICategoryRepo GetCategoryRepo()
        {
            return categoryRepo;
        }
        public IArticleRepo GetArticleRepo()
        {
            return articleRepo;
        }
        public ITagRepo GetTagRepo()
        {
            return tagRepo;
        }
        
    }
}
