namespace PiggyBank.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PiggyBanks",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false),
                    DeletedDate = c.DateTime(),
                    CreatedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PiggyBankTransactions",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    PiggyBankId = c.Guid(nullable: false),
                    Value = c.Double(nullable: false),
                    TransactionType = c.Int(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PiggyBanks", t => t.PiggyBankId, cascadeDelete: true)
                .Index(t => t.PiggyBankId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.PiggyBankTransactions", "PiggyBankId", "dbo.PiggyBanks");
            DropIndex("dbo.PiggyBankTransactions", new[] { "PiggyBankId" });
            DropTable("dbo.PiggyBankTransactions");
            DropTable("dbo.PiggyBanks");
        }
    }
}
