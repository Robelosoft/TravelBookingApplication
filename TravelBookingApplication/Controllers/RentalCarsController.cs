using Microsoft.AspNetCore.Mvc;
using TravelBookingApplication.Models;
using TravelBookingApplication.Services;

namespace TravelBookingApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class RentalCarsController : ControllerBase
{
    private readonly IRentalCarService _rentalCarService;

    public RentalCarsController(IRentalCarService rentalCarService)
    {
        _rentalCarService = rentalCarService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string location, DateTime pickUpDate, DateTime dropOffDate)
    {
        try
        {
            var rentalCars = await _rentalCarService.GetRentalCarsAsync(location, pickUpDate, dropOffDate);
            return Ok(rentalCars);
        }
        catch (Exception)
        {
            // Return a 500 Internal Server Error status code
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

