<template>
  <q-layout>
    <q-page-container>
      <q-page padding>
        <div class="row items-center justify-between q-mb-md">
          <div class="text-h4">Piggy Bank Application</div>

          <q-btn
            color="primary"
            label="Add Piggy Bank"
            icon="add"
            @click="openCreateDialog"
          />
        </div>

        <q-banner v-if="error" class="bg-red text-white q-mb-md">
          {{ error }}
        </q-banner>

        <div class="row justify-center q-my-lg" v-if="loading">
          <q-spinner color="primary" size="50px" />
        </div>

        <div v-else>
          <PiggyBankCard
            v-for="bank in piggyBanks"
            :key="bank.id"
            :piggy-bank="bank"
            :balance="calculateBalance(bank.transactions || [])"
            @edit="openEditDialog"
            @delete="removePiggyBank"
            @deposit="openDepositDialog"
            @withdraw="openWithdrawDialog"
            @view-transactions="selectPiggyBank"
          />
        </div>

        <div v-if="selectedPiggyBank" class="q-mt-lg">
          <BalanceCard :balance="calculateBalance(transactions)" />

          <TransactionList :transactions="transactions" />
        </div>

        <PiggyBankFormDialog
          v-model="showPiggyBankDialog"
          :selected-piggy-bank="selectedPiggyBank"
          @save="savePiggyBank"
        />

        <TransactionDialog
          v-model="showTransactionDialog"
          :piggy-bank-id="selectedPiggyBank?.id"
          :transaction-type="transactionType"
          @submit="submitTransaction"
        />
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script setup>
import { ref, onMounted } from "vue";

import PiggyBankCard from "../components/PiggyBankCard.vue";
import PiggyBankFormDialog from "../components/PiggyBankFormDialog.vue";
import TransactionDialog from "../components/TransactionDialog.vue";
import TransactionList from "../components/TransactionList.vue";
import BalanceCard from "../components/BalanceCard.vue";

import {
  getPiggyBanks,
  createPiggyBank,
  updatePiggyBank,
  deletePiggyBank,
  getPiggyBankTransactions,
  AddPiggyBankTransaction,
} from "../api/piggyBankApi.js";

const piggyBanks = ref([]);
const transactions = ref([]);

const loading = ref(false);
const error = ref("");

const selectedPiggyBank = ref(null);

const showPiggyBankDialog = ref(false);
const showTransactionDialog = ref(false);

const transactionType = ref("Deposit");

const loadPiggyBanks = async () => {
  try {
    loading.value = true;
    error.value = "";

    piggyBanks.value = await getPiggyBanks();
  } catch (err) {
    console.error(err);
    error.value = "Failed to load piggy banks.";
  } finally {
    loading.value = false;
  }
};

const openCreateDialog = () => {
  selectedPiggyBank.value = null;
  showPiggyBankDialog.value = true;
};

const openEditDialog = (piggyBank) => {
  selectedPiggyBank.value = piggyBank;
  showPiggyBankDialog.value = true;
};

const savePiggyBank = async (payload) => {
  try {
    error.value = "";

    if (payload.id) {
      await updatePiggyBank(payload);
    } else {
      await createPiggyBank(payload);
    }

    await loadPiggyBanks();
  } catch (err) {
    console.error(err);
    error.value = "Failed to save piggy bank.";
  }
};

const removePiggyBank = async (id) => {
  try {
    error.value = "";

    await deletePiggyBank(id);
    await loadPiggyBanks();

    if (selectedPiggyBank.value?.id === id) {
      selectedPiggyBank.value = null;
      transactions.value = [];
    }
  } catch (err) {
    console.error(err);
    error.value = "Failed to delete piggy bank.";
  }
};

const openDepositDialog = (piggyBank) => {
  selectedPiggyBank.value = piggyBank;
  transactionType.value = "Deposit";
  showTransactionDialog.value = true;
};

const openWithdrawDialog = (piggyBank) => {
  selectedPiggyBank.value = piggyBank;
  transactionType.value = "Withdrawal";
  showTransactionDialog.value = true;
};

const submitTransaction = async (payload) => {
  try {
    error.value = "";

    if (selectedPiggyBank.value && payload.transactionType == 'Withdrawal' && payload.value > selectedPiggyBank.value.balance){
        error.value = "Transaction failed: Invalid withdrawal amount";
        return;
    }

    await AddPiggyBankTransaction(payload);

    if (selectedPiggyBank.value) {
      await selectPiggyBank(selectedPiggyBank.value);
    }

    await loadPiggyBanks();
  } catch (err) {
    console.error(err);
    error.value = "Transaction failed.";
  }
};

const selectPiggyBank = async (piggyBank) => {
  try {
    selectedPiggyBank.value = piggyBank;
    
    transactions.value = await getPiggyBankTransactions(piggyBank.id);
  } catch (err) {
    console.error(err);
    error.value = "Failed to load transactions.";
  }
};

const calculateBalance = (transactions) => {
  return transactions.reduce((total, transaction) => {
    if (transaction.transactionType === "Deposit") {
      return total + transaction.value;
    }

    return total - transaction.value;
  }, 0);
};

onMounted(async () => {
  await loadPiggyBanks();
});
</script>
