using PiggyBank.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiggyBank.Data.Entities
{
    public class PiggyBankTransaction : EntityBase
    {
        public PiggyBankTransaction() { }

        public PiggyBankTransaction(Guid piggyBankId, double value, TransactionType transactionType)
            : base()
        {
            PiggyBankId = piggyBankId;
            Value = value;
            TransactionType = transactionType;
        }

        [ForeignKey(nameof(PiggyBankId))]
        public PiggyBank PiggyBank { get; private set; }

        public Guid PiggyBankId { get; private set; }

        [Required]
        public double Value { get; private set; }

        [Required]
        public TransactionType TransactionType { get; private set; }
    }
}
