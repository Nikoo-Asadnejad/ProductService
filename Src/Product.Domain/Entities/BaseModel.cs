using System.Net;
using Product.Domain.Exceptions;

namespace Product.Domain.Entities;

public abstract class BaseModel<T> 
{
    public T Id { get;  set; }
    public long CreateDate { get; private set; }
    public long? CreatedBy { get; private set; }
    public long? UpdateDate { get; private set; }
    public long? UpdatedBy { get; private set; }
    public long? DeleteDate { get; private set; }
    public long? DeletedBy { get; private set; }
    public string? CreateIp { get; private set; }
    public string? UpdateIp { get; private set; }
    public string? DeleteIp { get; private set; }

    public virtual void Create(string? ip = null , long? createdBy = null)
    {
        this.CreateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.CreatedBy = createdBy;
        ValidateIp(ip);
        this.CreateIp = ip;
    }
    public virtual void Update(string? ip = null, long? updatedBy = null)
    {
        this.UpdateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.UpdatedBy = updatedBy;
        ValidateIp(ip);
        this.UpdateIp = ip;
    }
    public virtual void Delete(string? ip = null, long? deletedBy = null)
    {
        this.DeleteDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.DeletedBy = deletedBy;
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