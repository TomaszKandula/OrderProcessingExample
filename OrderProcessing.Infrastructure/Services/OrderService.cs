using OrderProcessing.Domain;
using OrderProcessing.Infrastructure.Repositories;
using OrderProcessing.Infrastructure.Services.Abstractions;

namespace OrderProcessing.Infrastructure.Services;

public class OrderService(IOrderRepository orderRepository, ILoggerService loggerService) : IOrderService
{
    /// <inheritdoc/>
    public async Task ProcessOrder(int orderId)
    {
        try
        {
            loggerService.LogInfo($"Processing order {orderId}");
            var description = await orderRepository.GetOrder(orderId);
            loggerService.LogInfo($"Processed order ID {orderId}: {description}.");
        }
        catch (Exception exception)
        {
            loggerService.LogError("Something went wrong...", exception);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task CreateOrderEntry(Order order)
    {
        try
        {
            loggerService.LogInfo("Processing new order...");
            await orderRepository.AddOrder(order);
        }
        catch (Exception exception)
        {
            loggerService.LogError("Something went wrong...", exception);
            throw;
        }
    }
}