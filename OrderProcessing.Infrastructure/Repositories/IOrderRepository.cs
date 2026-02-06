using OrderProcessing.Domain;

namespace OrderProcessing.Infrastructure.Repositories;

public interface IOrderRepository
{
    /// <summary>
    /// Returns description for a given Order ID.
    /// </summary>
    /// <param name="orderId">Requested order ID.</param>
    /// <returns>Order description.</returns>
    Task<string> GetOrder(int orderId);

    /// <summary>
    /// Adds new order to the repository.
    /// </summary>
    /// <param name="order">Order details.</param>
    Task AddOrder(Order order);
}