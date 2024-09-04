using TravelBookingApplication.HttpClients;
using TravelBookingApplication.Models;

namespace TravelBookingApplication.Services;
public interface IRentalCarService
{
    Task<IEnumerable<RentalCar>> GetRentalCarsAsync(string location, DateTime pickUpDate, DateTime dropOffDate);
}

public class RentalCarService : IRentalCarService
{
    private readonly IExpediaClient _expediaClient;

    public RentalCarService(IExpediaClient expediaClient)
    {
        _expediaClient = expediaClient;
    }

    public async Task<IEnumerable<RentalCar>> GetRentalCarsAsync(string location, DateTime pickUpDate, DateTime dropOffDate)
    {
        try
        {
            return await _expediaClient.GetRentalCarsAsync(location, pickUpDate, dropOffDate);
        }
        catch (Exception ex)
        {
            // Log the exception and rethrow it
            // _logger.LogError(ex, "Error fetching rental cars from Expedia API");
            throw;
        }
    }
}


