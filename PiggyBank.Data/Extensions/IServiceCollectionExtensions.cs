using Microsoft.Extensions.DependencyInjection;
using PiggyBank.Data.Repositories;
using PiggyBank.Data.Seeding;
using PiggyBank.Shared.Repositories;

namespace PiggyBank.Data.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPiggyBankRepository, PiggyBankRepository>();
            services.AddScoped<IPiggyBankTransactionRepository, PiggyBankTransactionRepository>();

            //services.AddDbContext<PiggyBankContext>(options =>
            //{
            //    options.UseNpgsql(configuration.GetConnectionString("BidWalletApiDb"));
            //    options.EnableSensitiveDataLogging();
            //}, ServiceLifetime.Scoped);

            Seed.SeedData();// Seed the database
        }
    }
}
