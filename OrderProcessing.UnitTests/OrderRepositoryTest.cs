using AwesomeAssertions;
using Moq;
using OrderProcessing.Infrastructure.Repositories;
using OrderProcessing.Infrastructure.Services.Abstractions;
using Xunit;

namespace OrderProcessing.UnitTests;

public class OrderRepositoryTest
{
    [Fact]
    public async Task GivenInvalidOrderId_WhenGetOrder_ShouldFail()
    {
        // Arrange
        const int orderId = -1;
        var expectedMessage = $"Order ID: {orderId}. Mate, are you serious?";

        var validatorMock = new Mock<IOrderValidator>();

        validatorMock
            .Setup(x => x.IsValid(orderId))
            .Returns(false);

        var sut = new OrderRepository(validatorMock.Object);

        // Act
        var result = await Assert.ThrowsAsync<ArgumentException>(() => sut.GetOrder(orderId));

        // Assert
        result.Message.Should().Contain(expectedMessage);
    }

    [Fact]
    public async Task GivenOutOfRangeOrderId_WhenGetOrder_ShouldFail()
    {
        // Arrange
        const int orderId = 100;
        var expectedMessage = $"Order ID: {orderId}. I do not know anything about such order ID.";

        var validatorMock = new Mock<IOrderValidator>();

        validatorMock
            .Setup(x => x.IsValid(orderId))
            .Returns(true);

        var sut = new OrderRepository(validatorMock.Object);

        // Act
        var result = await Assert.ThrowsAsync<KeyNotFoundException>(() => sut.GetOrder(orderId));

        // Assert
        result.Message.Should().Contain(expectedMessage);
    }
}