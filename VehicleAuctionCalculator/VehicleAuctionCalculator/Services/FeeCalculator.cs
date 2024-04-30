using System;
using System.Threading.Tasks;
using VehicleAuctionCalculator.Models;

namespace VehicleAuctionCalculator.Services
{
	/// <summary>
	/// Provides methods to calculate various fees for a vehicle.
	/// </summary>
	public class FeeCalculator
	{
		/// <summary>
		/// Asynchronously calculates all fees for a given vehicle.
		/// </summary>
		/// <param name="vehicle">The vehicle for which fees are calculated.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the calculated fees.</returns>
		public async Task<Fee> CalculateFees(Vehicle vehicle)
		{
			double basicUserFee = CalculateBasicFee(vehicle);
			double specialFee = CalculateSpecialFee(vehicle);
			double associationFee = CalculateAssociationFee(vehicle.BasePrice);
			const double storageFee = 100;  // This fee remains constant across all vehicles

			double total = vehicle.BasePrice + basicUserFee + specialFee + associationFee + storageFee;

			// Using Task.FromResult to avoid unnecessary thread creation
			return await Task.FromResult(new Fee
			{
				BasicUserFee = basicUserFee,
				SpecialFee = specialFee,
				AssociationFee = associationFee,
				StorageFee = storageFee,
				Total = total
			});
		}

		/// <summary>
		/// Calculates the basic user fee based on the vehicle type.
		/// </summary>
		/// <param name="vehicle">The vehicle for which the basic fee is calculated.</param>
		/// <returns>The calculated basic user fee.</returns>
		private double CalculateBasicFee(Vehicle vehicle)
		{
			double percentage = vehicle.VehicleType == "Common" ? 0.1 : 0.25;  // 10% for common, 25% for luxury
			double fee = vehicle.BasePrice * percentage;
			double min = vehicle.VehicleType == "Common" ? 10 : 25;
			double max = vehicle.VehicleType == "Common" ? 50 : 200;
			return Math.Clamp(fee, min, max);
		}

		/// <summary>
		/// Calculates the special fee based on the vehicle type.
		/// </summary>
		/// <param name="vehicle">The vehicle for which the special fee is calculated.</param>
		/// <returns>The calculated special fee.</returns>
		private double CalculateSpecialFee(Vehicle vehicle)
		{
			return vehicle.VehicleType == "Common" ? vehicle.BasePrice * 0.02 : vehicle.BasePrice * 0.04;
		}

		/// <summary>
		/// Calculates the association fee based on the vehicle's base price.
		/// </summary>
		/// <param name="price">The base price of the vehicle.</param>
		/// <returns>The calculated association fee.</returns>
		private double CalculateAssociationFee(double price)
		{
			if (price <= 500) return 5;
			else if (price <= 1000) return 10;
			else if (price <= 3000) return 15;
			else return 20;
		}
	}
}
