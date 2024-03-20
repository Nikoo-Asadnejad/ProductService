using Product.Domain.Aggregates.Product.Exceptions;
using Product.Domain.Shared.Base;

namespace Product.Domain.Aggregates.Product.ValueObjects;

public class Currency : ValueObject
{
    public string Value { get; }

    public Currency(string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
            throw new InvalidCurrencyException();

        if (currency.Length is not 3)
            throw new InvalidCurrencyException("Currency lenght should be equal to 3");
        
        Value = currency;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}