import {Injectable, Inject} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Category} from '../modules/category/models/category';

@Injectable({providedIn: 'root'})
export class CategoryService {
    //private base = 'https://localhost:44382/';
    private categories:Category[];
    constructor(private http: HttpClient){
        this.categories = [];
        let category:Category;
        category = new Category();
        category.description = "Stock descr";
        category.id = 100;
        category.value = "Stock value";
        this.categories.push(category);
    }

    addCategory(category:Category){
        this.categories.push(category);

    }
    removeCategory(category:Category){
        this.categories.splice(this.categories.findIndex(x => x.id === category.id),1);

    }
    getCategories():Category[]
    {
        console.log(this.categories);
        return this.categories;

    }
}