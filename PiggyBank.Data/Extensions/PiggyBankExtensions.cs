using PiggyBank.Shared.DTOs.PiggyBank;
using System.Collections.Generic;
using System.Linq;

namespace PiggyBank.Data.Extensions
{
    public static class PiggyBankExtensions
    {
        public static PiggyBankDetails ToDetails(this Entities.PiggyBank piggyBank)
        {
            return new PiggyBankDetails
            {
                CreatedDate = piggyBank.CreatedDate,
                Id = piggyBank.Id,
                Name = piggyBank.Name,
                DeletedDate = piggyBank.CreatedDate
            };
        }

        public static List<PiggyBankDetails> ToDetailsList(this List<Entities.PiggyBank> piggyBanks)
        {
            return piggyBanks.Select(o => o.ToDetails()).ToList();
        }
    }
}
