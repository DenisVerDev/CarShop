namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        SecondName = c.String(maxLength: 25),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 25),
                        LastOnline = c.DateTime(nullable: false),
                        IsCompany = c.Boolean(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mileage = c.Double(nullable: false),
                        EngineCapacity = c.Double(nullable: false),
                        CurrentState = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 300),
                        Price = c.Double(nullable: false),
                        GeoLocation = c.String(nullable: false, maxLength: 100),
                        ImagePath = c.String(),
                        Announcer_Id = c.Int(),
                        BodyStyle_Id = c.Int(nullable: false),
                        CarBrand_Id = c.Int(nullable: false),
                        CarModel_Id = c.Int(nullable: false),
                        EngineType_Id = c.Int(nullable: false),
                        TransmissionType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Announcer_Id)
                .ForeignKey("dbo.CarBodyStyles", t => t.BodyStyle_Id, cascadeDelete: true)
                .ForeignKey("dbo.CarBrands", t => t.CarBrand_Id, cascadeDelete: true)
                .ForeignKey("dbo.CarModels", t => t.CarModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.CarEngineTypes", t => t.EngineType_Id, cascadeDelete: true)
                .ForeignKey("dbo.CarTransmissionTypes", t => t.TransmissionType_Id)
                .Index(t => t.Announcer_Id)
                .Index(t => t.BodyStyle_Id)
                .Index(t => t.CarBrand_Id)
                .Index(t => t.CarModel_Id)
                .Index(t => t.EngineType_Id)
                .Index(t => t.TransmissionType_Id);
            
            CreateTable(
                "dbo.CarBodyStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BodyStyle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        CarBrand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.CarBrand_Id)
                .Index(t => t.CarBrand_Id);
            
            CreateTable(
                "dbo.CarEngineTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EngineType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarTransmissionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransmissionType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Account_Id = c.Int(),
                        Announcement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Announcements", t => t.Announcement_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Announcement_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false, maxLength: 300),
                        Announcement_Id = c.Int(),
                        Commentator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Announcements", t => t.Announcement_Id)
                .ForeignKey("dbo.Accounts", t => t.Commentator_Id)
                .Index(t => t.Announcement_Id)
                .Index(t => t.Commentator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Commentator_Id", "dbo.Accounts");
            DropForeignKey("dbo.Comments", "Announcement_Id", "dbo.Announcements");
            DropForeignKey("dbo.Baskets", "Announcement_Id", "dbo.Announcements");
            DropForeignKey("dbo.Baskets", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Announcements", "TransmissionType_Id", "dbo.CarTransmissionTypes");
            DropForeignKey("dbo.Announcements", "EngineType_Id", "dbo.CarEngineTypes");
            DropForeignKey("dbo.Announcements", "CarModel_Id", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "CarBrand_Id", "dbo.CarBrands");
            DropForeignKey("dbo.Announcements", "CarBrand_Id", "dbo.CarBrands");
            DropForeignKey("dbo.Announcements", "BodyStyle_Id", "dbo.CarBodyStyles");
            DropForeignKey("dbo.Announcements", "Announcer_Id", "dbo.Accounts");
            DropIndex("dbo.Comments", new[] { "Commentator_Id" });
            DropIndex("dbo.Comments", new[] { "Announcement_Id" });
            DropIndex("dbo.Baskets", new[] { "Announcement_Id" });
            DropIndex("dbo.Baskets", new[] { "Account_Id" });
            DropIndex("dbo.CarModels", new[] { "CarBrand_Id" });
            DropIndex("dbo.Announcements", new[] { "TransmissionType_Id" });
            DropIndex("dbo.Announcements", new[] { "EngineType_Id" });
            DropIndex("dbo.Announcements", new[] { "CarModel_Id" });
            DropIndex("dbo.Announcements", new[] { "CarBrand_Id" });
            DropIndex("dbo.Announcements", new[] { "BodyStyle_Id" });
            DropIndex("dbo.Announcements", new[] { "Announcer_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Baskets");
            DropTable("dbo.CarTransmissionTypes");
            DropTable("dbo.CarEngineTypes");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarBrands");
            DropTable("dbo.CarBodyStyles");
            DropTable("dbo.Announcements");
            DropTable("dbo.Accounts");
        }
    }
}
