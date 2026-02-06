using Moq;
using OrderProcessing.Infrastructure.Repositories;
using OrderProcessing.Infrastructure.Services;
using OrderProcessing.Infrastructure.Services.Abstractions;
using Xunit;

namespace OrderProcessing.UnitTests;

public class OrderServiceTests
{
    [Fact]
    public async Task GivenExistingOrderId_WhenProcessOrder_ShouldSucceed()
    {
        // Arrange
        const int orderId = 1;
        const string orderDescription = "Test Order";
        const string loggerMessage = "Processed order ID 1: Test Order.";
        
        var repositoryMock = new Mock<IOrderRepository>();
        var loggerMock = new Mock<ILoggerService>();

        repositoryMock
            .Setup(x => x.GetOrder(orderId))
            .ReturnsAsync(orderDescription);

        loggerMock.Setup(x => x.LogInfo(loggerMessage));

        var sut = new OrderService(repositoryMock.Object, loggerMock.Object);

        // Act
        await sut.ProcessOrder(orderId);

        // Assert
        loggerMock.Verify(x => x.LogInfo(loggerMessage), Times.Once);
    }
}