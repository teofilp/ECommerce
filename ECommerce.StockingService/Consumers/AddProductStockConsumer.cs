using ECommerce.Common.Services;
using ECommerce.Contracts;
using ECommerce.StockingService.Database;
using ECommerce.StockingService.Domain;
using MassTransit;

namespace ECommerce.StockingService.Consumers;

public class AddProductStockConsumer : IConsumer<AddProductStock>
{
    private readonly StockingContext _dbContext;
    private readonly ILogger<AddProductStockConsumer> _logger;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddProductStockConsumer(StockingContext dbContext, ILogger<AddProductStockConsumer> logger, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task Consume(ConsumeContext<AddProductStock> context)
    {
        var message = context.Message;

        _dbContext.Add(new ProductStock
        {
            Stock = message.Stock,
            ProductId = message.ProductId,
            UpdatedAt = _dateTimeProvider.UtcNow
        });
        
        _logger.LogInformation(message.ToString());

        await _dbContext.SaveChangesAsync();
    }
}