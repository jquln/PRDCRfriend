namespace PRDCRfriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Session", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Session", "Date");
        }
    }
}
