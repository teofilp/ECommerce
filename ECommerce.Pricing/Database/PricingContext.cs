using ECommerce.Pricing.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Pricing.Database;

public class PricingContext : DbContext
{
    public PricingContext(DbContextOptions options) : base(options) {}
    
    public DbSet<ProductPrice> ProductPrices { get; set; }
}