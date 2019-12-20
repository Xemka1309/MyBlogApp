import { Category } from "../../category/models/category";

export class Article {
    id:number;
    title:String;
    description:String;
    content:String;
    categoryId:number;
    category:String;
    picsUrl:String;
}