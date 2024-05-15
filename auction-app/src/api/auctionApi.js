// auctionApi.js - Uses the Vue.js framework
// Architecture: Follows the Vue.js single-file component architecture
// Principles: 
// - Separation of Concerns (SoC): Each component focuses on a specific task (fetching data, displaying data).
// - Reusability: The fetchTotal function can be reused in other components or parts of the application.

import axios from 'axios';

// API base URL
const API_URL = 'https://localhost:7245/Auction/';

// Function to fetch total cost based on base price and vehicle type
export async function fetchTotal(basePrice, vehicleType) {
    try {
        // Send a POST request to the calculate endpoint with basePrice and vehicleType
        const response = await axios.post(`${API_URL}calculate`, {
            basePrice,
            vehicleType
        }, {
            // Include Authorization token from localStorage in the request headers
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`,
                'Content-Type': 'application/json'
            }
        });
        // Return the response data (total fees calculated for the vehicle)
        return response.data;
    } catch (error) {
        // Log and throw any errors that occur during the request
        console.error('Failed to fetch total:', error);
        throw error;
    }
}
