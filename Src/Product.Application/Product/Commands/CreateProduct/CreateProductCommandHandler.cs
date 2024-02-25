using MediatR;

namespace Product.Application.Product.Commands;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}