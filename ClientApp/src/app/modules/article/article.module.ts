import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {BrowserModule} from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { ArticleConstructor } from './components/article-consturctor/article-constructor.component';

@NgModule({
  declarations: [
    ArticleConstructor,
  ],
  imports: [
    BrowserModule,
    RouterModule,
    HttpClientModule,
  ],
  providers: [],
  exports: [ArticleConstructor]
})

export class ArticleModule {
}