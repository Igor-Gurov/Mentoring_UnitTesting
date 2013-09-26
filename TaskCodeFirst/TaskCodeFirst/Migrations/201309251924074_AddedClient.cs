namespace TaskCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        FIO = c.String(),
                        PaymentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clients", new[] { "PaymentId" });
            DropForeignKey("dbo.Clients", "PaymentId", "dbo.Payments");
            DropTable("dbo.Clients");
        }
    }
}
