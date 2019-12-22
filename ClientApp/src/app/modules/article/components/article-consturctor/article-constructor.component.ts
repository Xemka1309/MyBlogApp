import { Component, OnInit, AfterContentInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category-service';
import { Category } from 'src/app/modules/category/models/category';
import { FormGroup, FormControl } from '@angular/forms';
import { ArticleService } from 'src/app/services/article-service';
import { Article } from '../../models/article';
import { TagService } from 'src/app/services/tag-service';
import { Tag } from 'src/app/modules/tag/models/tag';
import { ArticleTag } from '../../models/article-tag';


@Component({
    selector: 'article-constructor',
    templateUrl: './article-constructor.component.html',
    styleUrls: ['./article-constructor.component.css']
})
export class ArticleConstructorComponent implements OnInit, AfterContentInit {
    articleForm: FormGroup;
    private categories: Category[];
    private tags:Tag[];
    private articleTags:Tag[] = [];
    constructor(private categoryService: CategoryService, private articleSerice:ArticleService, private tagService:TagService)  
    {

    }
    ngOnInit(): void 
    {
        this.categoryService.getCategories().subscribe( (result:Category[]) =>{
            this.categories = result;
        } ), error => console.log(error);
        console.log(this.categories);
        this.tagService.getTags().subscribe((result:Tag[]) =>{
            this.tags = result;
        } ), error => console.log(error);
        this.articleForm = new FormGroup({
            title: new FormControl(),
            content: new FormControl(),
            description: new FormControl(),
            picpass:new FormControl(),
            categoryId:new FormControl(),
            tagId:new FormControl(),
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
        let category = this.categories.find(x => x.Id === formValue.controls.categoryId.value);
        article.Category = category; 
        console.log(category.Name);
        article.Content = formValue.controls.content.value;
        article.Title = formValue.controls.title.value;
        article.Description = formValue.controls.description.value;
        article.PicsUrl = "articles/" + article.Title;
        article.Id = 0;
        if (this.articleTags.length > 0){
            article.ArticleTags = [];
            this.articleTags.forEach(element => {
                let articleTag = new ArticleTag();
                articleTag.TagId = element.Id;
                articleTag.ArticleId = 0;
                article.ArticleTags.push(articleTag)
            });
        }
        this.articleSerice.addArticle(article).subscribe();
        this.clearForm();
        
    }
    public addTag(formValue:FormGroup){
        if (this.articleTags.findIndex(x => x.Id == formValue.controls.tagId.value) == -1)
            this.articleTags.push(this.tags.find(t => t.Id == formValue.controls.tagId.value))

    }
    public removeTag(formValue:FormGroup){
        if (this.articleTags.findIndex(x => x.Id == formValue.controls.tagId.value) != -1)
            this.articleTags.splice(this.articleTags.findIndex(t => t.Id == formValue.controls.tagId.value),1);
        console.log(this.articleTags);
    }

    
}