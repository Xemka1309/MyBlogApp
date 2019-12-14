import {Injectable, Inject} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Article } from '../modules/article/models/article';

@Injectable({providedIn: 'root'})
export class ArticleService {
    private base = 'https://localhost:44382/';
    constructor(private http: HttpClient){
    }

    addArticle(article: Article): Observable<any> {
        return this.http.post(this.base + "articles",article);
    }

    getArticles(): Observable<any> {
        return this.http.get(this.base + "articles");
    }
}