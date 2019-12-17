import { Component, OnInit, AfterContentInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category-service';
import { Category } from '../../models/category';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'category-constructor',
    templateUrl: './category-constructor.component.html',
    styleUrls: ['./category-constructor.component.css']
})
export class CategoryConstructorComponent implements OnInit, AfterContentInit {
    form: FormGroup;
    private categories: Category[];
    private buttonText: String = "Add category"
    constructor(private categoryService: CategoryService) 
    {

    }
    ngOnInit(): void 
    {
        this.categories = this.categoryService.getCategories();
        console.log(this.categories);
        this.form = new FormGroup({
            val: new FormControl(),
            id: new FormControl(),
            descr: new FormControl()
           });
        
        
    }

    ngAfterContentInit() {
        console.log("suda smotret000");
        console.log(this.categories);
    }

    addCategory(){
        if (!this.form.valid)
            return;
        let category: Category = new Category();
        category.id = this.form.value.id;
        category.description = this.form.value.descr;
        category.value = this.form.value.val;
        this.categoryService.addCategory(category);
        this.categories = this.categoryService.getCategories();
    }
}
