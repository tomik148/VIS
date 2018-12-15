namespace VIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Order_id", "dbo.Orders");
            DropIndex("dbo.Recipes", new[] { "Order_id" });
            CreateTable(
                "dbo.RecipeOrders",
                c => new
                    {
                        Recipe_id = c.Int(nullable: false),
                        Order_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_id, t.Order_id })
                .ForeignKey("dbo.Recipes", t => t.Recipe_id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_id, cascadeDelete: true)
                .Index(t => t.Recipe_id)
                .Index(t => t.Order_id);
            
            DropColumn("dbo.Recipes", "Order_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Order_id", c => c.Int());
            DropForeignKey("dbo.RecipeOrders", "Order_id", "dbo.Orders");
            DropForeignKey("dbo.RecipeOrders", "Recipe_id", "dbo.Recipes");
            DropIndex("dbo.RecipeOrders", new[] { "Order_id" });
            DropIndex("dbo.RecipeOrders", new[] { "Recipe_id" });
            DropTable("dbo.RecipeOrders");
            CreateIndex("dbo.Recipes", "Order_id");
            AddForeignKey("dbo.Recipes", "Order_id", "dbo.Orders", "id");
        }
    }
}
