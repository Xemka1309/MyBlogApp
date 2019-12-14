import { Component,Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ArticleService } from '../services/article-service';
import { Article } from '../modules/article/models/article';

@Component({
  selector: 'testcomponent',
  templateUrl: './testcomponent.html',
  styleUrls: ['./testcomponent.css']
})
export class TestComponent implements OnInit {
    public articles:Article[];
    public result:any;
    constructor(private http: HttpClient,
                private articleService: ArticleService){ }

    ngOnInit() {
        this.articleService.getArticles().subscribe((data: Article[]) => {
            this.articles = data
        }, error => console.log(error));
        let article:Article;
        article = new Article();
        article.title = "Title of angular article";
        article.description = "descr";
        article.content = "content";
        this.articleService.addArticle(article).subscribe((data) => {
            this.result = data
        }, error => console.log(error));
    }
  
}