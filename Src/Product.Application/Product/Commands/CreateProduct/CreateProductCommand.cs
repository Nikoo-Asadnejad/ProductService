using MediatR;

namespace Product.Application.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest
{
    public CreateProductCommand(string title,
        decimal price,
        string subTitle = default,
        string description = default,
        int categoryId = default)
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
    public decimal Price { get; private set; }
    public int CategoryId { get; private set; }
}