import { Component, OnInit, AfterContentInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category-service';
import { Category } from 'src/app/modules/category/models/category';
import { FormGroup, FormControl } from '@angular/forms';
import { ArticleService } from 'src/app/services/article-service';
import { Article } from '../../models/article';


@Component({
    selector: 'article-constructor',
    templateUrl: './article-constructor.component.html',
    styleUrls: ['./article-constructor.component.css']
})
export class ArticleConstructorComponent implements OnInit, AfterContentInit {
    articleForm: FormGroup;
    private categories: Category[];
    constructor(private categoryService: CategoryService, private articleSerice:ArticleService)  
    {

    }
    ngOnInit(): void 
    {
        this.categoryService.getCategories().subscribe( (result:Category[]) =>{
            this.categories = result;
        } ), error => console.log(error);
        console.log(this.categories);
        this.articleForm = new FormGroup({
            title: new FormControl(),
            content: new FormControl(),
            description: new FormControl(),
            picpass:new FormControl(),
            categoryId:new FormControl(),
           });
        
        
    }
    ngAfterContentInit() {
        console.log("suda smotret000");
        console.log(this.categories);
    }
    public hasError = (controlName: string, errorName: string) =>{
        return this.articleForm.controls[controlName].hasError(errorName);
    }
    public onCancel = () => {
        
    }
    public clearForm() {
        
        
    }
    public createArticle(formValue:FormGroup){
        console.log("create article");
        console.log(formValue.controls.categoryId.value);
        let article:Article = new Article();
        article.categoryId = formValue.controls.categoryId.value;
        article.content = formValue.controls.content.value;
        article.title = formValue.controls.title.value;
        article.description = formValue.controls.description.value;
        article.id = 0;
        this.articleSerice.addArticle(article);
        this.clearForm();
        
    }

    
}