using Product.Domain.Constants.Messages;
namespace Product.Domain.Exceptions;

public sealed class InvalidIpException : DomainException
{
    public InvalidIpException() : base(message: ExceptionMessage.InvalidIp)
    {
        
    }
}