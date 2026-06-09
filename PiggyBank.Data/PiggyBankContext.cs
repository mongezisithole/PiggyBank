using Microsoft.Extensions.Configuration;
using System.Data.Entity;
using System.Reflection;

namespace PiggyBank.Data
{
    public class PiggyBankContext : DbContext
    {
        public PiggyBankContext()
        {
            
        }
        public PiggyBankContext(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"))
        {
        }

        public DbSet<Entities.PiggyBank> PiggyBanks { get; set; }

        public DbSet<Entities.PiggyBankTransaction> PiggyBankTransactions { get; set; }
    }
}
