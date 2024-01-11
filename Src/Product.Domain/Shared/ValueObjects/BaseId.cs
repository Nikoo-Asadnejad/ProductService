namespace Product.Domain.Base;

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