import { Component, OnInit, AfterContentInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { TagService } from 'src/app/services/tag-service';
import { Tag } from '../../models/tag';


@Component({
    selector: 'tag-constructor',
    templateUrl: './tag-constructor.component.html',
    styleUrls: ['./tag-constructor.component.css']
})
export class TagConstructorComponent implements OnInit, AfterContentInit {
    public tagForm: FormGroup;
    public controlForm:FormGroup;
    public tabInd:number;
    public cardTitle:String = "Create new tag";
    public constructorMode:String = "NEW";
    public tags: Tag[];
    
    constructor(private tagService: TagService)  
    {

    }
    ngOnInit(): void 
    {
        this.tagService.getTags().subscribe( (result:Tag[]) =>{
            this.tags = result;
        } ), error => console.log(error);
        this.tagForm = new FormGroup({
            value : new FormControl()
        });
        this.controlForm = new FormGroup({
            tagId:new FormControl()
        });
        
    }
    ngAfterContentInit() {
        console.log("suda smotret000");
        console.log(this.tags);
    }
    public hasError = (formId:number,controlName: string, errorName: string) =>{
        if (formId == 1){
            return this.tagForm.controls[controlName].hasError(errorName);
        }
        if (formId == 2){
            return this.controlForm.controls[controlName].hasError(errorName);
        }
        
    }
    public onCancel = () => {
        
    }
    public clearForm() {
        this.tagForm.controls.value.setValue('');
        
    }
    public performAction(formValue:FormGroup){
        
        let tag = new Tag();
        tag.Id = 0;
        tag.Value = formValue.controls.value.value;
        if (this.constructorMode == "NEW"){
            this.tagService.addTag(tag).subscribe((result) => {
            }), error => console.log(error);
            return;
        }
        if (this.constructorMode == "EDIT"){
            this.tagService.editTag(this.controlForm.controls.tagId.value,tag).subscribe(result => {
            }), error => console.log(error);

        }
        
        
    }
    public selectDeleteTag(formValue:FormGroup){

    }
    public selectEditTag(formValue:FormGroup){
        this.cardTitle = "Edit tag";
        this.constructorMode = "EDIT";
        this.tabInd = 0;
        this.tagForm.controls.value.setValue(this.tags.find(t => t.Id == this.controlForm.controls.tagId.value).Value);
    }
    public selectAddTag(){
        this.cardTitle = "Create new tag";
        this.constructorMode = "NEW";
        this.tabInd = 0;
    }

    
}