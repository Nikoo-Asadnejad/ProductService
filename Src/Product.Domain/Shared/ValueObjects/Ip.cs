using Product.Domain.Shared.Base;
using Product.Domain.Shared.Constants.Messages;
using Product.Domain.Shared.Exceptions;

namespace Product.Domain.Shared.ValueObjects;

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
            throw new DomainValidationException(ExceptionMessage.IpIsMandatory);
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