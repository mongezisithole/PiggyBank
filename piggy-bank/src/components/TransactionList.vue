<template>
  <q-card>
    <q-card-section> <div class="text-h6">Transactions</div> </q-card-section>
    <q-separator />
    <q-list bordered separator>
      <q-item v-for="transaction in transactions" :key="transaction.id">
        <q-item-section> {{ transaction.transactionType }} </q-item-section>
        <q-item-section side>
          R {{ transaction.value.toFixed(2) }}
        </q-item-section>
      </q-item>
    </q-list>
  </q-card>
</template>
<script setup>
import { defineProps } from 'vue';
defineProps({ transactions: { type: Array, required: true } });
</script>
