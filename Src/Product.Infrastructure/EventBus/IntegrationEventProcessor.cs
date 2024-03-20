using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Product.Infrastructure.EventBus;

public sealed class IntegrationEventProcessor : BackgroundService
{
    private readonly InMemoryMessageQueue _queue;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public IntegrationEventProcessor(InMemoryMessageQueue queue, IServiceScopeFactory serviceScopeFactory)
    {
        _queue = queue;
        _serviceScopeFactory = serviceScopeFactory;
    }
    protected  override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (IIntegrationEvent integrationEvent in  _queue.Reader.ReadAllAsync(stoppingToken))
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();

            IPublisher publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

            await publisher.Publish(integrationEvent, stoppingToken);
        }
    }
}