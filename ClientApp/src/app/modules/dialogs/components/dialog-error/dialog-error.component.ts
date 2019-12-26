import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: "dialog-error",
  templateUrl: './dialog-error.component.html',
  styleUrls: ['./dialog-error.component.css']
})
export class DialogErrorComponent implements OnInit {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
  ngOnInit(): void {}
}
