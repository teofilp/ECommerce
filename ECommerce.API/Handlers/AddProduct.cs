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
    
    public AddProduct(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var productId = await _httpClient.PostAsJsonAsync($"{ProductsServiceEndpoint}/products", request, cancellationToken);

        return true;
    }
}