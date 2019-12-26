import { Component, OnInit, AfterContentInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category-service';
import { Category } from 'src/app/modules/category/models/category';
import { FormGroup, FormControl } from '@angular/forms';
import { ArticleService } from 'src/app/services/article-service';
import { Article } from '../../models/article';
import { TagService } from 'src/app/services/tag-service';
import { Tag } from 'src/app/modules/tag/models/tag';
import { ArticleTag } from '../../models/article-tag';
import { DialogOKComponent } from 'src/app/modules/dialogs/components/dialog-ok/dialog-ok.component';
import { DialogErrorComponent } from 'src/app/modules/dialogs/components/dialog-error/dialog-error.component';
import { MatDialog } from '@angular/material/dialog';
import { HttpHeaderResponse } from '@angular/common/http';


@Component({
  selector: 'article-constructor',
  templateUrl: './article-constructor.component.html',
  styleUrls: ['./article-constructor.component.css']
})
export class ArticleConstructorComponent implements OnInit, AfterContentInit {
  private dialogConfig;
  public tabInd = 0;
  public articleForm: FormGroup;
  public articleListForm: FormGroup;
  private categories: Category[];
  private articles: Article[];
  private tags: Tag[];
  private articleTags: Tag[] = [];
  public modes = ['New Article', 'Edit Article'];
  public formMode = 'New article';
  constructor(private categoryService: CategoryService, private articleSerice: ArticleService,
    private tagService: TagService, private dialog: MatDialog) {

  }
  ngOnInit(): void {
    this.categoryService.getCategories().subscribe((result: Category[]) => {
      this.categories = result;
    }), error => console.log(error);

    this.tagService.getTags().subscribe((result: Tag[]) => {
      this.tags = result;
    }), error => console.log(error);

    this.articleForm = new FormGroup({
      title: new FormControl(),
      content: new FormControl(),
      description: new FormControl(),
      picpass: new FormControl(),
      categoryId: new FormControl(),
      tagId: new FormControl(),
      pictureUrl: new FormControl(),
    });
    this.articleListForm = new FormGroup({
      articleId: new FormControl(),
    });
    this.getArticles();

    this.dialogConfig = {
      height: '200px',
      width: '400px',
      disableClose: true,
      data: {}
    };

  }
  ngAfterContentInit() {

  }
  public hasError = (controlName: string, errorName: string) => {
    return this.articleForm.controls[controlName].hasError(errorName);
  }
  public onCancel = () => {

  }
  public clearForm() {


  }
  public performAction(formValue: FormGroup) {
    const article: Article = new Article();
    const category = this.categories.find(x => x.Id === formValue.controls.categoryId.value);
    article.Category = category;
    article.Content = formValue.controls.content.value;
    article.Title = formValue.controls.title.value;
    article.Description = formValue.controls.description.value;
    article.PicsUrl = formValue.controls.pictureUrl.value;
    article.Id = 0;
    if (this.articleTags.length > 0) {
      article.ArticleTags = [];
      this.articleTags.forEach(element => {
        const articleTag = new ArticleTag();
        articleTag.TagId = element.Id;
        articleTag.ArticleId = 0;
        article.ArticleTags.push(articleTag);
      });
    }
    if (this.formMode == 'New article') {
      if (!this.CheckUniqueTitleValue(article.Title)) {
        this.showDialog(true, "Can't add tag", 'Article with that title already exists');
        return;
      }
      this.articleSerice.addArticle(article).subscribe((result: HttpHeaderResponse) => {
        if (result.status === 200) {
          this.showDialog(true, 'Add ok', 'Article was added');
          this.getArticles();
          this.clearForm();
          this.tabInd = 1;
          return;
        } else {
          this.showDialog(false, "Can't add article", 'article was not added');
          return;
        }
      });
    }
    if (this.formMode == 'Edit article') {
      article.Id = this.articleListForm.controls.articleId.value;
      article.Publish4Time = null;
      this.articleSerice.editArticle(article.Id, article).subscribe((result: HttpHeaderResponse) => {
        if (result.status === 200) {
          this.showDialog(true, 'Edit ok', 'Article was edited');
          this.getArticles();
          this.clearForm();
          this.tabInd = 1;
          return;
        } else {
          this.showDialog(false, "Can't edit article", 'article was not edited');
          return;
        }
      });
    }

  }
  public addTag(formValue: FormGroup) {
    if (this.articleTags.findIndex(x => x.Id == formValue.controls.tagId.value) == -1) {
      this.articleTags.push(this.tags.find(t => t.Id == formValue.controls.tagId.value))
    }

  }
  public removeTag(formValue: FormGroup) {
    if (this.articleTags.findIndex(x => x.Id == formValue.controls.tagId.value) != -1) {
      this.articleTags.splice(this.articleTags.findIndex(t => t.Id == formValue.controls.tagId.value), 1);
    }
    console.log(this.articleTags);
  }

  public getArticles() {
    this.articleSerice.getArticles().subscribe(res => {
      this.articles = res;
    }), error => console.log(error);

  }
  public showDialog(ok: boolean, title: String, message: String) {
    this.dialogConfig.data = {
      'message': message,
      'title': title
    };
    if (ok) {
      const dialogRef = this.dialog.open(DialogOKComponent, this.dialogConfig);
    } else {
      const dialogRef = this.dialog.open(DialogErrorComponent, this.dialogConfig);
    }

  }
  public CheckUniqueTitleValue(value: String): boolean {
    for (const article of this.articles) {
      if (article.Title == value) {
        return false;
      }
    }
    return true;
  }
  public goNew() {
    this.tabInd = 0;
    this.formMode = 'New article';
  }
  public goEdit() {
    this.formMode = 'Edit article';
    this.tabInd = 0;
    const articleToEdit = this.articles.find(a => a.Id == this.articleListForm.controls.articleId.value);
    this.articleForm.controls.title.setValue(articleToEdit.Title);
    this.articleForm.controls.content.setValue(articleToEdit.Content);
    this.articleForm.controls.description.setValue(articleToEdit.Description);
    this.articleTags = [];
    articleToEdit.ArticleTags.forEach(element => {
      this.articleTags.push(this.tags.find(t => t.Id == element.TagId));
    });
    this.articleForm.controls.categoryId.setValue(articleToEdit.Category.Id);

  }
  public goDelete() {
    this.formMode = 'Delete article';
    this.articleSerice.removeArticle(this.articleListForm.controls.articleId.value).subscribe((result: HttpHeaderResponse) => {
      if (result.status === 200) {
        this.showDialog(true, 'Delete ok', 'Article was deleted');
        this.getArticles();
        this.clearForm();
        this.tabInd = 1;
        return;
      } else {
        this.showDialog(false, "Can't delete article", 'article was not deleted');
        return;
      }
    });
  }

}
