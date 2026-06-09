using PiggyBank.Data.Entities;
using PiggyBank.Data.Extensions;
using PiggyBank.Shared.DTOs.PiggyBankTransaction;
using PiggyBank.Shared.Enums;
using PiggyBank.Shared.Extensions;
using PiggyBank.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Data.Repositories
{
    public class PiggyBankTransactionRepository : IPiggyBankTransactionRepository
    {
        private readonly PiggyBankContext _context;

        public PiggyBankTransactionRepository(PiggyBankContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePiggyBankTransaction(CreatePiggyBankTransaction transaction)
        {
            try
            {
                var piggyBank = await _context.PiggyBanks.FirstOrDefaultAsync(o => o.Id == transaction.PiggyBankId);

                if (piggyBank == null) throw new Exception("Piggy bank not found");

                if (transaction.TransactionType == TransactionType.Withdrawal.GetDescription() && piggyBank.ToDetails().Balance < transaction.Value)
                {
                    throw new Exception("Invalid withdrawal amount");
                }

                _context.PiggyBankTransactions.Add(new PiggyBankTransaction(piggyBank.Id, transaction.Value, transaction.TransactionType.GetValueFromDescription()));
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PiggyBankTransactionDetails>> GetPiggyBankTransactions(Guid piggyBankId)
        {
            try
            {
                var transactions = await _context.PiggyBankTransactions.Where(o => o.PiggyBankId == piggyBankId).ToListAsync();

                return transactions.ToDetailsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
