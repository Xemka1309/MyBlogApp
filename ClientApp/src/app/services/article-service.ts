import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Article } from '../modules/article/models/article';
import { ArticlePageParams } from '../modules/article/models/article-page-params';

@Injectable({ providedIn: 'root' })
export class ArticleService {
  private currentAtricle: Article;
  private base = 'https://localhost:44382/api/articles';
  constructor(private http: HttpClient) { }

  addArticle(article: Article): Observable<any> {
    return this.http.post(this.base, article, {
      observe: 'response'
    });
  }

  setCurrent(article: Article) {
    this.currentAtricle = article;
  }
  getCurrent(): Article {
    return this.currentAtricle;
  }
  getArticles(): Observable<any> {
    return this.http.get(this.base);
  }
  getArticlesFiltered(articleParams: ArticlePageParams): Observable<Article[]> {
    const query = this.base + '?';
    if (isNaN(articleParams.CategoryId)) {
      articleParams.CategoryId = -1;
    }
    if (!articleParams.Tags) {
      articleParams.Tags = '';
    }
    const pars = new HttpParams({
      fromObject: {
        PageSize: articleParams.pageSize.toString(),
        PageNumber: articleParams.pageNumber.toString(),
        CategoryId: articleParams.CategoryId.toString(),
        Tags: articleParams.Tags.toString(),
        MinDate: articleParams.MinDate.toString(),
        MaxDate: articleParams.MaxDate.toString(),
      }
    });
    console.log(query);
    return this.http.get<Article[]>(this.base + '?' + pars.toString());
  }
  editArticle(id: number, article: Article): Observable<any> {
    return this.http.put(this.base + '?id=' + id, article, {
      observe: 'response'
    });
  }
  removeArticle(id: number): Observable<any> {
    return this.http.delete(this.base + '?id=' + id, {
      observe: 'response'
    });
  }
}
