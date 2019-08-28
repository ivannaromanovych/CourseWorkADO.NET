namespace FoodDiary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        ProteinsIn100g = c.Single(nullable: false),
                        FatsIn100g = c.Single(nullable: false),
                        CarbohydratesIn100g = c.Single(nullable: false),
                        CaloriesIn100g = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblAtedProducts",
                c => new
                    {
                        DayId = c.Int(nullable: false),
                        DayDate = c.DateTime(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                        AtedProteins = c.Single(nullable: false),
                        AtedFats = c.Single(nullable: false),
                        AtedCarbohydrates = c.Single(nullable: false),
                        AtedCalories = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblDays", t => new { t.DayId, t.DayDate }, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => new { t.DayId, t.DayDate })
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tblDays",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.Date })
                .ForeignKey("dbo.tblUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                        Height = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RecommentedCountOfCalories = c.Single(nullable: false),
                        RecommentedCountOfProteins = c.Single(nullable: false),
                        RecommentedCountOfFats = c.Single(nullable: false),
                        RecommentedCountOfCarbohydrates = c.Single(nullable: false),
                        AtedProteins = c.Single(nullable: false),
                        AtedFats = c.Single(nullable: false),
                        AtedCarbohydrates = c.Single(nullable: false),
                        AtedCalories = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblAtedProducts", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.tblAtedProducts", new[] { "DayId", "DayDate" }, "dbo.tblDays");
            DropForeignKey("dbo.tblDays", "UserId", "dbo.tblUsers");
            DropIndex("dbo.tblDays", new[] { "UserId" });
            DropIndex("dbo.tblAtedProducts", new[] { "ProductId" });
            DropIndex("dbo.tblAtedProducts", new[] { "DayId", "DayDate" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblDays");
            DropTable("dbo.tblAtedProducts");
            DropTable("dbo.tblProducts");
        }
    }
}
