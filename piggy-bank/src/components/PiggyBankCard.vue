<template>
  <q-card class="q-mb-md">
    <q-card-section>
      <div class="text-h6">{{ piggyBank.name }}</div>
      <div class="text-subtitle2">Balance: R {{ balance.toFixed(2) }}</div>
    </q-card-section>

    <q-card-actions align="right">
      <q-btn
        flat
        color="primary"
        icon="visibility"
        label="Transactions"
        @click="$emit('view-transactions', piggyBank)"
      />

      <q-btn
        flat
        color="secondary"
        icon="edit"
        label="Edit"
        @click="$emit('edit', piggyBank)"
      />

      <q-btn
        flat
        color="negative"
        icon="delete"
        label="Delete"
        @click="$emit('delete', piggyBank.id)"
      />

      <q-btn
        flat
        color="positive"
        icon="add"
        label="Deposit"
        @click="$emit('deposit', piggyBank)"
      />

      <q-btn
        flat
        color="warning"
        icon="remove"
        label="Withdraw"
        @click="$emit('withdraw', piggyBank)"
      />
    </q-card-actions>
  </q-card>
</template>

<script setup>
import { defineProps, defineEmits } from 'vue';
defineProps({
  piggyBank: {
    type: Object,
    required: true,
  },
  balance: {
    type: Number,
    required: true,
  },
});

defineEmits(["edit", "delete", "deposit", "withdraw", "view-transactions"]);
</script>
