namespace Product.Infrastructure.EventBus;

public class InternalEventBus : IInternalEventBus
{

    private readonly InMemoryMessageQueue _queue;

    public InternalEventBus(InMemoryMessageQueue queue)
    {
        _queue = queue;
    }

    public async Task PublishAsync<T>(T internalEvent) where T: IInternalEvent
    {
        await _queue.Writer.WriteAsync(internalEvent);
    }
}