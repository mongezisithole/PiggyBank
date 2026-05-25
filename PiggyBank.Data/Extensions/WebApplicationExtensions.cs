using PiggyBank.Data.Seeding;

namespace PiggyBank.Data.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void SeedData()
        {
            Seed.SeedData();// Seed the database
        }
    }
}
