using System.ComponentModel.DataAnnotations;

namespace VehicleAuctionCalculator.Models
{
	public class Fee
	{
		// The class represents a fee calculation result, which aligns with the Single Responsibility Principle (SRP)

		// The [Range] attribute is used for validation, ensuring that BasicUserFee is within the specified range
		[Range(0, double.MaxValue)]
		public double BasicUserFee { get; set; }

		// The [Range] attribute is used for validation, ensuring that SpecialFee is within the specified range
		[Range(0, double.MaxValue)]
		public double SpecialFee { get; set; }

		// The [Range] attribute is used for validation, ensuring that AssociationFee is within the specified range
		[Range(0, double.MaxValue)]
		public double AssociationFee { get; set; }

		// The [Required] attribute is used for validation, ensuring that StorageFee is not null or empty
		[Required]
		public double StorageFee { get; set; }

		// The [Required] attribute is used for validation, ensuring that Total is not null or empty
		public double Total { get; set; }
	}
}
