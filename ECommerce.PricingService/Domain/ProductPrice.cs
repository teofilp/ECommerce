namespace ECommerce.PricingService.Domain;

public class ProductPrice
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid? UserId { get; set; }
    public decimal Price { get; set; }
    public DateTime UpdatedAt { get; set; }
}