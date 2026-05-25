using System;
using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Shared.DTOs.PiggyBankTransaction
{
    public class CreatePiggyBankTransaction
    {
        [Required]
        public Guid PiggyBankId { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public string TransactionType { get; set; }
    }
}
