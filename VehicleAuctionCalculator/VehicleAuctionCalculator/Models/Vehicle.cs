using System.ComponentModel.DataAnnotations;

namespace VehicleAuctionCalculator.Models
{
	public class Vehicle
	{
		// The class represents a vehicle, which aligns with the Single Responsibility Principle (SRP)

		// The [Required] attribute is used for validation, ensuring that BasePrice is not null or empty
		// The [Range] attribute is used for validation, ensuring that BasePrice is within the specified range
		// The ErrorMessage specifies the error message to display if the validation fails
		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Base price must be a non-negative number.")]
		public double BasePrice { get; set; }

		// The [Required] attribute is used for validation, ensuring that VehicleType is not null or empty
		// The [RegularExpression] attribute is used for validation, ensuring that VehicleType matches the specified pattern
		// The ErrorMessage specifies the error message to display if the validation fails
		[Required(ErrorMessage = "Vehicle type is required.")]
		[RegularExpression("Common|Luxury", ErrorMessage = "Vehicle type must be either 'Common' or 'Luxury'.")]
		public string? VehicleType { get; set; }
	}
}
