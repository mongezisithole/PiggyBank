<template>
  <q-dialog v-model="isOpen">
    <q-card style="min-width: 400px">
      <q-card-section>
        <div class="text-h6">
          {{ form.id ? "Edit Piggy Bank" : "New Piggy Bank" }}
        </div>
      </q-card-section>
      <q-card-section>
        <q-input
          v-model="form.name"
          label="Piggy Bank Name"
          outlined
          :rules="[(v) => !!v || 'Name is required']"
        />
      </q-card-section>
      <q-card-actions align="right">
        <q-btn flat label="Cancel" v-close-popup />
        <q-btn color="primary" label="Save" @click="submit" />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>
<script setup>
import { computed, reactive, watch, defineProps, defineEmits } from 'vue';
const props = defineProps({ modelValue: Boolean, selectedPiggyBank: Object});
const emit = defineEmits(['update:modelValue', 'save']);
const isOpen = computed(
    {
        get: () => props.modelValue, set: (value) => emit('update:modelValue', value)
    });
const form = reactive({ id: null, name: ''});
watch( () => props.selectedPiggyBank, (value) =>
{
    if (value)
    {
        form.id = value.id; 
        form.name = value.name;
        }
        else { 
            form.id = null;
            form.name = '' ;
            } 
}, 
{ immediate: true });
const submit = () => 
{ 
    emit('save', { id: form.id, name: form.name });
     isOpen.value = false
};
</script>
