using Newtonsoft.Json;
using TravelBookingApplication.Models;

namespace TravelBookingApplication.HttpClients;
public interface IExpediaClient
{
    Task<IEnumerable<Flight>> GetFlightsAsync(string departureAirport, string arrivalAirport, DateTime departureDate);
    Task<IEnumerable<Hotel>> GetHotelsAsync(string location, DateTime checkInDate, DateTime checkOutDate);
    Task<IEnumerable<RentalCar>> GetRentalCarsAsync(string location, DateTime pickUpDate, DateTime dropOffDate);
}

public class ExpediaClient : IExpediaClient
{
    private readonly HttpClient _httpClient;

    public ExpediaClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Flight>> GetFlightsAsync(string departureAirport, string arrivalAirport, DateTime departureDate)
    {
        var response = await _httpClient.GetAsync($"flights?departureAirport={departureAirport}&arrivalAirport={arrivalAirport}&departureDate={departureDate:yyyy-MM-dd}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error fetching flights from Expedia API");
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<Flight>>(content);
    }

    public async Task<IEnumerable<Hotel>> GetHotelsAsync(string location, DateTime checkInDate, DateTime checkOutDate)
    {
        var response = await _httpClient.GetAsync($"hotels?location={location}&checkInDate={checkInDate:yyyy-MM-dd}&checkOutDate={checkOutDate:yyyy-MM-dd}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error fetching hotels from Expedia API");
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<Hotel>>(content);
    }

    public async Task<IEnumerable<RentalCar>> GetRentalCarsAsync(string location, DateTime pickUpDate, DateTime dropOffDate)
    {
        var response = await _httpClient.GetAsync($"rentalcars?location={location}&pickUpDate={pickUpDate:yyyy-MM-dd}&dropOffDate={dropOffDate:yyyy-MM-dd}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error fetching rental cars from Expedia API");
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<RentalCar>>(content);
    }
}
