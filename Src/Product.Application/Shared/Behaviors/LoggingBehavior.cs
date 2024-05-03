using MediatR;
using Microsoft.Extensions.Logging;

namespace Product.Application.Shared.Behaviors;

public sealed class LoggingBehavior<TRequest , TResponse> : IPipelineBehavior<TRequest , TResponse> 
                    where TRequest : IRequest<TResponse>
{
    private readonly ILogger _logger;
    public LoggingBehavior(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw;
        }
    }
}