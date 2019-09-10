namespace FoodDiary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addnew : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.tblDays", new[] { "Date" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.tblDays", "Date", unique: true);
        }
    }
}
