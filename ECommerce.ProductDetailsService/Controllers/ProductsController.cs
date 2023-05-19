using ECommerce.Business;
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ProductDetailsService.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        return Ok(await _productsService.GetAll());
    }
}