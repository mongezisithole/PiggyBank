using PiggyBank.Shared.DTOs.PiggyBankTransaction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiggyBank.Shared.Services
{
    public interface IPiggyBankTransactionServices
    {
        Task<List<PiggyBankTransactionDetails>> GetPiggyBankTransactions(Guid piggyBankId);

        Task<bool> CreatePiggyBankTransaction(CreatePiggyBankTransaction piggyBankTransaction);
    }
}
