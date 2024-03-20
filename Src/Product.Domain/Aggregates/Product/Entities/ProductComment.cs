using Product.Domain.Shared.Base;

namespace Product.Domain.Aggregates.Product.Entities;

public class ProductComment : BaseEntity
{
    public string Body { get; set; }

}