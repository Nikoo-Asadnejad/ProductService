using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Product.Commands.CreateProduct;
using Product.Application.Product.Queries.GetProduct;

namespace Product.API.Controllers;

[Controller]
public sealed class ProductsController : Controller
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Product(CreateProductCommand command)
    {
        await _mediator.Send(command);
        return  Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Product(GetProductQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}