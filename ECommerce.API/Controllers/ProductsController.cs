using ECommerce.Business;
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

[ApiController()]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        var client = _httpClientFactory.CreateClient();
        var result = await client.GetFromJsonAsync<List<Product>>("https://localhost:7010/products");

        return Ok(result);
    }
}