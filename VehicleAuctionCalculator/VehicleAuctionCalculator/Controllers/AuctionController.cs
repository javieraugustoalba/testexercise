using Microsoft.AspNetCore.Mvc;
using VehicleAuctionCalculator.Models;
using VehicleAuctionCalculator.Services;

namespace VehicleAuctionCalculator.Controllers
{
	[ApiController] // Attribute indicating that this class is an API controller
	[Route("[controller]")] // Attribute specifying the base route for this controller
	public class AuctionController : ControllerBase // Inherits from ControllerBase for API controllers
	{
		private readonly IConfiguration _config; // Private field to store an instance of IConfiguration

		// Constructor injection to get IConfiguration instance
		public AuctionController(IConfiguration config)
		{
			_config = config; // Assigning the injected IConfiguration instance to the private field
		}

		/// <summary>
		/// Calculates the total cost based on the vehicle details.
		/// </summary>
		/// <param name="vehicle">Vehicle details</param>
		/// <returns>Total fees calculated for the vehicle</returns>
		[HttpPost("calculate")] // Attribute specifying the HTTP POST route for this action method
		public async Task<IActionResult> CalculateTotal(Vehicle vehicle)
		{
			// The Single Responsibility Principle (SRP) is followed here by delegating the fee calculation to the FeeCalculator class
			// The Dependency Inversion Principle (DIP) is followed by using constructor injection to get an instance of IConfiguration
			// Asynchronous programming is used for non-blocking I/O operations
			// The method uses the FeeCalculator class to calculate fees based on the provided vehicle details
			FeeCalculator calculator = new FeeCalculator();

			Fee fees = await calculator.CalculateFees(vehicle);

			// The method returns the calculated fees as an Ok response
			return Ok(fees);
		}
	}
}
