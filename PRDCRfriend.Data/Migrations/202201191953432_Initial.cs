namespace PRDCRfriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Session", "ArtistFirstName");
            DropColumn("dbo.Session", "ArtistLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Session", "ArtistLastName", c => c.String());
            AddColumn("dbo.Session", "ArtistFirstName", c => c.String());
        }
    }
}
