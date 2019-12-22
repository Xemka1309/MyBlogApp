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
    tagForm: FormGroup;
    private tags: Tag[];
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
        
    }
    ngAfterContentInit() {
        console.log("suda smotret000");
        console.log(this.tags);
    }
    public hasError = (controlName: string, errorName: string) =>{
        return this.tagForm.controls[controlName].hasError(errorName);
    }
    public onCancel = () => {
        
    }
    public clearForm() {
        this.tagForm.controls.value.setValue('');
        
    }
    public addTag(formValue:FormGroup){
        console.log("Creating new tag");
        let tag = new Tag();
        tag.Id = 0;
        tag.Value = formValue.controls.value.value;
        this.tagService.addTag(tag).subscribe((result) => {

        }), error => console.log(error);
        
    }

    
}