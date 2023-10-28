
using Product.Domain.Exceptions;
using Product.Domain.ValueObjects;

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
    public Ip? CreateIp { get; private set; }
    public Ip? UpdateIp { get; private set; }
    public Ip? DeleteIp { get; private set; }

    public virtual void Create(string? ip = null , long? createdBy = null)
    {
        this.CreateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.CreatedBy = createdBy;
        this.CreateIp = new Ip(ip);
    }
    public virtual void Update(string? ip = null, long? updatedBy = null)
    {
        this.UpdateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.UpdatedBy = updatedBy;
        this.UpdateIp = new Ip(ip);
    }
    public virtual void Delete(string? ip = null, long? deletedBy = null)
    {
        this.DeleteDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.DeletedBy = deletedBy;
        this.DeleteIp = new Ip(ip);
    }
    public virtual void Create(Ip? ip = null , long? createdBy = null)
    {
        this.CreateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.CreatedBy = createdBy;
        this.CreateIp = ip;
    }
    public virtual void Update(Ip? ip = null, long? updatedBy = null)
    {
        this.UpdateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.UpdatedBy = updatedBy;
        this.UpdateIp =  ip;
    }
    public virtual void Delete(Ip? ip = null, long? deletedBy = null)
    {
        this.DeleteDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.DeletedBy = deletedBy;
        this.DeleteIp = ip;
    }
    
}