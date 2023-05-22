namespace ECommerce.Contracts;

public record AddProductPrice
{
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
}