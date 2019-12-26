import { Component, OnInit, AfterContentInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { TagService } from 'src/app/services/tag-service';
import { Tag } from '../../models/tag';
import { HttpResponse, HttpHeaderResponse } from '@angular/common/http';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DialogOKComponent } from 'src/app/modules/dialogs/components/dialog-ok/dialog-ok.component';
import { DialogErrorComponent } from 'src/app/modules/dialogs/components/dialog-error/dialog-error.component';

@Component({
  selector: 'tag-constructor',
  templateUrl: './tag-constructor.component.html',
  styleUrls: ['./tag-constructor.component.css']
})
export class TagConstructorComponent implements OnInit, AfterContentInit {
  private dialogConfig;
  public tagForm: FormGroup;
  public controlForm: FormGroup;
  public tabInd: number;
  public cardTitle: String = 'Create new tag';
  public constructorMode: String = 'NEW';
  public tags: Tag[];

  constructor(private tagService: TagService, private dialog: MatDialog) {

  }
  ngOnInit(): void {

    this.loadTags();

    this.tagForm = new FormGroup({
      value: new FormControl()
    });

    this.controlForm = new FormGroup({
      tagId: new FormControl()
    });

    this.dialogConfig = {
      height: '200px',
      width: '400px',
      disableClose: true,
      data: {}
    };
  }
  ngAfterContentInit() {
    console.log(this.tags);
  }
  public hasError = (
    formId: number,
    controlName: string,
    errorName: string
  ) => {
    if (formId == 1) {
      return this.tagForm.controls[controlName].hasError(errorName);
    }
    if (formId == 2) {
      return this.controlForm.controls[controlName].hasError(errorName);
    }
  }

  public onCancel() {
    this.tabInd = 1;
  }

  public CheckUniqueTagValue(value: String): boolean {
    for (const tag of this.tags) {
      if (tag.Value == value) {
        return false;
      }
    }
    return true;
  }

  public clearForm() {
    this.tagForm.controls.value.setValue('');
  }

  public loadTags() {
    this.tagService.getTags().subscribe((result: Tag[]) => {
      this.tags = result;
    }),error => console.log(error);

  }
  public performAction(formValue: FormGroup) {
    const tag = new Tag();
    tag.Id = 0;
    tag.Value = formValue.controls.value.value;
    if (this.constructorMode === 'NEW') {
      if (!this.CheckUniqueTagValue(tag.Value)) {
        this.showDialog(false, "Can't add tag", 'Tag with that value already exists');
        return;
      }
      this.tagService.addTag(tag).subscribe((result: HttpHeaderResponse) => {
        if (result.status === 200) {
          this.showDialog(true, 'Action performed', 'Tag was added');
          this.loadTags();
          this.clearForm();
          this.tabInd = 1;
        } else {
          this.showDialog(false, "Can't add tag", result.headers.get('errorMessage'));
        }
      });
      return;
    }
    if (this.constructorMode === 'EDIT') {
      this.tagService
        .editTag(this.controlForm.controls.tagId.value, tag)
        .subscribe((result: HttpHeaderResponse) => {
          if (result.status === 200) {
            this.showDialog(true, 'Action performed', 'Tag was edited');
            this.loadTags();
            this.tabInd = 1;
            this.clearForm();
            this.constructorMode = 'NEW';

          } else {
            this.showDialog(false, "Can't edit tag", result.headers.get('errorMessage'));
          }
        });
      return;
    }

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

  public selectDeleteTag(formValue: FormGroup) {
    const id = this.controlForm.controls.tagId.value;
    this.tagService.removeTag(id).subscribe( (result: HttpHeaderResponse) => {
      if (result.status === 200) {
        this.showDialog(true, 'Action performed', 'Tag was deleted');
        this.loadTags();

      } else {
        this.showDialog(false, "Can't delete tag", '0');
      }
    });
  }

  public selectEditTag(formValue: FormGroup) {
    this.cardTitle = 'Edit tag';
    this.constructorMode = 'EDIT';
    this.tabInd = 0;
    this.tagForm.controls.value.setValue(
      this.tags.find(t => t.Id == this.controlForm.controls.tagId.value).Value
    );
  }

  public selectAddTag() {
    this.cardTitle = 'Create new tag';
    this.constructorMode = 'NEW';
    this.tabInd = 0;
  }
}
