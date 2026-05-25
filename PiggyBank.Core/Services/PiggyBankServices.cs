using PiggyBank.Shared.DTOs.PiggyBank;
using PiggyBank.Shared.Repositories;
using PiggyBank.Shared.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiggyBank.Core.Services
{
    public class PiggyBankServices : IPiggyBankServices
    {
        private readonly IPiggyBankRepository _repository;

        public PiggyBankServices(IPiggyBankRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> CreatePiggyBank(CreatePiggyBank piggyBank)
        {
            return _repository.CreatePiggyBank(piggyBank);
        }

        public Task<bool> DeletePiggyBank(Guid piggyBankId)
        {
            return _repository.DeletePiggyBank(piggyBankId);
        }

        public Task<List<PiggyBankDetails>> GetPiggyBanks(bool includeDeleted = false)
        {
            return _repository.GetPiggyBanks(includeDeleted);
        }
    }
}
