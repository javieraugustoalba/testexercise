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
