using MassTransit;

namespace ECommerce.Contracts;

public record AddProductStock : CorrelatedBy<Guid>
{
    public Guid ProductId { get; set; }
    public int Stock { get; set; }

    public Guid CorrelationId => ProductId;
}