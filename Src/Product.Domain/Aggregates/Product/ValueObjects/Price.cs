using Product.Domain.Aggregates.Product.Exceptions;
using Product.Domain.Shared.Base;

namespace Product.Domain.Aggregates.Product.ValueObjects;

public class Price : ValueObject
{
    public int Value { get; }
    public Currency Currency { get; }
    
    public Price(int price , Currency currency)
    {
        if (price is 0)
            throw new InvalidPriceException("price can not be 0");
        
        if(price < 0)
            throw new InvalidPriceException("price can not be negative");
        
        Value = price;
        Currency = currency;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
    
   
}