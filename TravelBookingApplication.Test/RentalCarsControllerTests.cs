using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TravelBookingApplication.Controllers;
using TravelBookingApplication.Services;

namespace TravelBookingApplication.Test;
public class RentalCarsControllerTests
{
    private readonly Mock<IRentalCarService> _mockRentalCarService;
    private readonly RentalCarsController _controller;

    public RentalCarsControllerTests()
    {
        _mockRentalCarService = new Mock<IRentalCarService>();
        _controller = new RentalCarsController(_mockRentalCarService.Object);
    }

    [Fact]
    public async Task Get_ReturnsInternalServerError_WhenRentalCarServiceThrowsException()
    {
        // Arrange
        _mockRentalCarService.Setup(service => service.GetRentalCarsAsync(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

        // Act
        var result = await _controller.Get("New York", DateTime.Today, DateTime.Today.AddDays(7));

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
}

