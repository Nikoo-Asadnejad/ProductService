using Product.Domain.Shared.Constants.Messages;

namespace Product.Domain.Shared.Exceptions;

public sealed class InvalidIpException : DomainValidationException
{
    public InvalidIpException() : base(message: ExceptionMessage.InvalidIp)
    {
        
    }
}