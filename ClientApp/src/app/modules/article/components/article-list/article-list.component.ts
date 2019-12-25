import { Component, OnInit, AfterContentInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ArticleListService } from 'src/app/services/article-list-service';
import { ArticleService } from 'src/app/services/article-service';
import { Article } from '../../models/article';
import { ArticlePageParams } from '../../models/article-page-params';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/services/category-service';
import { Category } from 'src/app/modules/category/models/category';
import { Tag } from 'src/app/modules/tag/models/tag';
import { TagService } from 'src/app/services/tag-service';

@Component({
    selector: 'article-list',
    templateUrl: './article-list.component.html',
    styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit{
    filterForm:FormGroup;
    articles:Article[];
    tags:Tag[];
    selectedTags:Tag[];  
    articleParams:ArticlePageParams;  
    categories:Category[];
    hasArticles:boolean = true;
    constructor(private categoryService:CategoryService,private articleService:ArticleService, private router: Router, private tagService:TagService) 
    {
        this.articleParams = new ArticlePageParams();
        this.articleParams.pageSize = 5;
        
    }
    ngOnInit(): void 
    {
        this.categoryService.getCategories().subscribe( (result:Category[]) =>{
            this.categories = result;
        }),error => console.log(error);
        this.tagService.getTags().subscribe( (result:Tag[]) => {
            this.tags = result;
        } )
        this.filterForm = new FormGroup({
            categoryId:new FormControl(),
            startDate:new FormControl(),
            endDate:new FormControl(),
            titleContains:new FormControl(),
            tagId: new FormControl(),
           });
        this.articleParams.pageNumber = 1;
        this.articleParams.CategoryId = -1;
        this.articleParams.Tags="";
        this.articleParams.TitleContains = "";
        this.getPageArticles();
        
    }
    getPageArticles():void{
        this.articleService.getArticlesFiltered(this.articleParams).subscribe((result:Article[]) =>{
            this.articles = result;
            this.hasArticles = false;
            if (this.articles){
                if (this.articles.length >= 1){
                    this.hasArticles = true;
            }
        }
        }), error => console.log(error);
        
        
        
    }
    nextPage(){
        this.articleParams.pageNumber++;
        this.getPageArticles();
        window.scrollTo(0,0);
        
    }
    filter(){
        this.articleParams.pageNumber = 1;
        if ((!this.filterForm.value.categoryId.value)){
            this.articleParams.CategoryId = Number.parseInt(this.filterForm.value.categoryId);
        }
        if (this.selectedTags){
            this.articleParams.Tags = "";
            this.selectedTags.forEach(element => {
                this.articleParams.Tags += element.Id.toString() + " ";
            });
            ;
        }
        
        console.log(this.articleParams);
        this.getPageArticles();

    }
    prevPage(){
        if (this.articleParams.pageNumber > 1)
            this.articleParams.pageNumber--;
        else
            return;
        this.getPageArticles();
        window.scrollTo(0,0);
    }
    
    selectTag(){
        if (!this.selectedTags){
            this.selectedTags = [];
        }
        let id = +this.filterForm.value.tagId;
        if (this.selectedTags.findIndex(t => t.Id == id) == -1){
            this.selectedTags.push(this.tags.find(t => t.Id == id));
        }


    }
    unselectTag(){
        if (!this.selectedTags){
            this.selectedTags = [];
        }
        let id = Number.parseInt(this.filterForm.controls.tagId.value);
        if (this.selectedTags.findIndex(t => t.Id == id) != -1){
            this.selectedTags.splice(this.selectedTags.findIndex(t => t.Id == id),1);
        }
    }
    
}