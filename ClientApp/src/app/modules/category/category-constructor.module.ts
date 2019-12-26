import { NgModule } from '@angular/core';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule} from '@angular/material/input';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CategoryConstructorComponent} from './components/category-constructor/category-constructor.component';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MyDialogModule } from '../dialogs/dialogs.module';


@NgModule({
    declarations: [CategoryConstructorComponent],
    imports: [
        MatInputModule, MatFormFieldModule,
        CommonModule,
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        MatTabsModule,
        MatFormFieldModule,
        MatCardModule,
        MatSelectModule,
        MatButtonModule,
        MyDialogModule
    ],
    exports: [
        CategoryConstructorComponent
    ],
    providers: [],
})
export class CategoryModule {}
