using PiggyBank.Shared.DTOs.PiggyBank;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiggyBank.Shared.Repositories
{
    public interface IPiggyBankRepository
    {
        Task<List<PiggyBankDetails>> GetPiggyBanks();

        Task<bool> CreatePiggyBank(CreatePiggyBank piggyBank);

        Task<bool> DeletePiggyBank(Guid piggyBankId);

        Task<PiggyBankDetails> UpdatePiggyBank(UpdatePiggyBank piggyBank);
    }
}
