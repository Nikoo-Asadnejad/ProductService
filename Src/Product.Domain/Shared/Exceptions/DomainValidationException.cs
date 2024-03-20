namespace Product.Domain.Shared.Exceptions;

public class DomainValidationException : Exception
{
    public DomainValidationException(string message) : base(message)
    {
        
    }
}