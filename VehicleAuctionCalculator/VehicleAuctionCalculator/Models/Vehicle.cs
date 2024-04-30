using System.ComponentModel.DataAnnotations;

namespace VehicleAuctionCalculator.Models
{
	public class Vehicle
	{
		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Base price must be a non-negative number.")]
		public double BasePrice { get; set; }

		[Required(ErrorMessage = "Vehicle type is required.")]
		[RegularExpression("Common|Luxury", ErrorMessage = "Vehicle type must be either 'Common' or 'Luxury'.")]
		public string? VehicleType { get; set; }
	}
}
