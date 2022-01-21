namespace PRDCRfriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlannerMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectPlanner", "ArtistFirstName", c => c.String());
            AddColumn("dbo.ProjectPlanner", "ArtistLastName", c => c.String());
            AddColumn("dbo.ProjectPlanner", "Artist", c => c.String());
            DropColumn("dbo.ProjectPlanner", "ArtistName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectPlanner", "ArtistName", c => c.String());
            DropColumn("dbo.ProjectPlanner", "Artist");
            DropColumn("dbo.ProjectPlanner", "ArtistLastName");
            DropColumn("dbo.ProjectPlanner", "ArtistFirstName");
        }
    }
}
