import axios from 'axios';

const API_URL = 'https://localhost:7245/Auction/';

export async function fetchTotal(basePrice, vehicleType) {
    try {
        const response = await axios.post(`${API_URL}calculate`, {
            basePrice,
            vehicleType
        }, {
            headers: {
                'Authorization': `Bearer ${localStorage.getItem('token')}`,
                'Content-Type': 'application/json'
            }
        });
        return response.data;
    } catch (error) {
        console.error('Failed to fetch total:', error);
        throw error;
    }
}
