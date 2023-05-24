using ECommerce.StockingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.StockingService.Database;

public class StockingContext : DbContext
{
    public StockingContext(DbContextOptions options) : base(options) {}
    
    public DbSet<ProductStock> ProductStocks { get; set; } 
}