using System.ComponentModel.DataAnnotations;
using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = FluentValidation.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Product.Application.Shared;

public sealed class ValidationBehavior<TRequest,TResponse>
                  : IPipelineBehavior<TRequest , TResponse> where TRequest : IRequest
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<TRequest> context = new(request);

        IEnumerable<Task<ValidationResult>> validatesTasks = _validators.Select(validator => validator.ValidateAsync(context));
        ValidationResult[] validationResults = await Task.WhenAll(validatesTasks);

        IEnumerable<ValidationFailure> errors = validationResults.Where(r => !r.IsValid)
                                                                 .SelectMany(r => r.Errors);

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        var response = await next();
        return response;
    }
}