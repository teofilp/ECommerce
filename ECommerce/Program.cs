// See https://aka.ms/new-console-template for more information

using ECommerce.Business;
using ECommerce.Business.Handlers;
using ECommerce.UI.Commands;
using ECommerce.UI.Menu;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQueryHandler>());
        services.AddHostedService<MenuService>();
        services.AddSingleton<ProductsService>();
        
        services.AddTransient<ICommand, GetAllProductsCommand>();
    })
    .Build()
    .StartAsync();