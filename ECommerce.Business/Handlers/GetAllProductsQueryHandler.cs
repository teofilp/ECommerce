using ECommerce.Data.Models;
using MediatR;

namespace ECommerce.Business.Handlers;

public class GetAllProductsQuery : IRequest<List<Product>> { }

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly ProductsService _productsService;

    public GetAllProductsQueryHandler(ProductsService productsService)
    {
        _productsService = productsService;
    }

    public Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return _productsService.GetAll();
    }
}