import { Component, OnInit, AfterContentInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category-service';
import { Category } from 'src/app/modules/category/models/category';
import { FormGroup, FormControl } from '@angular/forms';
import { ArticleService } from 'src/app/services/article-service';


@Component({
    selector: 'category-constructor',
    templateUrl: './article-constructor.component.html',
    styleUrls: ['./article-constructor.component.css']
})
export class ArticleConstructorComponent implements OnInit, AfterContentInit {
    form: FormGroup;
    private categories: Category[];
    private buttonText: String = "Add category"
    constructor(private categoryService: CategoryService, private articleSerice:ArticleService)  
    {

    }
    ngOnInit(): void 
    {
        this.categories = this.categoryService.getCategories();
        console.log(this.categories);

        this.form = new FormGroup({
            title: new FormControl(),
            content: new FormControl(),
            descr: new FormControl(),
            picpass:new FormControl(),
            categoryid:new FormControl(),
           });
        
        
    }

    ngAfterContentInit() {
        console.log("suda smotret000");
        console.log(this.categories);
    }

    addArticle(){
        if (!this.form.valid)
            return;
    }
}