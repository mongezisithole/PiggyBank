using PiggyBank.Data.Entities;
using PiggyBank.Data.Extensions;
using PiggyBank.Shared.DTOs.PiggyBankTransaction;
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
        public async Task<bool> CreatePiggyBankTransaction(CreatePiggyBankTransaction transaction)
        {
            using (var context = new PiggyBankContext())
            {
                try
                {
                    var piggyBank = await context.PiggyBanks.FirstOrDefaultAsync(o => o.Id == transaction.PiggyBankId);

                    if (piggyBank == null) throw new Exception("Piggy bank not found");

                    context.PiggyBankTransactions.Add(new PiggyBankTransaction(piggyBank.Id, transaction.Value, transaction.TransactionType.GetValueFromDescription()));
                    await context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<PiggyBankTransactionDetails>> GetPiggyBankTransactions(Guid piggyBankId)
        {
            using (var context = new PiggyBankContext())
            {
                try
                {
                    var transactions = await context.PiggyBankTransactions.Where(o => o.PiggyBankId == piggyBankId).ToListAsync();

                    return transactions.ToDetailsList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
