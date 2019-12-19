import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CategoryModule } from './modules/category/category-constructor.module';
import { MatSliderModule } from '@angular/material/slider';


import { AppComponent } from './app.component';
import { TestComponent } from './testcomponent/testcomponent';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CategoryConstructorComponent } from './modules/category/components/category-constructor/category-constructor.component';
import { ArticleItem } from './modules/article/components/article-item/article-item.component';
import { ArticleModule } from './modules/article/article.module';
import { ArticleListComponent } from './modules/article/components/article-list/article-list.component';


@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    CategoryModule,
    ArticleModule,
    MatSliderModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'test', component:TestComponent, canActivate: [AuthorizeGuard]},
      { path: 'category', component: CategoryConstructorComponent},
      { path: 'article-item', component:ArticleListComponent }
      
    ]),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
