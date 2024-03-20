using FluentValidation;
using MediatR;

namespace Product.Application.Product.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IValidator<CreateProductCommand> _validator;
    public CreateProductCommandHandler(IValidator<CreateProductCommand>  validator)
    {
        _validator = validator;
    }
    public Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(command);
        throw new NotImplementedException();
    }
}