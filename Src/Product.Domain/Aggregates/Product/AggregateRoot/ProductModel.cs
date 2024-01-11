using Product.Domain.Aggregates.Product.Entities;
using Product.Domain.Base;

namespace Product.Domain.Aggregates.ProductAggregate;

public sealed class ProductModel : BaseEntity
{
    public ProductModel(string title, int price, long? categoryId = null, string? subTitle = null,
        string? description = null)
    {
        Title = title;
        SubTitle = subTitle;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }

    public string Title { get; private set; }
    public string? SubTitle { get; private set; }
    public string? Description { get; private set; }
    public int Price { get; private set; }
    public long? CategoryId { get; private set; }

    public CategoryModel Category { get; private set; }

    public IReadOnlyList<ProductComment> ProductComments
    {
        get { return _productComments; }
    }

    private List<ProductComment> _productComments { get; set; }

    public void Update(ProductModel newProduct)
    {
        base.Update(newProduct.CreateIp);
        this.Title = newProduct.Title;
        this.SubTitle = newProduct.SubTitle;
        this.Description = newProduct.Description;
        this.Price = newProduct.Price;
        this.CategoryId = newProduct.CategoryId;
    }
}