using PiggyBank.Data.Entities;
using PiggyBank.Shared.DTOs.PiggyBankTransaction;
using PiggyBank.Shared.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace PiggyBank.Data.Extensions
{
    public static class PiggyBankTransactionExtensions
    {
        public static PiggyBankTransactionDetails ToDetails(this PiggyBankTransaction transaction)
        {
            return new PiggyBankTransactionDetails
            {
                CreatedDate = transaction.CreatedDate,
                Id = transaction.Id,
                TransactionType = transaction.TransactionType.GetDescription(),
                Value = transaction.Value,
                PiggyBankId = transaction.PiggyBankId
            };
        }

        public static List<PiggyBankTransactionDetails> ToDetailsList(this List<PiggyBankTransaction> transactions)
        {
            return transactions.Select(o => o.ToDetails()).ToList();
        }
    }
}
