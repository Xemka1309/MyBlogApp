import {Component, OnInit,Input} from '@angular/core';
import { Article } from '../../models/article';

/**
 * @title Card with multiple sections
 */
@Component({
  selector: 'article-item',
  templateUrl: 'article-item.component.html',
  styleUrls: ['article-item.component.css'],
})
export class ArticleItem implements OnInit {
    @Input() 
    public article:Article;
    constructor(){
      
    }
    ngOnInit(): void {
      //this.article = Article.cloneBase(this.articleIn);
      console.log(this.article);
    
  }
  
}