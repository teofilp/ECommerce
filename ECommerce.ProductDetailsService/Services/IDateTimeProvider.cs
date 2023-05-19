namespace ECommerce.ProductDetailsService.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}