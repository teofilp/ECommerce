using ECommerce.API.Extensions;
using ECommerce.Contracts;
using MassTransit;
using MediatR;
using static ECommerce.API.Endpoints;

namespace ECommerce.API.Handlers;

public class AddProductCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class AddProduct : IRequestHandler<AddProductCommand, bool>
{
    private readonly HttpClient _httpClient;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public AddProduct(IHttpClientFactory factory, IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
        _httpClient = factory.CreateClient();
    }

    public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync($"{ProductsServiceEndpoint}/products", request, cancellationToken);
        var result = await response.GetResult<Guid>();

        await SendProductPrice(result.Data, request.Price);
        await SendProductStock(result.Data, request.Stock);
        
        return true;
    }

    private async Task SendProductPrice(Guid productId, decimal price)
    {
        await _publishEndpoint.Publish<AddProductPrice>(new()
        {   
            ProductId = productId,
            Price = price
        });
    }

    private async Task SendProductStock(Guid productId, int stock)
    {
        await _publishEndpoint.Publish<AddProductStock>(new()
        {
            ProductId = productId,
            Stock = stock
        });
    }
}