namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ann_model_update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Announcements", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Announcements", "ImagePath", c => c.String());
        }
    }
}
