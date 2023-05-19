using ECommerce.ProductDetailsService.Database;
using ECommerce.ProductDetailsService.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductDetailsService.Endpoints;

[HttpGet("products")]
[AllowAnonymous]
public class GetProducts : EndpointWithoutRequest
{
    private readonly ProductsDetailsContext _context;

    public GetProducts(ProductsDetailsContext context)
    {
        _context = context;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var items = await _context.Products
            .Select(item => new ProductInfo
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            })
            .ToListAsync(ct);

        await SendOkAsync(items, ct);
    }
}