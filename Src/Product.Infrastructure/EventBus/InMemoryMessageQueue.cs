using System.Threading.Channels;

namespace Product.Infrastructure.EventBus;

public sealed class InMemoryMessageQueue
{
    public readonly Channel<IInternalEvent> _channel = Channel.CreateUnbounded<IInternalEvent>();

    public  ChannelReader<IInternalEvent> Reader => _channel.Reader;
    public  ChannelWriter<IInternalEvent> Writer => _channel.Writer;
}