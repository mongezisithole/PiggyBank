using PiggyBank.Shared.DTOs.PiggyBankTransaction;
using PiggyBank.Shared.Enums;
using PiggyBank.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PiggyBank.Shared.DTOs.PiggyBank
{
    public class PiggyBankDetails
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Name { get; set; }

        public DateTime? DeletedDate { get; set; }

        public double Balance
        {
            get
            {
                double balance = 0;

                if (Transactions?.Any() == true)
                {
                    foreach (var transaction in Transactions)
                    {
                        if (transaction.TransactionType == TransactionType.Deposit.GetDescription())
                        {
                            balance += transaction.Value;
                        }
                        else if (transaction.TransactionType == TransactionType.Withdrawal.GetDescription())
                        {
                            balance -= transaction.Value;
                        }
                    }
                }

                return balance;
            }
        }

        public List<PiggyBankTransactionDetails> Transactions { get; set; }
    }
}
