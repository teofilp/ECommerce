// See https://aka.ms/new-console-template for more information

using ECommerce.Business;
using ECommerce.Business.Handlers;
using ECommerce.Consumers;
using ECommerce.UI.Commands;
using ECommerce.UI.Menu;
using MassTransit;
using PingCommand = ECommerce.UI.Commands.PingCommand;

using var app =  new WebHostBuilder()
    .ConfigureServices(services =>
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQueryHandler>());

        services.AddMassTransit(x =>
        {
            x.AddConsumers(typeof(PingConsumer).Assembly);
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("user");
                    h.Password("password");
                });
            });
        });
        
        services.AddSingleton<Menu>();
        services.AddSingleton<ProductsService>();
        
        services.AddTransient<ICommand, GetAllProductsCommand>();
        services.AddTransient<ICommand, PingCommand>();
    })
    .Build();
    
    await app.StartAsync();

    // var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();
    // var menu = host.Services.GetRequiredService<Menu>();
    //
    // await menu!.Run();
    //
    // lifetime.StopApplication();
    // await host.WaitForShutdownAsync();