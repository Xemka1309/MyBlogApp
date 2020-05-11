import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../../models/article';
import { ArticleService } from 'src/app/services/article-service';
import { Router } from '@angular/router';
import { TagService } from 'src/app/services/tag-service';
import { Tag } from 'src/app/modules/tag/models/tag';
import { CommentaryService } from 'src/app/services/commentary-service';
import { ArticleComment } from '../../models/article-commentary';

@Component({
  selector: 'article-viewer',
  templateUrl: 'article-viewer.component.html',
  styleUrls: ['article-viewer.component.css'],
})
export class ArticleViewerComponent implements OnInit {
  public url: String = 'https://localhost:44382/article-constructor';
  public article: Article;
  public articleTags: Tag[];
  public comments: ArticleComment[];
  public commentText: String = '';
  constructor(private articleService: ArticleService,
              private router: Router,
              private tagService: TagService,
              private commentService: CommentaryService) {

  }
  ngOnInit(): void {
    this.article = this.articleService.getCurrent();
    this.tagService.getTagsOfArticle(this.article.Id).subscribe(result => {
      this.articleTags = result;
    });
    this.commentService.getCommentariesToArticle(this.article.Id).subscribe(result => {
      this.comments = result;
    });
    //console.log(this.article);
    //console.log(this.articleTags);

  }
  public articleClick() {
  }

  public addComment() {
    const comment = new ArticleComment();
    comment.Text = this.commentText;
    comment.ArticleId = this.article.Id;
    comment.Author = "Author";
    comment.Text = "Text";
    this.commentService.addComment(comment, this.article.Id).subscribe(result => {
      this.commentService.getCommentariesToArticle(this.article.Id).subscribe(result => {
        this.comments = result;
        console.log(result);
      });
    });

  }

}
