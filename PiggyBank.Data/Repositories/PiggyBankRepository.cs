using PiggyBank.Data.Entities;
using PiggyBank.Data.Extensions;
using PiggyBank.Shared.DTOs.PiggyBank;
using PiggyBank.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Data.Repositories
{
    public class PiggyBankRepository : IPiggyBankRepository
    {
        private readonly PiggyBankContext _context;

        public PiggyBankRepository(PiggyBankContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePiggyBank(CreatePiggyBank piggyBank)
        {
            try
            {
                _context.PiggyBanks.Add(new Entities.PiggyBank(piggyBank.Name));
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletePiggyBank(Guid piggyBankId)
        {
            try
            {
                var piggyBank = await _context.PiggyBanks.FirstOrDefaultAsync(o => o.Id == piggyBankId);

                if (piggyBank == null) throw new Exception("Piggy Bank Not Found");

                piggyBank.Delete();
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PiggyBankDetails>> GetPiggyBanks()
        {
            try
            {
                var piggyBanks = await _context.PiggyBanks.Where(o => !o.DeletedDate.HasValue).ToListAsync();

                var detailsList = piggyBanks.ToDetailsList();

                foreach (var piggyBank in detailsList)
                {
                    var transactions = await _context.PiggyBankTransactions.Where(o => o.PiggyBankId == piggyBank.Id).ToListAsync();
                    piggyBank.Transactions = transactions.ToDetailsList();
                }

                return detailsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PiggyBankDetails> UpdatePiggyBank(UpdatePiggyBank piggyBankDetails)
        {
            try
            {
                var piggyBank = await _context.PiggyBanks.FirstOrDefaultAsync(o => o.Id == piggyBankDetails.Id);

                if (piggyBank == null) throw new Exception("Piggy Bank Not Found");

                piggyBank.Update(piggyBankDetails.Name);
                await _context.SaveChangesAsync();

                return piggyBank.ToDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
