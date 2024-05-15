<!-- TotalDisplay.vue - Vue.js single-file component -->
<!-- Architecture: Follows the Vue.js single-file component architecture -->
<!-- Principles: 
- Single Responsibility Principle (SRP): The component is responsible for displaying the total price or a loading message based on the provided props.
- Data-Driven Development: Uses props to display the total price or a loading message based on the data received from the parent component. -->

<template>
  <div>
    <h1 v-if="totalPrice !== null">Total Price: {{ totalPrice }}</h1>
    <h1 v-else>Loading price...</h1>
  </div>
</template>

<script>
export default {
  props: {
    totalPrice: {
      type: Number,
      default: null 
    }
  }
};
</script>
