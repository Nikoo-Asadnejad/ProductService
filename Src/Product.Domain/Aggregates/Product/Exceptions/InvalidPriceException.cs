namespace Product.Domain.Aggregates.Product.Exceptions;

public class InvalidPriceException : Exception
{
    public InvalidPriceException() : base(message: "Price is not valid")
    {
        
    }
    public InvalidPriceException(string msg) : base(message: msg)
    {
        
    }
}