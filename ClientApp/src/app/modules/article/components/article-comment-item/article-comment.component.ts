import { Component, OnInit, Input } from '@angular/core';
import { Comment } from '../../models/article-commentary';
import { CommentaryService } from 'src/app/services/commentary-service';

@Component({
  selector: 'article-comment-item',
  templateUrl: './article-comment.component.html',
  styleUrls: ['./article-comment.component.css']
})
export class ArticleCommentryItemComponent implements OnInit {

  @Input()
  private comment: Comment;
  constructor(private commentaryService: CommentaryService) {

  }
  ngOnInit(): void { }
}
