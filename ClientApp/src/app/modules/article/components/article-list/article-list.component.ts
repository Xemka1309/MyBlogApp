import { Component, OnInit, AfterContentInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ArticleListService } from 'src/app/services/article-list-service';
import { ArticleService } from 'src/app/services/article-service';
import { Article } from '../../models/article';

@Component({
    selector: 'article-list',
    templateUrl: './article-list.component.html',
    styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit{
    articles:Article[];    
    constructor(private articleListService:ArticleListService, private articleService:ArticleService) 
    {

    }
    ngOnInit(): void 
    {
        console.log("Init executing");
        this.articleService.getArticles().subscribe( (result:Article[]) =>{
            this.articles = result;
        }), error => console.log(error);
        console.log("init executed");
        console.log(this.articles);
        
        
    }

    
}