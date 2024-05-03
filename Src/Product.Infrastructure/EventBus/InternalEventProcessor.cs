using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Product.Infrastructure.EventBus;

public sealed class InternalEventProcessor : BackgroundService
{
    private readonly InMemoryMessageQueue _queue;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public InternalEventProcessor(InMemoryMessageQueue queue, IServiceScopeFactory serviceScopeFactory)
    {
        _queue = queue;
        _serviceScopeFactory = serviceScopeFactory;
    }
    protected  override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (IInternalEvent integrationEvent in  _queue.Reader.ReadAllAsync(stoppingToken))
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();

            IPublisher publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

            await publisher.Publish(integrationEvent, stoppingToken);
        }
    }
}