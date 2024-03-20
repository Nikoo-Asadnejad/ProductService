using Product.Domain.Shared.Events;
using Product.Domain.Shared.ValueObjects;

namespace Product.Domain.Shared.Base;

public abstract class BaseEntity
{
    int? _requestedHashCode;
    int _Id;
    public virtual int Id
    {
        get
        {
            return _Id;
        }
        protected set
        {
            _Id = value;
        }
    }
    private List<IDomainEvent> _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();
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

    public void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents = _domainEvents ?? new ();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public bool IsTransient()
    {
        return this.Id == default;
    }

    public override bool Equals(object obj)
    {
        if (obj is not BaseEntity)
            return false;

        if (Object.ReferenceEquals(this, obj))
            return true;

        if (this.GetType() != obj.GetType())
            return false;

        BaseEntity item = (BaseEntity)obj;

        if (item.IsTransient() || this.IsTransient())
            return false;
        else
            return item.Id == this.Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }
    
    public static bool operator ==(BaseEntity left, BaseEntity right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }
    
    public static bool operator !=(BaseEntity left, BaseEntity right)
    {
        return !(left == right);
    }
}


