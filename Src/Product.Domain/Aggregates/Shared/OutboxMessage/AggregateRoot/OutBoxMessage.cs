using System.Text.Json;
using Product.Domain.Shared.Base;
using Product.Domain.Shared.Events;

namespace Product.Domain.Aggregates.Shared.OutboxMessage.AggregateRoot;

public class OutBoxMessage : BaseEntity
{
    public OutBoxMessage(string type , string content)
    {
        Type = type;
        Content = content;
    }
    public OutBoxMessage(IDomainEvent domainEvent)
    {
        Type = domainEvent.GetType().Name;
        Content = JsonSerializer.Serialize(domainEvent);
    }

    public string Type { get; private set; }
    public string Content { get; private set; }
}