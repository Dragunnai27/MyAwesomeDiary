namespace MyAwesomeDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NationalDays",
                c => new
                    {
                        NationID = c.Int(nullable: false),
                        SpecialDayID = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.NationID, t.SpecialDayID })
                .ForeignKey("dbo.Nations", t => t.NationID, cascadeDelete: true)
                .ForeignKey("dbo.SpecialDays", t => t.SpecialDayID, cascadeDelete: true)
                .Index(t => t.NationID)
                .Index(t => t.SpecialDayID);
            
            CreateTable(
                "dbo.Nations",
                c => new
                    {
                        NationID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NationID);
            
            CreateTable(
                "dbo.SpecialDays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        UserAddress = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Work = c.String(),
                        Intro = c.String(),
                        PrivateAnswer = c.String(nullable: false),
                        NationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Nations", t => t.NationID, cascadeDelete: true)
                .Index(t => t.NationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "NationID", "dbo.Nations");
            DropForeignKey("dbo.NationalDays", "SpecialDayID", "dbo.SpecialDays");
            DropForeignKey("dbo.NationalDays", "NationID", "dbo.Nations");
            DropIndex("dbo.Users", new[] { "NationID" });
            DropIndex("dbo.NationalDays", new[] { "SpecialDayID" });
            DropIndex("dbo.NationalDays", new[] { "NationID" });
            DropTable("dbo.Users");
            DropTable("dbo.SpecialDays");
            DropTable("dbo.Nations");
            DropTable("dbo.NationalDays");
        }
    }
}
