using System.Threading.Channels;

namespace Product.Infrastructure.EventBus;

public sealed class InMemoryMessageQueue
{
    public readonly Channel<IIntegrationEvent> _channel = Channel.CreateUnbounded<IIntegrationEvent>();

    public  ChannelReader<IIntegrationEvent> Reader => _channel.Reader;
    public  ChannelWriter<IIntegrationEvent> Writer => _channel.Writer;
}