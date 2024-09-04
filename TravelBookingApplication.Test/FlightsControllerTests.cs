using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingApplication.Controllers;
using TravelBookingApplication.Services;

namespace TravelBookingApplication.Test;
public class FlightsControllerTests
{
    private readonly Mock<IFlightService> _mockFlightService;
    private readonly FlightsController _controller;

    public FlightsControllerTests()
    {
        _mockFlightService = new Mock<IFlightService>();
        _controller = new FlightsController(_mockFlightService.Object);
    }

    [Fact]
    public async Task Get_ReturnsInternalServerError_WhenFlightServiceThrowsException()
    {
        // Arrange
        _mockFlightService.Setup(service => service.GetFlightsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

        // Act
        var result = await _controller.Get("JFK", "LAX", DateTime.Today);

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }
}

