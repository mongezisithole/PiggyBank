using System.ComponentModel;

namespace PiggyBank.Shared.Enums
{
    public enum TransactionType
    {
        [Description("Deposit")]
        Deposit,
        [Description("Withdrawal")]
        Withdrawal
    }
}
