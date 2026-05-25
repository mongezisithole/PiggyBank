using PiggyBank.Shared.DTOs.PiggyBankTransaction;
using PiggyBank.Shared.Repositories;
using PiggyBank.Shared.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiggyBank.Core.Services
{
    public class PiggyBankTransactionServices : IPiggyBankTransactionServices
    {
        private readonly IPiggyBankTransactionRepository _repository;

        public PiggyBankTransactionServices(IPiggyBankTransactionRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> CreatePiggyBankTransaction(CreatePiggyBankTransaction piggyBankTransaction)
        {
            return _repository.CreatePiggyBankTransaction(piggyBankTransaction);
        }

        public Task<List<PiggyBankTransactionDetails>> GetPiggyBankTransactions(Guid piggyBankId)
        {
            return _repository.GetPiggyBankTransactions(piggyBankId);
        }
    }
}
