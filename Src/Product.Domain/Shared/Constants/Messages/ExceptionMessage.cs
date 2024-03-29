namespace Product.Domain.Shared.Constants.Messages;

public struct ExceptionMessage
{
    public static readonly string InvalidIp = "Ip is invalid";
    public static readonly string IpIsMandatory = "The IpAddress cannot be null or empty.";
    public static string IpLenghtShouldBe(int lenght) => $"The IpAddress length must be {lenght} characters.";
}