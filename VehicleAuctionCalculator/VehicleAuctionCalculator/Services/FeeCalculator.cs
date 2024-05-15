using Microsoft.AspNetCore.Http.HttpResults;
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
		// FeeCalculator class is marked as public, allowing it to be accessed from other classes in the same assembly or from other assemblies.
		// The class provides methods for calculating various fees for a vehicle, following the Single Responsibility Principle(SRP) by focusing on fee calculation.

		// The class follows the Single Responsibility Principle (SRP) by providing methods for fee calculation

		/// <summary>
		/// Asynchronously calculates all fees for a given vehicle.
		/// </summary>
		/// <param name="vehicle">The vehicle for which fees are calculated.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the calculated fees.</returns>
		public async Task<Fee> CalculateFees(Vehicle vehicle)
		{
			//CalculateFees method is marked as public and async,
			//indicating that it can be called from external code and that it performs asynchronous operations.

			// The method uses async/await to perform calculations asynchronously
			// The fees are calculated based on the provided vehicle details
			// The method returns a Task<Fee> representing the calculated fees
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
			// The method calculates the basic user fee based on the vehicle type
			// The fee percentage varies for Common and Luxury vehicles
			// The fee is clamped to ensure it falls within a specified range
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
			// The method calculates the special fee based on the vehicle type
			// The fee percentage varies for Common and Luxury vehicles
			return vehicle.VehicleType == "Common" ? vehicle.BasePrice * 0.02 : vehicle.BasePrice * 0.04;
		}

		/// <summary>
		/// Calculates the association fee based on the vehicle's base price.
		/// </summary>
		/// <param name="price">The base price of the vehicle.</param>
		/// <returns>The calculated association fee.</returns>
		private double CalculateAssociationFee(double price)
		{
			// The method calculates the association fee based on the vehicle's base price
			// The fee varies based on different price ranges
			if (price <= 500) return 5;
			else if (price <= 1000) return 10;
			else if (price <= 3000) return 15;
			else return 20;
		}
	}
}
