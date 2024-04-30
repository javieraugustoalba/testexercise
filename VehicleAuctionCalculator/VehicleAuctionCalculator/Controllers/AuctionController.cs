using Microsoft.AspNetCore.Mvc;
using VehicleAuctionCalculator.Models;
using VehicleAuctionCalculator.Services;

namespace VehicleAuctionCalculator.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuctionController : ControllerBase
	{
		private readonly IConfiguration _config;

		public AuctionController(IConfiguration config)
		{
			_config = config;
		}

		/// <summary>
		/// Calculates the total cost based on the vehicle details.
		/// </summary>
		/// <param name="vehicle">Vehicle details</param>
		/// <returns>Total fees calculated for the vehicle</returns>
		[HttpPost("calculate")]
		public async Task<IActionResult> CalculateTotal(Vehicle vehicle)
		{
			FeeCalculator calculator = new FeeCalculator();
			Fee fees = await calculator.CalculateFees(vehicle);
			return Ok(fees);
		}
	}
}
