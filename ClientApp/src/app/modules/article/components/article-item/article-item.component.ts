import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../../models/article';
import { ArticleService } from 'src/app/services/article-service';
import { Router } from '@angular/router';

/**
 * @title Card with multiple sections
 */
@Component({
  selector: 'article-item',
  templateUrl: 'article-item.component.html',
  styleUrls: ['article-item.component.css']
})
export class ArticleItemComponent implements OnInit {
  public url: String = 'https://localhost:44382/article';
  @Input()
  public article: Article;
  constructor(private articleService: ArticleService, private router: Router) {}
  ngOnInit(): void {
    console.log(this.article);
  }
  openDetails() {
    console.log('clicked');
    this.articleService.setCurrent(this.article);
    this.router.navigate(['/article']);
  }
}
