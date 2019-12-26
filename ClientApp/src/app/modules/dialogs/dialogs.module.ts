import { DialogOKComponent } from './components/dialog-ok/dialog-ok.component';
import { MatDialogModule } from '@angular/material/dialog';
import { NgModule } from '@angular/core';
import { DialogErrorComponent } from './components/dialog-error/dialog-error.component';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [DialogOKComponent, DialogErrorComponent],
  imports: [MatDialogModule, MatButtonModule ],
  exports: [DialogOKComponent, DialogErrorComponent],
  providers: [],
  entryComponents: [DialogOKComponent, DialogErrorComponent]
})
export class MyDialogModule { }
