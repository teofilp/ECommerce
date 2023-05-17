using ECommerce.Data.Models;

namespace ECommerce.Business;

public class ProductsService
{
    private List<Product> _products = new()
    {
        new Product
        {
            Id = 1, Name = "Apple iPhone 13", Description = "Latest model of the iPhone series.", Price = 699.99,
            AvailableQuantity = 50
        },
        new Product
        {
            Id = 2, Name = "Samsung Galaxy S21", Description = "High-end Android smartphone.", Price = 799.99,
            AvailableQuantity = 70
        },
        new Product
        {
            Id = 3, Name = "HP Envy Laptop", Description = "Powerful laptop with Intel i7.", Price = 999.99,
            AvailableQuantity = 30
        },
        new Product
        {
            Id = 4, Name = "Sony PlayStation 5", Description = "Latest gaming console from Sony.", Price = 499.99,
            AvailableQuantity = 20
        },
        new Product
        {
            Id = 5, Name = "Nintendo Switch", Description = "Hybrid console for gaming on the go.", Price = 299.99,
            AvailableQuantity = 45
        },
        new Product
        {
            Id = 6, Name = "Apple AirPods Pro", Description = "Wireless bluetooth earbuds.", Price = 249.99,
            AvailableQuantity = 60
        },
        new Product
        {
            Id = 7, Name = "Fitbit Charge 4", Description = "Fitness and health tracker.", Price = 149.99,
            AvailableQuantity = 75
        },
        new Product
        {
            Id = 8, Name = "Amazon Echo Dot", Description = "Compact smart speaker with Alexa.", Price = 49.99,
            AvailableQuantity = 80
        },
        new Product
        {
            Id = 9, Name = "Dell Ultrasharp Monitor", Description = "27-inch 4K monitor.", Price = 579.99,
            AvailableQuantity = 25
        },
        new Product
        {
            Id = 10, Name = "Canon EOS 5D Mark IV", Description = "Professional DSLR camera.", Price = 2599.99,
            AvailableQuantity = 10
        }
    };

    public Task<List<Product>> GetAll()
    {
        return Task.FromResult(_products);
    }
}