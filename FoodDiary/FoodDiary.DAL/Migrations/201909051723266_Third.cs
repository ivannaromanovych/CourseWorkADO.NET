namespace FoodDiary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblUsers", "AtedProteins");
            DropColumn("dbo.tblUsers", "AtedFats");
            DropColumn("dbo.tblUsers", "AtedCarbohydrates");
            DropColumn("dbo.tblUsers", "AtedCalories");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUsers", "AtedCalories", c => c.Single(nullable: false));
            AddColumn("dbo.tblUsers", "AtedCarbohydrates", c => c.Single(nullable: false));
            AddColumn("dbo.tblUsers", "AtedFats", c => c.Single(nullable: false));
            AddColumn("dbo.tblUsers", "AtedProteins", c => c.Single(nullable: false));
        }
    }
}
