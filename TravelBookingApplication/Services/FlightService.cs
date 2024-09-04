using TravelBookingApplication.HttpClients;
using TravelBookingApplication.Models;

namespace TravelBookingApplication.Services;
public interface IFlightService
{
    Task<IEnumerable<Flight>> GetFlightsAsync(string departureAirport, string arrivalAirport, DateTime departureDate);
}

public class FlightService : IFlightService
{
    private readonly IExpediaClient _expediaClient;

    public FlightService(IExpediaClient expediaClient)
    {
        _expediaClient = expediaClient;
    }

    public async Task<IEnumerable<Flight>> GetFlightsAsync(string departureAirport, string arrivalAirport, DateTime departureDate)
    {
        try
        {
            return await _expediaClient.GetFlightsAsync(departureAirport, arrivalAirport, departureDate);
        }
        catch (Exception ex)
        {
            // Log the exception and rethrow it
            // _logger.LogError(ex, "Error fetching flights from Expedia API");
            throw;
        }
    }

}
