
using OrderProcessing.Domain;

namespace OrderProcessing.Infrastructure.Services.Abstractions;

public interface IOrderService
{
    /// <summary>
    /// Process a given order ID.
    /// </summary>
    /// <param name="orderId">Order ID.</param>
    Task ProcessOrder(int orderId);

    /// <summary>
    /// Creates new entry for a given order details.
    /// </summary>
    /// <param name="order">Order details.</param>
    Task CreateOrderEntry(Order order);
}