using Product.Domain.Exceptions;
using Product.Domain.ValueObjects;

namespace Product.Domain;

public class Price : ValueObject
{
    public int Value { get; private set; }
    public Currency Currency { get; private set; }
    
    public Price()
    {
        
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }

    private void SetValue(int value)
    {
        if (value is 0)
            throw new DomainValidationException("price can not be 0");
        
        if(value < 0)
            throw new DomainValidationException("price can not be negative");

        Value = value;
    }
   
}