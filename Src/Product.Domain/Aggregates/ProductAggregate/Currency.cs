using Product.Domain.Base;

namespace Product.Domain.Aggregates.ProductAggregate;

public class Currency : ValueObject
{
    public string Value { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}