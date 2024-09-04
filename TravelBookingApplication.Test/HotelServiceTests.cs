using Moq;
using TravelBookingApplication.HttpClients;
using TravelBookingApplication.Models;
using TravelBookingApplication.Services;

namespace TravelBookingApplication.Test;
public class HotelServiceTests
{
    private readonly Mock<IExpediaClient> _mockExpediaClient;
    private readonly HotelService _service;

    public HotelServiceTests()
    {
        _mockExpediaClient = new Mock<IExpediaClient>();
        _service = new HotelService(_mockExpediaClient.Object);
    }

    [Fact]
    public async Task GetHotelsAsync_ReturnsHotels()
    {
        // Arrange
        var hotels = new List<Hotel> { new Hotel(), new Hotel() };
        _mockExpediaClient.Setup(client => client.GetHotelsAsync(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(hotels);

        // Act
        var result = await _service.GetHotelsAsync("New York", DateTime.Today, DateTime.Today.AddDays(7));

        // Assert
        Assert.Equal(hotels, result);
    }

    [Fact]
    public async Task GetHotelsAsync_ThrowsException_WhenExpediaClientThrowsException()
    {
        // Arrange
        _mockExpediaClient.Setup(client => client.GetHotelsAsync(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.GetHotelsAsync("New York", DateTime.Today, DateTime.Today.AddDays(7)));
    }
}

