namespace ECommerce.Contracts;

public record Ping
{
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}