namespace Product.Infrastructure.EventBus;

public interface IInternalEventBus
{
    Task PublishAsync<T>(T integrationEvent) where T : IInternalEvent;
}