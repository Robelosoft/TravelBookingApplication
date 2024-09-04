using Microsoft.AspNetCore.Mvc;
using TravelBookingApplication.Models;
using TravelBookingApplication.Services;

namespace TravelBookingApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string location, DateTime checkInDate, DateTime checkOutDate)
    {
        try
        {
            var hotels = await _hotelService.GetHotelsAsync(location, checkInDate, checkOutDate);
            return Ok(hotels);
        }
        catch (Exception)
        {
            // Return a 500 Internal Server Error status code
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

