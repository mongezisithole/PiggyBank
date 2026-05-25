using PiggyBank.Shared.DTOs.PiggyBank;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiggyBank.Shared.Repositories
{
    public interface IPiggyBankRepository
    {
        Task<List<PiggyBankDetails>> GetPiggyBanks(bool includeDeleted = false);

        Task<bool> CreatePiggyBank(CreatePiggyBank piggyBank);

        Task<bool> DeletePiggyBank(Guid piggyBankId);
    }
}
