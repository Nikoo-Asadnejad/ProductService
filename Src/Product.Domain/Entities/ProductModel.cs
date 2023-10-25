namespace Product.Domain.Entities;

public sealed class ProductModel : BaseModel<long>
{

    public ProductModel(string title, int price ,string? subTitle = null, string? description = null)
    {
        base.Create();
        Title = title;
        SubTitle = subTitle;
        Description = description;
        Price = price;
    }

    public string Title { get; private set; }
    public string? SubTitle { get; private set; }
    public string? Description { get; private set; }
    public int Price { get; private set; }
    
    public void Update(ProductModel newProduct)
    {
        base.Update(newProduct.CreateIp);
        this.Title = newProduct.Title;
        this.SubTitle = newProduct.SubTitle;
        this.Description = newProduct.Description;
        this.Price = newProduct.Price;
    }
}