using ECommerce.Common.Services;
using ECommerce.ProductDetailsService.Database;
using ECommerce.ProductDetailsService.Domain;
using ECommerce.ProductDetailsService.Requests;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.ProductDetailsService.Endpoints;

[AllowAnonymous]
[HttpPost("products")]
public class AddProduct : Endpoint<AddProductRequest>
{
    private readonly IMediator _mediator;
    
    public AddProduct(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task HandleAsync(AddProductRequest req, CancellationToken ct)
    {
        var id = await _mediator.Send(new AddProductCommand
        {
            Name = req.Name,
            Description = req.Description
        }, ct);
        
        await SendOkAsync(id, ct);
    }
}

public class AddProductCommand : IRequest<Guid> {
    public string Name { get; set; }
    public string Description { get; set; }
}

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
{
    private readonly ProductsDetailsContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddProductCommandHandler(ProductsDetailsContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            CreatedAt = _dateTimeProvider.UtcNow
        };
        
        _context.Products.Add(product);

        await _context.SaveChangesAsync(cancellationToken);
        
        return product.Id;
    }
}