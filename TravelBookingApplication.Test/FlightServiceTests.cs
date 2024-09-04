using Moq;
using TravelBookingApplication.HttpClients;
using TravelBookingApplication.Models;
using TravelBookingApplication.Services;

namespace TravelBookingApplication.Test;
public class FlightServiceTests
{
    private readonly Mock<IExpediaClient> _mockExpediaClient;
    private readonly FlightService _service;

    public FlightServiceTests()
    {
        _mockExpediaClient = new Mock<IExpediaClient>();
        _service = new FlightService(_mockExpediaClient.Object);
    }

    [Fact]
    public async Task GetFlightsAsync_ReturnsFlights()
    {
        // Arrange
        var flights = new List<Flight> { new Flight(), new Flight() };
        _mockExpediaClient.Setup(client => client.GetFlightsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>())).ReturnsAsync(flights);

        // Act
        var result = await _service.GetFlightsAsync("JFK", "LAX", DateTime.Today);

        // Assert
        Assert.Equal(flights, result);
    }

    [Fact]
    public async Task GetFlightsAsync_ThrowsException_WhenExpediaClientThrowsException()
    {
        // Arrange
        _mockExpediaClient.Setup(client => client.GetFlightsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.GetFlightsAsync("JFK", "LAX", DateTime.Today));
    }
}

