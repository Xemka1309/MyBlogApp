import { Category } from "../../category/models/category";

export class Article {
    id:number;
    title:String;
    description:String;
    content:String;
    category:Category;
    picsUrl:String;
    publishTime:Date;
    tags:Tag[];
}