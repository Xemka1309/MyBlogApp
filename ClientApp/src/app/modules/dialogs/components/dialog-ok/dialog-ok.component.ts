import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: "dialog-ok",
  templateUrl: './dialog-ok.component.html',
  styleUrls: ['./dialog-ok.component.css']
})
export class DialogOKComponent implements OnInit {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) { }
  ngOnInit(): void { }
}
