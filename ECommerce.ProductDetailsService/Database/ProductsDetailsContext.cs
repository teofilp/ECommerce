using ECommerce.ProductDetailsService.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductDetailsService.Database;

public class ProductsDetailsContext : DbContext
{
    public ProductsDetailsContext(DbContextOptions options) : base(options) {}
    
    public DbSet<Product> Products { get; set; }  
}