using MediatR;

namespace Product.Application.Product.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery ,GetProductQueryResponse>
{
    public Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}