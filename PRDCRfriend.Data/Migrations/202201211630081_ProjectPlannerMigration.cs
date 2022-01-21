namespace PRDCRfriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectPlannerMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectPlanner", "Date", c => c.DateTime(nullable: false));
            CreateIndex("dbo.ProjectPlanner", "ProducerId");
            AddForeignKey("dbo.ProjectPlanner", "ProducerId", "dbo.Producer", "ProducerId", cascadeDelete: true);
            DropColumn("dbo.ProjectPlanner", "SessionId");
            DropColumn("dbo.ProjectPlanner", "StartTime");
            DropColumn("dbo.ProjectPlanner", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectPlanner", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectPlanner", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectPlanner", "SessionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProjectPlanner", "ProducerId", "dbo.Producer");
            DropIndex("dbo.ProjectPlanner", new[] { "ProducerId" });
            DropColumn("dbo.ProjectPlanner", "Date");
        }
    }
}
