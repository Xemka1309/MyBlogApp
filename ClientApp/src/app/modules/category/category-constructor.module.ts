import { NgModule } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {CategoryConstructorComponent} from './components/category-constructor/category-constructor.component';
import { CommonModule } from '@angular/common';  
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';


@NgModule({
    declarations: [CategoryConstructorComponent],
    imports: [MatInputModule, MatFormFieldModule, CommonModule, BrowserModule, FormsModule, ReactiveFormsModule],
    exports: [CategoryConstructorComponent],
    providers: [],
})
export class CategoryModule {}