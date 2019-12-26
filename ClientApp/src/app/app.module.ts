import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CategoryModule } from './modules/category/category-constructor.module';
import { MatSliderModule } from '@angular/material/slider';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CategoryConstructorComponent } from './modules/category/components/category-constructor/category-constructor.component';
import { ArticleModule } from './modules/article/article.module';
import { ArticleListComponent } from './modules/article/components/article-list/article-list.component';
import { ArticleConstructorComponent } from './modules/article/components/article-consturctor/article-constructor.component';
import { TagModule } from './modules/tag/tag.module';
import { TagConstructorComponent } from './modules/tag/components/tag-constructor-component/tag-constructor.component';
import { ArticleViewerComponent } from './modules/article/components/article-viewer/article-viewer.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    CategoryModule,
    ArticleModule,
    MatSliderModule,
    TagModule,
    RouterModule.forRoot([
      { path: '', component: ArticleListComponent, pathMatch: 'full' },
      { path: 'category', component: CategoryConstructorComponent},
      { path: 'article-item', component: ArticleListComponent },
      { path: 'article-constructor', component: ArticleConstructorComponent},
      { path: 'tag-constructor', component: TagConstructorComponent },
      { path: 'article', component: ArticleViewerComponent},
    ]),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
