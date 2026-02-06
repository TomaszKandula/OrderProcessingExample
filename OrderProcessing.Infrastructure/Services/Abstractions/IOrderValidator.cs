namespace OrderProcessing.Infrastructure.Services.Abstractions;

public interface IOrderValidator
{
    /// <summary>
    /// Checks if order ID is greater than 0.
    /// </summary>
    /// <param name="orderId">Given order ID.</param>
    /// <returns>False if ID is less or equal 0. True otherwise.</returns>
    bool IsValid(int orderId);
}