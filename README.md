# Vehicle Auction Calculator

## Project Overview

The Vehicle Auction Calculator is designed to help users calculate the total cost of purchasing a vehicle at an auction. This application accounts for various fees based on the vehicle's price and type, supporting both common and luxury vehicles.

## Features

- **Dynamic Fee Calculation**: Calculates total costs including basic user fee, special fee, association fee, and a fixed storage fee.
- **Support for Multiple Vehicle Types**: Handles different calculations for common and luxury vehicles.
- **Real-time Calculation Updates**: Updates the total cost automatically as users input or change vehicle details.

## Technology Stack

- **Frontend**: Vue.js
- **Backend**: ASP.NET Core 8.0
- **API**: RESTful API for frontend-backend communication.
- **Authentication**: JWT for secure access to the API.

## Getting Started

These instructions will get your copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

Ensure you have the following installed:
- Node.js
- .NET Core 8.0 SDK
- Git

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/javieraugustoalba/testexercise.git
   cd vehicle-auction-calculator

2. **Install frontend dependencies**:
   ```bash
   cd auction-app
   npm install

3. **Start the frontend development server:**:
   ```bash
   npm run serve

4. **Start the frontend development server:**:
   ```bash
   cd ../VehicleAuctionCalculator
   dotnet build
   dotnet run

5. **Start the frontend development server:**:
   ```bash
   cd ../VehicleAuctionCalculator
   dotnet build
   dotnet run

**Configuration**
**Configure environment variables in the backend application for JWT settings:**

Jwt:Key
Jwt:Issuer
Jwt:Audience

**Usage**
  With both the frontend and backend services running, navigate to http://localhost:8080 (or your configured port) to view the application. Enter vehicle prices and types to see the calculated costs.

**API Reference**
**POST /Auction/calculate**
Calculates and returns the total cost of the vehicle.

**Payload:**
{
  "basePrice": 1000,
  "vehicleType": "Common"
}

**Success Response:**
{
  "BasicUserFee": 50,
  "SpecialFee": 20,
  "AssociationFee": 10,
  "StorageFee": 100,
  "Total": 1180
}
**Contributing**
Contributions are welcome! Please review the CONTRIBUTING.md file for details on our code of conduct, and the process for submitting pull requests to us.

