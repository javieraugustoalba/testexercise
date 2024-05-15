<!-- This is a component-based architecture created on Vue.js (Vue Component Architecture) -->
<template>
  <!-- Main application container with id "app" -->
  <div id="app">
    <!-- Include the AuctionForm component and listen for the "totalCalculated" event -->
    <auction-form @totalCalculated="handleTotalCalculated" />
    <!-- Conditionally render the TotalDisplay component if totalPrice is not null -->
    <total-display v-if="totalPrice" :totalPrice="totalPrice" />
  </div>
</template>

<script>
// Import the AuctionForm and TotalDisplay components
import AuctionForm from './components/AuctionForm.vue';
import TotalDisplay from './components/TotalDisplay.vue';

export default {
  // Register components used in the template
  // Component Registration: The components object is used to register child components 
  // that are used within the parent component's template. 
  // This allows you to use these child components as custom HTML elements within the parent component's template.

  components: {
    AuctionForm,
    TotalDisplay
  },
  // Initialize the totalPrice data property as null
  // Data Initialization: The data function is used to initialize the component's data properties. 
  // These data properties can be accessed within the component's template and are reactive, 
  // meaning that if their values change, the corresponding parts of the template will update automatically.
  data() {
    return {
      totalPrice: null
    };
  },
  // Method to handle the "totalCalculated" event emitted by the AuctionForm component
  // Methods: The methods object is used to define methods that can be called within the component. 
  // In this case, the handleTotalCalculated method is used to update the totalPrice data property
  //when the "totalCalculated" event is emitted by the AuctionForm component.
  methods: {
    handleTotalCalculated(total) {
      // Update the totalPrice data property with the calculated total price
      this.totalPrice = total;
    }
  }
};
</script>