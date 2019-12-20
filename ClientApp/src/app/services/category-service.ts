import {Injectable, Inject} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Category} from '../modules/category/models/category';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class CategoryService {
    private base = 'https://localhost:44382/api/';
    private categories:Category[];
    constructor(private http: HttpClient){
        this.categories = [];
    }

    addCategory(category:Category){
        let categoryX= {
            Id:0,
            Name:category.name,
            Description:category.description
        };
        this.http.post(this.base + "category/", categoryX).subscribe();

    }
    removeCategory(category:Category){
        this.categories.splice(this.categories.findIndex(x => x.id === category.id),1);

    }
    getCategories()
    {
        return this.http.get(this.base + "category");
    }
}