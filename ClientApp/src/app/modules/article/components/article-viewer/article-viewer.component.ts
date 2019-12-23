import {Component, OnInit,Input} from '@angular/core';
import { Article } from '../../models/article';
import { ArticleService } from 'src/app/services/article-service';
import { Router } from '@angular/router';
import { TagService } from 'src/app/services/tag-service';
import { Tag } from 'src/app/modules/tag/models/tag';

@Component({
  selector: 'article-viewer',
  templateUrl: 'article-viewer.component.html',
  styleUrls: ['article-viewer.component.css'],
})
export class ArticleViewerComponent implements OnInit {
    public url:String = "https://localhost:44382/article-constructor";
    public article:Article;
    public articleTags:Tag[];
    constructor(private articleService: ArticleService, private router: Router, private tagService:TagService){
        
    }
    ngOnInit(): void {
      this.article = this.articleService.getCurrent();
      //this.articleTags = [];
     // this.article.ArticleTags.forEach(element => {
     //     this.tagService.getTag(element.TagId).subscribe(t =>{
      //        this.articleTags.push(t);
      //    })
      //});
      console.log(this.article);
      console.log(this.articleTags);
    
    }
    articleClick(){
    }
  
}