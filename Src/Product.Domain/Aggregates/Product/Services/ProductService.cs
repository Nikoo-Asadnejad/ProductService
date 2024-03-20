using Product.Domain.Aggregates.Product.AggregateRoot;

namespace Product.Domain.Aggregates.Product.Services;

public sealed class ProductService : IProductService
{
    public Task Add(ProductModel productModel)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProductModel productModel)
    {
        throw new NotImplementedException();
    }
}