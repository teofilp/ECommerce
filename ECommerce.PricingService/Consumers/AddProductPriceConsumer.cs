using ECommerce.Common.Services;
using ECommerce.Contracts;
using ECommerce.PricingService.Database;
using ECommerce.PricingService.Domain;
using MassTransit;

namespace ECommerce.PricingService.Consumers;

public class AddProductPriceConsumer : IConsumer<AddProductPrice>
{
    private readonly PricingContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ILogger<AddProductPriceConsumer> _logger;

    public AddProductPriceConsumer(PricingContext dbContext, ILogger<AddProductPriceConsumer> logger, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task Consume(ConsumeContext<AddProductPrice> context)
    {
        var message = context.Message;
        
        _dbContext.Add(new ProductPrice
        {
            Price = message.Price,
            ProductId = message.ProductId,
            UpdatedAt = _dateTimeProvider.UtcNow
        });

        _logger.LogInformation(message.ToString());
        
        await _dbContext.SaveChangesAsync();
    }
}