using PiggyBank.Data.Entities;
using PiggyBank.Shared.Enums;
using System;
using System.Linq;

namespace PiggyBank.Data.Seeding
{
    public static class Seed
    {
        public static void SeedData()
        {
            using (var context = new PiggyBankContext())
            {
                var configuration = new Migrations.Configuration();

                var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);

                //Applying all pending migrations to the database
                //It creates the database if it doesn't exist

                migrator.Update();

                if (!context.PiggyBanks.Any())
                {
                    Entities.PiggyBank accOne = new Entities.PiggyBank("Account One");
                    context.PiggyBanks.Add(accOne);
                    
                    for (int i = 0; i < 3; i++)
                    {
                        var random = new Random();
                        context.PiggyBankTransactions.Add(new PiggyBankTransaction(accOne.Id, random.Next(1000, 10000), TransactionType.Deposit));
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        var random = new Random();
                        context.PiggyBankTransactions.Add(new PiggyBankTransaction(accOne.Id, random.Next(100, 1000), TransactionType.Withdrawal));
                    }

                    Entities.PiggyBank accTwo = new Entities.PiggyBank("Account Two");
                    context.PiggyBanks.Add(accTwo);
                    
                    for (int i = 0; i < 3; i++)
                    {
                        var random = new Random();
                        context.PiggyBankTransactions.Add(new PiggyBankTransaction(accTwo.Id, random.Next(2000, 20000), TransactionType.Deposit));
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        var random = new Random();
                        context.PiggyBankTransactions.Add(new PiggyBankTransaction(accTwo.Id, random.Next(200, 2000), TransactionType.Withdrawal));
                    }

                    Entities.PiggyBank accThree = new Entities.PiggyBank("Account Three");
                    context.PiggyBanks.Add(accThree);

                    for (int i = 0; i < 3; i++)
                    {
                        var random = new Random();
                        context.PiggyBankTransactions.Add(new PiggyBankTransaction(accThree.Id, random.Next(3000, 30000), TransactionType.Deposit));
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        var random = new Random();
                        context.PiggyBankTransactions.Add(new PiggyBankTransaction(accThree.Id, random.Next(300, 3000), TransactionType.Withdrawal));
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
