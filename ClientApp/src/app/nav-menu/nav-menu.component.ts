import { Component, OnInit } from '@angular/core';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  public isAuthorized = false;
  ngOnInit(): void {
    this.authorizeService.isAuthenticated().subscribe(r =>{
      this.isAuthorized = r;
    });
  }

  constructor(private authorizeService:AuthorizeService){

  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
