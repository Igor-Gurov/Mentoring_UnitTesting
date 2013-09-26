namespace TaskCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Good = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Goods", t => t.Good, cascadeDelete: true)
                .Index(t => t.Good);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Structure",
                c => new
                    {
                        Good = c.Guid(nullable: false),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Good, t.Category })
                .ForeignKey("dbo.Goods", t => t.Good, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category, cascadeDelete: true)
                .Index(t => t.Good)
                .Index(t => t.Category);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Structure", new[] { "Category" });
            DropIndex("dbo.Structure", new[] { "Good" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropIndex("dbo.Payments", new[] { "Good" });
            DropForeignKey("dbo.Structure", "Category", "dbo.Categories");
            DropForeignKey("dbo.Structure", "Good", "dbo.Goods");
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropForeignKey("dbo.Payments", "Good", "dbo.Goods");
            DropTable("dbo.Structure");
            DropTable("dbo.Categories");
            DropTable("dbo.Goods");
            DropTable("dbo.Payments");
        }
    }
}
