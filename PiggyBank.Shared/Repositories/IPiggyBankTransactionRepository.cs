using PiggyBank.Shared.DTOs.PiggyBankTransaction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiggyBank.Shared.Repositories
{
    public interface IPiggyBankTransactionRepository
    {
        Task<List<PiggyBankTransactionDetails>> GetPiggyBankTransactions(Guid piggyBankId);

        Task<bool> CreatePiggyBankTransaction(CreatePiggyBankTransaction piggyBankTransaction);
    }
}
