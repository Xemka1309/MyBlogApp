import { Category } from '../../category/models/category';
import { Tag } from '../../tag/models/tag';
import { ArticleTag } from './article-tag';

export class Article {
    Id: number;
    Title: String;
    Description: String;
    Content: String;
    Category: Category;
    PicsUrl: String;
    Publish4Time: Date;
    ArticleTags: ArticleTag[];
    Comments: Comment[];
    Rating: number;
    constructor() {
        this.ArticleTags = [];
        this.Id = 0;
        this.Title = '';
        this.Publish4Time = null;
        this.PicsUrl = '';
        this.Rating = 0;
        this.Comments = [];

    }
    static cloneBase(base: Article): Article {
        const result = new Article();
        result.Title = base.Title;
        result.Description = base.Description;
        result.Content = base.Content;
        result.Rating = base.Rating;
        result.Comments = base.Comments;
        if (base.ArticleTags == null) {
            return result;
        }
        base.ArticleTags.forEach( tag => {
          result.ArticleTags.push(tag);
        });
        return result;
      }
}
