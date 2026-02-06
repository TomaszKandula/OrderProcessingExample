using OrderProcessing.Infrastructure.Services.Abstractions;

namespace OrderProcessing.Infrastructure.Services;

public class OrderValidator : IOrderValidator
{
    /// <inheritdoc/>
    public bool IsValid(int orderId) => orderId > 0;
}