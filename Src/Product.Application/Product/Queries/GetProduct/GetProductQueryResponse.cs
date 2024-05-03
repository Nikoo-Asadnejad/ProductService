namespace Product.Application.Product.Queries.GetProduct;
public class GetProductQueryResponse
{
    public GetProductQueryResponse(string title , string subTitle , string description , string category)
    {
        Title = title;
        SubTitle = subTitle;
        Description = description;
        Category = category;
    }

    public string Title { get; }
    public string? SubTitle { get;}
    public string? Description { get; }
    public string Category { get; }
    
}