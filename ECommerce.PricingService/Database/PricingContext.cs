using ECommerce.PricingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.PricingService.Database;

public class PricingContext : DbContext
{
    public PricingContext(DbContextOptions options) : base(options) {}
    
    public DbSet<ProductPrice> ProductPrices { get; set; }
}