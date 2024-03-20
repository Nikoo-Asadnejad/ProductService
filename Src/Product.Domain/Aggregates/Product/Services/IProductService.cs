using Product.Domain.Aggregates.Product.AggregateRoot;

namespace Product.Domain.Aggregates.Product.Services;

public interface IProductService
{
    Task Add(ProductModel productModel);
    
    Task Update(ProductModel productModel);

}