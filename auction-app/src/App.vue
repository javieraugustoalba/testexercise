<template>
  <div id="app">
    <auction-form @totalCalculated="handleTotalCalculated" />
    <total-display v-if="totalPrice" :totalPrice="totalPrice" />
  </div>
</template>

<script>
import AuctionForm from './components/AuctionForm.vue';
import TotalDisplay from './components/TotalDisplay.vue';

export default {
  components: {
    AuctionForm,
    TotalDisplay
  },
  data() {
    return {
      totalPrice: null
    };
  },
  methods: {
    handleTotalCalculated(total) {
      this.totalPrice = total;
    }
  }
};
</script>