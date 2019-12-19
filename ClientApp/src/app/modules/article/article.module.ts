import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule } from '@angular/common/http';
import { ArticleConstructor } from './components/article-consturctor/article-constructor.component';
import { ArticleItem } from './components/article-item/article-item.component';
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';  
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { ArticleListComponent } from './components/article-list/article-list.component';


@NgModule({
  declarations: [
    ArticleConstructor,
    ArticleItem,
    ArticleListComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule,
    HttpClientModule,
    MatCardModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [],
  exports: [ArticleConstructor,ArticleItem,ArticleListComponent]
})

export class ArticleModule {
}