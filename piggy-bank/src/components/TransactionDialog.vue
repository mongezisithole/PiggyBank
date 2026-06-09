<template>
  <q-dialog v-model="isOpen">
    <q-card style="min-width: 400px">
      <q-card-section>
        <div class="text-h6">{{ transactionType }}</div>
      </q-card-section>
      <q-card-section>
        <q-input
          v-model.number="amount"
          type="number"
          label="Amount"
          outlined
        />
      </q-card-section>
      <q-card-actions align="right">
        <q-btn flat label="Cancel" v-close-popup />
        <q-btn color="primary" label="Submit" @click="submit" />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>
<script setup>
import { computed, ref, defineProps, defineEmits } from 'vue';
const props = defineProps({ modelValue: Boolean, piggyBankId: String, transactionType: String});
const emit = defineEmits(['update:modelValue', 'submit']);
const amount = ref(0);
const isOpen = computed({ get: () => props.modelValue, set: (value) => emit('update:modelValue', value)});
const submit = () =>
{
    emit('submit', { piggyBankId: props.piggyBankId, value: amount.value, transactionType: props.transactionType });
    amount.value = 0; 
    isOpen.value = false;
}
</script>
