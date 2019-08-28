namespace FoodDiary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblProducts", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblProducts", "Name", c => c.Int(nullable: false));
        }
    }
}
