namespace ECommerce.StockingService.Domain;

public class ProductStock
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid? UserId { get; set; }
    public int Stock { get; set; }
    public DateTime UpdatedAt { get; set; }
}