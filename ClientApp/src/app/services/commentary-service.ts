import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ArticleComment } from '../modules/article/models/article-commentary';

@Injectable({ providedIn: 'root' })
export class CommentaryService {
  private base = 'https://localhost:44382/api/articles/comments';
  constructor(private http: HttpClient) {
  }

  public getCommentariesToArticle(articleId: number): Observable<any> {
    if (isNaN(articleId)) {
      return;
    }
    return this.http.get<ArticleComment[]>(this.base + `?articleId=${articleId.toString()}`);
  }

  public addComment(comment: ArticleComment, articleId: number): Observable<any> {
    comment.Author = "PETYA";
    return this.http.post(this.base + `?articleId=${articleId.toString()}`, comment, {
      observe: 'response'
    });

  }
}
