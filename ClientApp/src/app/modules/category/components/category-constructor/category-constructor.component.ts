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
    loadCategories(){
        this.categoryService.getCategories().subscribe( (result:Category[]) =>{
            this.categories = result;
        } ), error => console.log(error);
    }
    ngOnInit(): void 
    {
        this.loadCategories();
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
        category.Id = 0
        category.Description = this.form.value.descr;
        category.Name = this.form.value.val;
        this.categoryService.addCategory(category).subscribe();
        this.loadCategories();
    }
}
