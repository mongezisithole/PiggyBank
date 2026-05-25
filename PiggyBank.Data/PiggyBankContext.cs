using System.Data.Entity;

namespace PiggyBank.Data
{
    public class PiggyBankContext : DbContext
    {
        public PiggyBankContext() : base("Server=localhost;Database=PiggyBank;Trusted_Connection=True;")
        {

        }

        public DbSet<Entities.PiggyBank> PiggyBanks { get; set; }

        public DbSet<Entities.PiggyBankTransaction> PiggyBankTransactions { get; set; }
    }
}
