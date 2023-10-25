using System.Net;
using Product.Domain.Exceptions;

namespace Product.Domain.Entities;

public abstract class BaseModel<T> 
{
    public T Id { get;  set; }
    public long CreateDate { get; private set; }
    public long? UpdateDate { get; private set; }
    public long? DeleteDate { get; private set; }
    public string? CreateIp { get; private set; }
    public string? UpdateIp { get; private set; }
    public string? DeleteIp { get; private set; }

    public virtual void Create(string? ip = null)
    {
        this.CreateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        ValidateIp(ip);
        this.CreateIp = ip;
    }
    
    public virtual void Update(string? ip = null)
    {
        this.UpdateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        ValidateIp(ip);
        this.UpdateIp = ip;
    }
    
    public virtual void Delete(string? ip = null)
    {
        this.DeleteDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        ValidateIp(ip);
        this.DeleteIp = ip;
    }

    void ValidateIp(string? ip)
    {
        if(string.IsNullOrWhiteSpace(ip))
            return;
        
        if (!IsIpValid(ip))
            throw new InvalidIpException();
    }
    bool IsIpValid(string ip) => IPAddress.TryParse(ip, out _);
    
}