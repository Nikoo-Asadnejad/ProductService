using Product.Domain.Constants.Messages;
namespace Product.Domain.Exceptions;

public sealed class InvalidIpException : Exception
{
    public InvalidIpException() : base(message: ExceptionMessage.InvalidIp)
    {
        
    }
}