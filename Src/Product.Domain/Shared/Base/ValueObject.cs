namespace Product.Domain.Shared.Base;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject one, ValueObject two)
        => EqualOperator(one, two);


    public static bool operator !=(ValueObject one, ValueObject two)
        => !EqualOperator(one, two);


    public bool Equals(ValueObject? other)
        => other is not null && ValuesAreEqual(other);


    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        return obj is ValueObject other && ValuesAreEqual(other);
    }

    public override int GetHashCode()
        => GetEqualityComponents()
            .Select(x => x is not null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);


    protected static bool EqualOperator(ValueObject? left, ValueObject? right)
    {
        if (left is null && right is null)
            return true;
        
        if (left is null || right is null)
            return false;
        
        return ReferenceEquals(left, right) || left.Equals(right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    private bool ValuesAreEqual(ValueObject? other)
    =>  other is not null && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    
}