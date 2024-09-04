using Microsoft.AspNetCore.Mvc;
using TravelBookingApplication.Models;
using TravelBookingApplication.Services;

namespace TravelBookingApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightsController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string departureAirport, string arrivalAirport, DateTime departureDate)
    {
        try
        {
            var flights = await _flightService.GetFlightsAsync(departureAirport, arrivalAirport, departureDate);
            return Ok(flights);
        }
        catch (Exception)
        {
            // Return a 500 Internal Server Error status code
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

