import { Component, OnInit, AfterContentInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category-service';
import { Category } from '../../models/category';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { DialogOKComponent } from 'src/app/modules/dialogs/components/dialog-ok/dialog-ok.component';
import { DialogErrorComponent } from 'src/app/modules/dialogs/components/dialog-error/dialog-error.component';
import { HttpHeaderResponse } from '@angular/common/http';
@Component({
  selector: "category-constructor",
  templateUrl: './category-constructor.component.html',
  styleUrls: ['./category-constructor.component.css']
})
export class CategoryConstructorComponent implements OnInit {
  private dialogConfig;
  public categoryForm: FormGroup;
  public controlForm: FormGroup;
  public tabInd: number;
  public cardTitle: String = 'Create new category';
  public constructorMode: String = 'NEW';
  public categories: Category[];
  private buttonText: String = 'Add category';
  constructor(private categoryService: CategoryService, private dialog: MatDialog) { }
  public loadCategories() {
    this.categoryService.getCategories().subscribe((result: Category[]) => {
      this.categories = result;
    }), error => console.log(error);
  }
  public ngOnInit(): void {
    this.loadCategories();
    console.log(this.categories);
    this.categoryForm = new FormGroup({
      name: new FormControl(),
      descr: new FormControl()
    });
    this.controlForm = new FormGroup({
      categoryId: new FormControl()
    });
    this.dialogConfig = {
      height: '200px',
      width: '400px',
      disableClose: true,
      data: {}
    };
  }

  public CheckUniqueNameValue(value: String): boolean {
    for (const category of this.categories) {
      if (category.Name == value) {
        return false;
      }
    }
    return true;
  }

  public performAction() {
    if (!this.categoryForm.valid) { return; }
    const category: Category = new Category();
    category.Id = 0;
    category.Description = this.categoryForm.value.descr;
    category.Name = this.categoryForm.value.name;

    if (this.constructorMode == 'NEW') {
      if (!this.CheckUniqueNameValue(category.Name)) {
        this.showDialog(false, "Can't add category", 'Category with that name already exists');
        return;
      }
      this.categoryService.addCategory(category).subscribe((result: HttpHeaderResponse) => {
        if (result.status === 200) {
          this.showDialog(true, 'Add ok', 'Category was added');
          this.loadCategories();
          this.clearForm();
          this.tabInd = 1;
          return;
        } else {
          this.showDialog(false, "Can't add category", 'category was not added');
          return;
        }
      });
    }
    if (this.constructorMode == 'EDIT') {
      this.categoryService
        .editCategory(this.controlForm.controls.categoryId.value, category)
        .subscribe((result: HttpHeaderResponse) => {
          if (result.status === 200) {
            this.showDialog(true, 'Edit ok', 'Category was edited');
            this.loadCategories();
            this.clearForm();
            this.tabInd = 1;
            return;
          } else {
            this.showDialog(false, "Can't edit", 'category was not edited');
            return;
          }
        });
    }
  }
  public hasError = (
    formId: number,
    controlName: string,
    errorName: string
  ) => {
    if (formId === 1) {
      return this.categoryForm.controls[controlName].hasError(errorName);
    }
    if (formId === 2) {
      return this.controlForm.controls[controlName].hasError(errorName);
    }
  }
  public selectAddCategory() {
    this.constructorMode = 'NEW';
    this.cardTitle = 'Add new category';
    this.tabInd = 0;
  }
  public selectEditCategory() {
    this.constructorMode = 'EDIT';
    this.cardTitle = 'Edit existing category';
    this.tabInd = 0;
    const category = this.categories.find(
      c => c.Id == this.controlForm.controls.categoryId.value
    );
    this.categoryForm.controls.name.setValue(category.Name);
    this.categoryForm.controls.descr.setValue(category.Description);
  }
  public clearForm() {
    this.categoryForm.controls.name.setValue('');
    this.categoryForm.controls.descr.setValue('');
  }
  public selectDeleteCategory() {
    this.categoryService
      .deleteCategory(this.categoryForm.controls.categoryId.value)
      .subscribe((result: HttpHeaderResponse) => {
        if (result.status === 200) {
          this.showDialog(true, 'Delete ok', 'Category was deleted')
          this.clearForm();
          this.tabInd = 1;
        } else {
          this.showDialog(false, "Can't delete", 'category was not deleted');

        }
      });
  }
  public onCancel() {
    this.tabInd = 1;
    this.clearForm();
  }
  public showDialog(ok: boolean, title: String, message: String) {
    this.dialogConfig.data = {
      'message': message,
      'title': title
    };
    if (ok) {
      const dialogRef = this.dialog.open(DialogOKComponent, this.dialogConfig);
    } else {
      const dialogRef = this.dialog.open(DialogErrorComponent, this.dialogConfig);
    }

  }
}
