import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ArticleConstructorComponent } from './components/article-consturctor/article-constructor.component';
import { ArticleItemComponent } from './components/article-item/article-item.component';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ArticleListComponent } from './components/article-list/article-list.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { ArticleViewerComponent } from './components/article-viewer/article-viewer.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MyDialogModule } from '../dialogs/dialogs.module';
import { ArticleCommentryItemComponent } from './components/article-comment-item/article-comment.component';
@NgModule({
  declarations: [
    ArticleConstructorComponent,
    ArticleItemComponent,
    ArticleListComponent,
    ArticleViewerComponent,
    ArticleCommentryItemComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule,
    HttpClientModule,
    MatCardModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatTabsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MyDialogModule
  ],
  providers: [],
  exports: [ArticleConstructorComponent,
    ArticleItemComponent,
    ArticleListComponent,
    ArticleViewerComponent,
    ArticleCommentryItemComponent]
})

export class ArticleModule {
}
