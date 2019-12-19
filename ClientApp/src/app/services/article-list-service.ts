import {Injectable, Inject} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Article } from '../modules/article/models/article';

@Injectable({providedIn: 'root'})
export class ArticleListService {
    
    constructor(private http: HttpClient){
    }

    
}