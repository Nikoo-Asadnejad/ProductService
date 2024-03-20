using MediatR;

namespace Product.Application.Shared;

public sealed class ValidationBehavior<TRequest,TResponse>
    : IPipelineBehavior<TRequest , TResponse> where TRequest : IRequest
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}