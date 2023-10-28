using System.Security;
using Product.Domain.Constants.Messages;
using Product.Domain.Exceptions;

namespace Product.Domain.ValueObjects;

public class Ip : ValueObject
{
    private const int Lenght = 15;
    public string Value{ get;private set; }

    public Ip(string ip)
    {
        SetValue(ip);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private void SetValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainValidationException(ExceptionMessage.IpIsMandatry);
        }

        if (value.Length > Lenght || value.Length < Lenght)
        {
            throw new DomainValidationException(ExceptionMessage.IpLenghtShouldBe(Lenght));
        }
        
        if (IsIpValid(value))
        {
            throw new InvalidIpException();
        }

        Value = value;
    }
    
    bool IsIpValid(string ip) => System.Net.IPAddress.TryParse(ip, out _);
}