using ECommerce.Contracts;
using MassTransit;

namespace ECommerce.Consumers;

public class PingConsumer : IConsumer<Ping>
{
    public Task Consume(ConsumeContext<Ping> context)
    {
        Console.WriteLine(context.Message);
        
        return Task.CompletedTask;
    }
}