using MediatR;

namespace Product.Application.Product.Queries.GetProduct;

public record GetProductQuery(int Id) : IRequest<GetProductQueryResponse>;