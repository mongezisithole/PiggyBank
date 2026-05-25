using System;

namespace PiggyBank.Shared.DTOs.PiggyBankTransaction
{
    public class PiggyBankTransactionDetails
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid PiggyBankId { get; set; }

        public double Value { get; set; }

        public string TransactionType { get; set; }
    }
}
