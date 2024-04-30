using System.ComponentModel.DataAnnotations;

namespace VehicleAuctionCalculator.Models
{
	public class Fee
	{
		[Range(0, double.MaxValue)]
		public double BasicUserFee { get; set; }

		[Range(0, double.MaxValue)]
		public double SpecialFee { get; set; }

		[Range(0, double.MaxValue)]
		public double AssociationFee { get; set; }

		[Required]
		public double StorageFee { get; set; }

		[Required]
		public double Total { get; set; }
	}
}
