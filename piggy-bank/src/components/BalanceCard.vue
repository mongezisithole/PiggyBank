<template>
  <q-card class="bg-primary text-white q-mb-md">
    <q-card-section>
      <div class="text-h5">Current Balance</div>
      <div class="text-h4">R {{ balance.toFixed(2) }}</div>
    </q-card-section>
  </q-card>
</template>
<script setup>
import { defineProps } from 'vue';
defineProps({ balance: { type: Number, required: true } });
</script>
