using System.Collections.Concurrent;
using OrderProcessing.Domain;
using OrderProcessing.Infrastructure.Services.Abstractions;

namespace OrderProcessing.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IOrderValidator _orderValidator;
    
    private ConcurrentDictionary<int, OrderDto> _orders = null!;

    public OrderRepository(IOrderValidator orderValidator)
    {
        _orderValidator = orderValidator;
        ExampleRepositoryInitialize();
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">Throws an exception when order ID is invalid.</exception>
    /// <exception cref="KeyNotFoundException">Throws an exception when order ID is not in the collection.</exception>
    public async Task<string> GetOrder(int orderId)
    {
        var isValid = _orderValidator.IsValid(orderId);
        if (!isValid)
            throw new ArgumentException($"Order ID: {orderId}. Mate, are you serious?");

        _orders.TryGetValue(orderId, out var order);
        if (order == null)
            throw new KeyNotFoundException($"Order ID: {orderId}. I do not know anything about such order ID.");

        await Task.Delay(100);

        return order.Description;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">Throws an exception when order ID is invalid.</exception>
    public async Task AddOrder(OrderDto orderDto)
    {
        var isSuccessful = _orders.TryAdd(orderDto.Id, orderDto);
        if (!isSuccessful)
            throw new ArgumentException($"Order ID: {orderDto.Id}. It already exists.");

        await Task.Delay(100);
    }

    private void ExampleRepositoryInitialize()
    {
        var processorCount = Environment.ProcessorCount;
        var concurrencyLevel = processorCount * 2;        

        _orders = new ConcurrentDictionary<int, OrderDto>(concurrencyLevel, 10);
        _orders.TryAdd(1, new OrderDto
        {
            Id = 1,
            Description =  "Laptop"
        });
        _orders.TryAdd(2, new OrderDto
        {
            Id = 2,
            Description =  "Phone"
        });
    }
}