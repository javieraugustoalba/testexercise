<template>
  <div>
    <input v-model="basePrice" type="number" placeholder="Base Price" />
    <select v-model="vehicleType">
      <option value="Common">Common</option>
      <option value="Luxury">Luxury</option>
    </select>
    <button @click="submitForm">Calculate Total</button>
  </div>
</template>

<script>
import { fetchTotal } from '@/api/auctionApi';

export default {
  data() {
    return {
      basePrice: 0,
      vehicleType: 'Common',
      isLoading: false,
      errorMessage: ''
    };
  },
  methods: {
    async submitForm() {
      this.isLoading = true;
      this.errorMessage = '';
      try {
        const response = await fetchTotal(this.basePrice, this.vehicleType);
        this.$emit('totalCalculated', response);
        this.isLoading = false;
      } catch (error) {
        console.error('Error fetching total:', error);
        this.errorMessage = 'Failed to calculate total. Please try again.';
        this.isLoading = false;
      }
    }
  }
};
</script>

