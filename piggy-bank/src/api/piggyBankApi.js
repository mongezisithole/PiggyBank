import { api } from "@/boot/axios"

export const getPiggyBanks = async () => {
    const response = await api.get('/PiggyBank/GetPiggyBanks')
    return response.data
}

export const createPiggyBank = async (payload) => {
    const response = await api.post('/PiggyBank/CreatePiggyBank', payload)
    return response.data
}

export const deletePiggyBank = async (id) => {
    const response = await api.patch('/PiggyBank/DeletePiggyBank/${id}')
    return response.data
}

export const getPiggyBankTransactions = async (piggyBankId) => {
    const response = await api.get('/PiggyBankTransaction/GetPiggyBankTransactions/${piggyBankId}')
    return response.data
}

export const AddPiggyBankTransaction = async (payload) => {
    const response = await api.post('/PiggyBankTransaction/CreatePiggyBankTransaction', payload)
    return response.data
}