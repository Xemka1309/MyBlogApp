import {Injectable, Inject} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Category} from '../modules/category/models/category';
import { Observable } from 'rxjs';
import { Tag } from '../modules/tag/models/tag';

@Injectable({providedIn: 'root'})
export class TagService {
    private base = 'https://localhost:44382/api/tag/';
    private tags:Tag[];
    constructor(private http: HttpClient){
        this.tags = [];
    }

    addTag(tag:Tag):Observable<any>{
        return this.http.post(this.base,tag);
    }
    removeTag(id:number){
        if (isNaN(id))
            return;
        return this.http.delete(this.base + "?id=" + id.toString());

    }
    editTag(id:number, newTag:Tag){
        if (isNaN(id) || !newTag)
            return;
        return this.http.put(this.base + "?id=" + id.toString(),newTag)
    }
    getTags()
    {
        return this.http.get<Tag[]>(this.base);
    }
    getTag(id:Number){
        //return this.http.get<Tag>(this.base + "/item?id=" + id);
    }
    getTagsOfArticle(articleId:number){
        if (isNaN(articleId)){
            return;
        }
        return this.http.get<Tag[]>(this.base + "tagsOFarticle?articleId=" + articleId.toString());
    }
}