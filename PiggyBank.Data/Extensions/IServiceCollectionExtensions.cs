using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PiggyBank.Data.Repositories;
using PiggyBank.Data.Seeding;
using PiggyBank.Shared.Repositories;

namespace PiggyBank.Data.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDataRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<PiggyBankContext>();
            services.AddScoped<IPiggyBankRepository, PiggyBankRepository>();
            services.AddScoped<IPiggyBankTransactionRepository, PiggyBankTransactionRepository>();
            
            Seed.SeedData(configuration);// Seed the database
        }
    }
}
