using Microsoft.Extensions.DependencyInjection;
using OrderProcessing.Infrastructure.Repositories;
using OrderProcessing.Infrastructure.Services;
using OrderProcessing.Infrastructure.Services.Abstractions;

namespace OrderProcessing.Application;

internal abstract class Program
{
    /// <summary>
    /// Application main entry point.
    /// </summary>
    private static void Main()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();
        var application = serviceProvider.GetService<Application>();
        if (application is null)
            throw new InvalidOperationException("Oh no! Application service not found!");

        application.Run();
    }

    /// <summary>
    /// Service registration.
    /// </summary>
    /// <param name="services">Service collection.</param>
    private static void ConfigureServices(ServiceCollection services)
    {
        services
            .AddTransient<Application>()
            .AddScoped<IOrderValidator, OrderValidator>()
            .AddScoped<IOrderService, OrderService>()
            .AddSingleton<ILoggerService, LoggerService>()
            .AddSingleton<IOrderRepository, OrderRepository>();
    }
}