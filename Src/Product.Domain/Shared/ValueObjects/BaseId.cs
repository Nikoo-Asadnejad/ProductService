using Product.Domain.Shared.Base;

namespace Product.Domain.Shared.ValueObjects;

public class BaseId<T> : ValueObject
{
    public T Id { get; }

    public BaseId(T id)
    {
        Id = id;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}