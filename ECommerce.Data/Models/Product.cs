namespace ECommerce.Data.Models;

public record Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int AvailableQuantity { get; set; }
}