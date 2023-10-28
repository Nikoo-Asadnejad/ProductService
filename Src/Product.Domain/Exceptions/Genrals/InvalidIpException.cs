using Product.Domain.Constants.Messages;
namespace Product.Domain.Exceptions;

public sealed class InvalidIpException : DomainValidationException
{
    public InvalidIpException() : base(message: ExceptionMessage.InvalidIp)
    {
        
    }
}