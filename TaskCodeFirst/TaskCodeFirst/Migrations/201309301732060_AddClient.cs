namespace TaskCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClient : DbMigration
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
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Payments", "ClientId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Payments", "ClientId", "dbo.Clients", "ID", cascadeDelete: true);
            CreateIndex("dbo.Payments", "ClientId");
			
			Sql("insert into Clients(Login,FIO)values(N'anonymous',N'anonymous') if exists(select top 1 * from Payments) begin update Payments set ClientId = (select top 1 ID from Clients where Login='anonymous')end");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Payments", new[] { "ClientId" });
            DropForeignKey("dbo.Payments", "ClientId", "dbo.Clients");
            DropColumn("dbo.Payments", "ClientId");
            DropTable("dbo.Clients");
        }
    }
}
