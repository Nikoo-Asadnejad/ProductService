using Product.Domain.Constants.Messages;

namespace Product.Domain.Exceptions.Genrals;

public sealed class InvalidIpException : DomainValidationException
{
    public InvalidIpException() : base(message: ExceptionMessage.InvalidIp)
    {
        
    }
}