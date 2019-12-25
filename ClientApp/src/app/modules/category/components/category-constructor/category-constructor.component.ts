import { Component, OnInit, AfterContentInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category-service';
import { Category } from '../../models/category';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'category-constructor',
    templateUrl: './category-constructor.component.html',
    styleUrls: ['./category-constructor.component.css']
})
export class CategoryConstructorComponent implements OnInit {
    public categoryForm: FormGroup;
    public controlForm: FormGroup;
    public tabInd:number;
    public cardTitle:String = "Create new tag";
    public constructorMode:String = "NEW";
    public categories: Category[];
    private buttonText: String = "Add category"
    constructor(private categoryService: CategoryService) 
    {

    }
    public loadCategories(){
        this.categoryService.getCategories().subscribe( (result:Category[]) =>{
            this.categories = result;
        } ), error => console.log(error);
    }
    public ngOnInit(): void 
    {
        this.loadCategories();
        console.log(this.categories);
        this.categoryForm = new FormGroup({
            name: new FormControl(),
            descr: new FormControl()
           });
        this.controlForm = new FormGroup({
            categoryId: new FormControl()
        });
        
        
    }

    public performAction(){
        if (!this.categoryForm.valid)
            return;
        let category: Category = new Category();
        category.Id = 0
        category.Description = this.categoryForm.value.descr;
        category.Name = this.categoryForm.value.name;
        if (this.constructorMode == "NEW"){
            this.categoryService.addCategory(category).subscribe(result => {

            }), error => console.log(error);
        }
        if (this.constructorMode == "EDIT"){
            this.categoryService.editCategory(this.controlForm.controls.categoryId.value, category).subscribe(result => {

            }), error => console.log(error);
            
        }
        this.loadCategories();
        this.tabInd = 1;
    }
    public hasError = (formId:number,controlName: string, errorName: string) =>{
        if (formId == 1){
            return this.categoryForm.controls[controlName].hasError(errorName);
        }
        if (formId == 2){
            return this.controlForm.controls[controlName].hasError(errorName);
        }
        
    }
    public selectAddCategory(){
        this.constructorMode = "NEW";
        this.cardTitle = "Add new category";
        this.tabInd = 0;

    }
    public selectEditCategory(){
        this.constructorMode = "EDIT";
        this.cardTitle = "Edit existing category";
        this.tabInd = 0;
        let category = this.categories.find(c => c.Id == this.controlForm.controls.categoryId.value);
        this.categoryForm.controls.name.setValue(category.Name);
        this.categoryForm.controls.descr.setValue(category.Description)

    }
    public selectDeleteCategory(){
        this.categoryService.deleteCategory(this.categoryForm.controls.categoryId.value).subscribe(res =>{

        }), error => console.log(error);

    }
    public onCancel(){
        this.tabInd = 1;
    }
}
