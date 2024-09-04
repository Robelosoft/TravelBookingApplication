using Moq;
using TravelBookingApplication.HttpClients;
using TravelBookingApplication.Models;
using TravelBookingApplication.Services;

public class RentalCarServiceTests
{
    private readonly Mock<IExpediaClient> _mockExpediaClient;
    private readonly RentalCarService _service;

    public RentalCarServiceTests()
    {
        _mockExpediaClient = new Mock<IExpediaClient>();
        _service = new RentalCarService(_mockExpediaClient.Object);
    }

    [Fact]
    public async Task GetRentalCarsAsync_ReturnsRentalCars()
    {
        // Arrange
        var rentalCars = new List<RentalCar> { new RentalCar(), new RentalCar() };
        _mockExpediaClient.Setup(client => client.GetRentalCarsAsync(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(rentalCars);

        // Act
        var result = await _service.GetRentalCarsAsync("New York", DateTime.Today, DateTime.Today.AddDays(7));

        // Assert
        Assert.Equal(rentalCars, result);
    }

    [Fact]
    public async Task GetRentalCarsAsync_ThrowsException_WhenExpediaClientThrowsException()
    {
        // Arrange
        _mockExpediaClient.Setup(client => client.GetRentalCarsAsync(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.GetRentalCarsAsync("New York", DateTime.Today, DateTime.Today.AddDays(7)));
    }
}

