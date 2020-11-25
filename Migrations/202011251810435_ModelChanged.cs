namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "PhoneNumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "PhoneNumber", c => c.String(nullable: false));
        }
    }
}
