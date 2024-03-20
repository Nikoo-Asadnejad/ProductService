namespace Product.Infrastructure.EventBus;

public interface IEventBus
{
    Task PublishAsync<T>(T integrationEvent) where T : IIntegrationEvent;
}