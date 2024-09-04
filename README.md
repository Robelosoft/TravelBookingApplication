Travel Planner Application
This application allows users to search for flights, hotels, and rental cars using the Expedia API.

Prerequisites
.NET 6.0 SDK
An IDE such as Visual Studio or Visual Studio Code
Setup
Clone the repository:



git clone [https://github.com/Robelosoft/TravelBookingApplication]
Navigate to the project directory:



cd travel-planner
Install the necessary NuGet packages:



dotnet restore
Configuration
You need to configure the base address of the Expedia API and any necessary authentication credentials. This can be done in the Program.cs file:

csharp


builder.Services.AddHttpClient<IExpediaClient, ExpediaClient>(client =>
{
    client.BaseAddress = new Uri("https://api.expedia.com/");
    // Add any necessary authentication headers here
});
Replace "https://api.expedia.com/" with the actual base address of the Expedia API, and add any necessary authentication headers.

Running the Application
You can run the application using the dotnet run command:



dotnet run
The application will start and listen on http://localhost:5000 and https://localhost:5001.

Running the Tests
You can run the unit tests using the dotnet test command:



dotnet test
Endpoints
The application provides the following endpoints:

GET /flights?departureAirport={departureAirport}&arrivalAirport={arrivalAirport}&departureDate={departureDate}
GET /hotels?location={location}&checkInDate={checkInDate}&checkOutDate={checkOutDate}
GET /rentalcars?location={location}&pickUpDate={pickUpDate}&dropOffDate={dropOffDate}
Replace the placeholders with your desired search criteria.

Error Handling
The application returns a 500 Internal Server Error status code when an error occurs while fetching data from the Expedia API.

- Was it easy to complete the task using AI?  Yes
- How long did task take you to complete? (Please be honest, we need it to gather anonymized statistics)  1 hour
- Was the code ready to run after generation? What did you have to change to make it usable? I have to do some modifications in configurations, packages
- Which challenges did you face during completion of the task? packages, references
- Which specific prompts you learned as a good practice to complete the task? Do not request everything in one prompt, do it in steps.
