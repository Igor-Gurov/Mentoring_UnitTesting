namespace TaskCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCashOperationType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashOperationTypies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SpotCashes",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Currency = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CashOperationTypies", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.BankCarded",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        NumberCard = c.Int(nullable: false),
                        Close_Year = c.Int(nullable: false),
                        Close_Month = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CashOperationTypies", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.WebMoney",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CashOperationTypies", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.PayPal",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Account = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CashOperationTypies", t => t.ID)
                .Index(t => t.ID);
            
            AddColumn("dbo.Payments", "CashOperationTypeId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Payments", "CashOperationTypeId", "dbo.CashOperationTypies", "ID", cascadeDelete: true);
            CreateIndex("dbo.Payments", "CashOperationTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PayPal", new[] { "ID" });
            DropIndex("dbo.WebMoney", new[] { "ID" });
            DropIndex("dbo.BankCarded", new[] { "ID" });
            DropIndex("dbo.SpotCashes", new[] { "ID" });
            DropIndex("dbo.Payments", new[] { "CashOperationTypeId" });
            DropForeignKey("dbo.PayPal", "ID", "dbo.CashOperationTypies");
            DropForeignKey("dbo.WebMoney", "ID", "dbo.CashOperationTypies");
            DropForeignKey("dbo.BankCarded", "ID", "dbo.CashOperationTypies");
            DropForeignKey("dbo.SpotCashes", "ID", "dbo.CashOperationTypies");
            DropForeignKey("dbo.Payments", "CashOperationTypeId", "dbo.CashOperationTypies");
            DropColumn("dbo.Payments", "CashOperationTypeId");
            DropTable("dbo.PayPal");
            DropTable("dbo.WebMoney");
            DropTable("dbo.BankCarded");
            DropTable("dbo.SpotCashes");
            DropTable("dbo.CashOperationTypies");
        }
    }
}
