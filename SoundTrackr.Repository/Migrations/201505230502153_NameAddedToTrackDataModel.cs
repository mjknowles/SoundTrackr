namespace SoundTrackr.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameAddedToTrackDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackDbs", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrackDbs", "Name");
        }
    }
}
