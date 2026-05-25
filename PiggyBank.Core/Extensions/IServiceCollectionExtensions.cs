using Microsoft.Extensions.DependencyInjection;
using PiggyBank.Core.Services;
using PiggyBank.Shared.Services;

namespace PiggyBank.Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IPiggyBankServices, PiggyBankServices>();
            services.AddScoped<IPiggyBankTransactionServices, PiggyBankTransactionServices>();
        }
    }
}
