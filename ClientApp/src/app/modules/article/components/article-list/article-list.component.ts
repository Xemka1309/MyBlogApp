import { Component, OnInit, AfterContentInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ArticleListService } from 'src/app/services/article-list-service';
import { ArticleService } from 'src/app/services/article-service';
import { Article } from '../../models/article';
import { ArticlePageParams } from '../../models/article-page-params';
import { Router } from '@angular/router';

@Component({
    selector: 'article-list',
    templateUrl: './article-list.component.html',
    styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit{
    articles:Article[];  
    articleParams:ArticlePageParams;  
    constructor(private articleListService:ArticleListService, private articleService:ArticleService, private router: Router) 
    {
        this.articleParams = new ArticlePageParams();
        this.articleParams.pageSize = 5;
        
    }
    ngOnInit(): void 
    {
        this.articleParams.pageNumber = 1;
        this.articleService.getArticlesFiltered(this.articleParams).subscribe((result:Article[]) =>{
            this.articles = result;
        }), error => console.log(error);
        
    }
    getPageArticles():void{
        this.articleService.getArticlesFiltered(this.articleParams).subscribe((result:Article[]) =>{
            this.articles = result;
        }), error => console.log(error);
        
    }
    nextPage(){
        this.articleParams.pageNumber++;
        this.getPageArticles();
        window.scrollTo(0,0);
        
    }
    prevPage(){
        if (this.articleParams.pageNumber > 1)
            this.articleParams.pageNumber--;
        else
            return;
        this.getPageArticles();
        window.scrollTo(0,0);
    }

    
}