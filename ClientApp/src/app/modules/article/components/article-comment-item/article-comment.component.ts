import { Component, OnInit, Input } from '@angular/core';
import { ArticleComment } from '../../models/article-commentary';
import { CommentaryService } from 'src/app/services/commentary-service';

@Component({
  selector: 'article-comment-item',
  templateUrl: './article-comment.component.html',
  styleUrls: ['./article-comment.component.css']
})
export class ArticleCommentryItemComponent implements OnInit {

  @Input()
  private comment: ArticleComment;
  constructor(private commentaryService: CommentaryService) {

  }
  ngOnInit(): void { }
}
