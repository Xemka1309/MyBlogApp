import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { TagConstructorComponent } from './components/tag-constructor-component/tag-constructor.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MyDialogModule } from '../dialogs/dialogs.module';

@NgModule({
  declarations: [TagConstructorComponent],
  imports: [
    BrowserModule,
    RouterModule,
    HttpClientModule,
    MatCardModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatTabsModule,
    MyDialogModule
  ],
  providers: [],
  exports: [TagConstructorComponent]
})
export class TagModule {}
