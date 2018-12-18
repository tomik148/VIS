namespace VIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Tax", c => c.Int());
            AlterColumn("dbo.Orders", "DateOfOrder", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DateOfOrder", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "Tax", c => c.Int(nullable: false));
        }
    }
}
