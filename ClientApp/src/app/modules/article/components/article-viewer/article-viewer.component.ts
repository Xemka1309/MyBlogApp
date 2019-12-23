import {Component, OnInit,Input} from '@angular/core';
import { Article } from '../../models/article';
import { ArticleService } from 'src/app/services/article-service';
import { Router } from '@angular/router';

@Component({
  selector: 'article-viewer',
  templateUrl: 'article-viewer.component.html',
  styleUrls: ['article-viewer.component.css'],
})
export class ArticleViewerComponent implements OnInit {
    public url:String = "https://localhost:44382/article-constructor";
    public article:Article;
    constructor(private articleService: ArticleService, private router: Router){
      
    }
    ngOnInit(): void {
      this.article = this.articleService.getCurrent();
      console.log(this.article);
    
    }
    articleClick(){
        this.router.navigate(['/article']);
    }
  
}