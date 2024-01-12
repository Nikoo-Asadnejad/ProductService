namespace Product.Domain.Aggregates.Product.Exceptions;

public class InvalidCurrencyException : Exception
{
    public InvalidCurrencyException() : base(message: "Currency is not valid")
    {
        
    }
    public InvalidCurrencyException(string msg) : base(message: msg)
    {
        
    }
}