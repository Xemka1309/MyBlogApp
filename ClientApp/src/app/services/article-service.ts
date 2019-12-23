import {Injectable, Inject} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Article } from '../modules/article/models/article';
import { ArticlePageParams } from '../modules/article/models/article-page-params';

@Injectable({providedIn: 'root'})
export class ArticleService {
    private currentAtricle:Article;
    private base = 'https://localhost:44382/api/articles';
    constructor(private http: HttpClient){
    }

    addArticle(article: Article): Observable<any> {
        return this.http.post(this.base,article);
    }

    setCurrent(article:Article){
        this.currentAtricle = article;
    }
    getCurrent():Article{
        return this.currentAtricle;
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
    editArticle(id:number, article:Article){
        return this.http.put(this.base + "?id=" + id, article);

    }
    removeArticle(id:number){
        return this.http.delete(this.base + "?id=" + id);
    }
}