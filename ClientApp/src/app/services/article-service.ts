import {Injectable, Inject} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Article } from '../modules/article/models/article';
import { ArticlePageParams } from '../modules/article/models/article-page-params';

@Injectable({providedIn: 'root'})
export class ArticleService {
    private base = 'https://localhost:44382/api/articles';
    constructor(private http: HttpClient){
    }

    addArticle(article: Article): Observable<any> {
        return this.http.post(this.base,article);
    }

    getArticles(): Observable<any> {
        return this.http.get(this.base);
    }
    getArticlesFiltered(articleParams:ArticlePageParams):Observable<Article[]>{
        let query = this.base + "?";
        query = query + "pageSize=" + articleParams.pageSize
                + "&pageNumber=" + articleParams.pageNumber;
        console.log(query);
        return this.http.get<Article[]>(query);
    }
    public AddTagsToArticle(article){

    }
}