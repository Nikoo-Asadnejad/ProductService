using FluentValidation;

namespace Product.Application.Product.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        
        RuleFor(command => command.Title)
            .NotEmpty()
            .NotNull()
            .WithMessage("The title can't be empty.");
        
        RuleFor(command => command.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("The description can't be empty.");
        
        RuleFor(command => command.CategoryId)
            .NotEqual(0)
            .NotEmpty()
            .NotNull()
            .WithMessage("The category identifier can't be empty.");
    }
}