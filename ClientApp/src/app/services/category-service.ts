import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Category } from '../modules/category/models/category';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CategoryService {
  private base = 'https://localhost:44382/api/category';
  private categories: Category[];
  constructor(private http: HttpClient) {
    this.categories = [];
  }

  public addCategory(category: Category): Observable<any> {
    return this.http.post(this.base, category, {
      observe: 'response'
    });

  }
  public getCategories(): Observable<any> {
    return this.http.get(this.base);
  }
  public editCategory(id: number, newCategory: Category): Observable<any> {
    return this.http.put(this.base + "?id=" + id.toString(), newCategory, {
      observe: 'response'
    });
  }
  public deleteCategory(id: number): Observable<any> {
    return this.http.delete(this.base + "?id=" + id.toString(), {
      observe: 'response'
    });
  }
}
