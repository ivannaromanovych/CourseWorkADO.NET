namespace FoodDiary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblAtedProducts", new[] { "DayId", "DayDate" }, "dbo.tblDays");
            DropIndex("dbo.tblAtedProducts", new[] { "DayId", "DayDate" });
            DropPrimaryKey("dbo.tblDays");
            AddColumn("dbo.tblDays", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tblDays", "Id");
            CreateIndex("dbo.tblAtedProducts", "DayId");
            CreateIndex("dbo.tblDays", "Date", unique: true);
            AddForeignKey("dbo.tblAtedProducts", "DayId", "dbo.tblDays", "Id", cascadeDelete: true);
            DropColumn("dbo.tblAtedProducts", "DayDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblAtedProducts", "DayDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.tblAtedProducts", "DayId", "dbo.tblDays");
            DropIndex("dbo.tblDays", new[] { "Date" });
            DropIndex("dbo.tblAtedProducts", new[] { "DayId" });
            DropPrimaryKey("dbo.tblDays");
            DropColumn("dbo.tblDays", "Id");
            AddPrimaryKey("dbo.tblDays", new[] { "UserId", "Date" });
            CreateIndex("dbo.tblAtedProducts", new[] { "DayId", "DayDate" });
            AddForeignKey("dbo.tblAtedProducts", new[] { "DayId", "DayDate" }, "dbo.tblDays", new[] { "UserId", "Date" }, cascadeDelete: true);
        }
    }
}
