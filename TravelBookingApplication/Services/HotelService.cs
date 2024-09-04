using TravelBookingApplication.HttpClients;
using TravelBookingApplication.Models;

namespace TravelBookingApplication.Services;
public interface IHotelService
{
    Task<IEnumerable<Hotel>> GetHotelsAsync(string location, DateTime checkInDate, DateTime checkOutDate);
}

public class HotelService : IHotelService
{
    private readonly IExpediaClient _expediaClient;

    public HotelService(IExpediaClient expediaClient)
    {
        _expediaClient = expediaClient;
    }

    public async Task<IEnumerable<Hotel>> GetHotelsAsync(string location, DateTime checkInDate, DateTime checkOutDate)
    {
        try
        {
            return await _expediaClient.GetHotelsAsync(location, checkInDate, checkOutDate);
        }
        catch (Exception ex)
        {
            // Log the exception and rethrow it
            // _logger.LogError(ex, "Error fetching hotels from Expedia API");
            throw;
        }
    }
}
