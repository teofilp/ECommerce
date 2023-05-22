using ECommerce.API.Handlers;
using ECommerce.API.Models;
using ECommerce.API.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

[ApiController()]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMediator _mediator;

    public ProductsController(IHttpClientFactory httpClientFactory, IMediator mediator)
    {
        _httpClientFactory = httpClientFactory;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        var client = _httpClientFactory.CreateClient();
        var result = await client.GetFromJsonAsync<List<Product>>("https://localhost:7010/products");

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> AddProduct(AddProductRequest product)
    {
        return await _mediator.Send(new AddProductCommand()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock
        });
    }
}