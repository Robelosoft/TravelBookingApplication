using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TravelBookingApplication.Controllers;
using TravelBookingApplication.Services;

namespace TravelBookingApplication.Test;
public class HotelsControllerTests
{
    private readonly Mock<IHotelService> _mockHotelService;
    private readonly HotelsController _controller;

    public HotelsControllerTests()
    {
        _mockHotelService = new Mock<IHotelService>();
        _controller = new HotelsController(_mockHotelService.Object);
    }

    [Fact]
    public async Task Get_ReturnsInternalServerError_WhenHotelServiceThrowsException()
    {
        // Arrange
        _mockHotelService.Setup(service => service.GetHotelsAsync(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

        // Act
        var result = await _controller.Get("New York", DateTime.Today, DateTime.Today.AddDays(7));

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
}

