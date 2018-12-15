namespace VIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        StreetNo = c.Int(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Image = c.String(),
                        Amount = c.String(),
                        Recipe_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_id)
                .Index(t => t.Recipe_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Tax = c.Int(nullable: false),
                        DateOfOrder = c.DateTime(nullable: false),
                        Customer_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.Customer_id)
                .Index(t => t.Customer_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Lives_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Addresses", t => t.Lives_id)
                .Index(t => t.Lives_id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Image = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Price = c.Int(nullable: false),
                        Order_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.Order_id)
                .Index(t => t.Order_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Order_id", "dbo.Orders");
            DropForeignKey("dbo.Ingredients", "Recipe_id", "dbo.Recipes");
            DropForeignKey("dbo.Orders", "Customer_id", "dbo.Users");
            DropForeignKey("dbo.Users", "Lives_id", "dbo.Addresses");
            DropIndex("dbo.Recipes", new[] { "Order_id" });
            DropIndex("dbo.Users", new[] { "Lives_id" });
            DropIndex("dbo.Orders", new[] { "Customer_id" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_id" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Addresses");
        }
    }
}
