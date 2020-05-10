export class ArticlePageParams{
    TitleContains: String = "";
    CategoryId: number = -1;
    pageSize: number;
    pageNumber: number;
    Tags: String = "";
    MinDate: number = 0;
    MaxDate: number = 1;
}
