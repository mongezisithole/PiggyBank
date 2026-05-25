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
        public async Task<bool> CreatePiggyBank(CreatePiggyBank piggyBank)
        {
            using (var context = new PiggyBankContext())
            {
                try
                {
                    context.PiggyBanks.Add(new Entities.PiggyBank(piggyBank.Name));
                    await context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<bool> DeletePiggyBank(Guid piggyBankId)
        {
            using (var context = new PiggyBankContext())
            {
                try
                {
                    var piggyBank = await context.PiggyBanks.FirstOrDefaultAsync(o => o.Id == piggyBankId);

                    if (piggyBank == null) throw new Exception("Piggy Bank Not Found");

                    piggyBank.Delete();
                    await context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<PiggyBankDetails>> GetPiggyBanks(bool includeDeleted = false)
        {
            using (var context = new PiggyBankContext())
            {
                try
                {
                    var piggyBanks = await context.PiggyBanks.Where(o => !o.DeletedDate.HasValue).ToListAsync();

                    if (includeDeleted)
                    {
                        piggyBanks.AddRange(await context.PiggyBanks.Where(o => o.DeletedDate.HasValue).ToListAsync());
                    }

                    var detailsList = piggyBanks.ToDetailsList();

                    foreach (var piggyBank in detailsList)
                    {
                        var transactions = await context.PiggyBankTransactions.Where(o => o.PiggyBankId == piggyBank.Id).ToListAsync();
                        piggyBank.Transactions = transactions.ToDetailsList();
                    }

                    return detailsList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
